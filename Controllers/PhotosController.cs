using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Photos.Models;

namespace Photos.Controllers
{
    public class PhotosController : Controller
    {
        private const string _baseUrl = "http://interview.agileengine.com/";
        private readonly ILogger<PhotosController> _logger;
        private IMemoryCache _cache;
        private MemoryCacheEntryOptions _cacheEntryOptions;

        public PhotosController(ILogger<PhotosController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
            _cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));
        }
        public IActionResult Index(int page = 1)
        {
            AgileEngineImagesResponse imagesResponse = null;

            try
            {
                var cacheEntryKey = $"page_{ page }";
                if (!_cache.TryGetValue(cacheEntryKey, out imagesResponse))
                {
                    var httpRequest = (HttpWebRequest)WebRequest.Create(string.Concat(_baseUrl, "images?page=", page));
                    httpRequest.Headers["Authorization"] = $"Bearer { GetToken() }";

                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var json = string.Empty;
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            json = streamReader.ReadToEnd();
                        }

                        imagesResponse = JsonConvert.DeserializeObject<AgileEngineImagesResponse>(json);
                        _cache.Set(cacheEntryKey, imagesResponse, _cacheEntryOptions);
                    }
                    httpResponse.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return View(imagesResponse);
        }
        public IActionResult Details(string id)
        {
            AgileEnginePictureDetails pictureDetails = null;

            try
            {
                List<AgileEnginePictureDetails> pictures = null;
                var cacheEntryKey = "pictures";
                if (!_cache.TryGetValue(cacheEntryKey, out pictures))
                {
                    pictures = new List<AgileEnginePictureDetails>();
                }

                if (pictures.Any(p => p.id.Equals(id)))
                {
                    pictureDetails = pictures.Single(p => p.id.Equals(id));
                }
                else
                {
                    var httpRequest = (HttpWebRequest)WebRequest.Create(string.Concat(_baseUrl, "images/", id));
                    httpRequest.Headers["Authorization"] = $"Bearer { GetToken() }";

                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var json = string.Empty;
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            json = streamReader.ReadToEnd();
                        }

                        pictureDetails = JsonConvert.DeserializeObject<AgileEnginePictureDetails>(json);

                        pictures.Add(pictureDetails);
                        _cache.Set(cacheEntryKey, pictures, _cacheEntryOptions);
                    }
                    httpResponse.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return View(pictureDetails);
        }

        /// <summary>
        /// Search is not case sensitive
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IActionResult Search(string searchTerm)
        {
            var searchResults = new List<AgileEnginePictureDetails>();

            try
            {
                List<AgileEnginePictureDetails> pictures = null;
                var cacheEntryKey = "pictures";
                if (_cache.TryGetValue(cacheEntryKey, out pictures))
                {
                    searchTerm = searchTerm != null ? searchTerm.ToLower() : string.Empty;
                    searchResults = pictures
                        .Where(p =>
                        (p.author != null && p.author.ToLower().Contains(searchTerm))
                        || (p.camera != null && p.camera.ToLower().Contains(searchTerm))
                        || p.id.ToLower().Contains(searchTerm)
                        || (p.tags != null && p.tags.ToLower().Contains(searchTerm)))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return View(searchResults);
        }

        #region Private Methods

        /// <summary>
        /// Gets authorization token
        /// </summary>
        /// <returns>token</returns>
        private string GetToken()
        {
            var token = string.Empty;

            try
            {
                var cacheEntryKey = "token";
                if (!_cache.TryGetValue(cacheEntryKey, out token))
                {
                    var httpRequest = (HttpWebRequest)WebRequest.Create(string.Concat(_baseUrl, "auth"));
                    httpRequest.Method = "POST";
                    httpRequest.ContentType = "application/json";

                    var data = "{ \"apiKey\": \"23567b218376f79d9415\" }";
                    using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                    {
                        streamWriter.Write(data);
                    }

                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var json = string.Empty;
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            json = streamReader.ReadToEnd();
                        }

                        var authResponse = JsonConvert.DeserializeObject<AgileEngineAuthResponse>(json);
                        token = authResponse.token;
                        _cache.Set(cacheEntryKey, token, _cacheEntryOptions);
                    }
                    httpResponse.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return token;
        }

        #endregion
    }
}