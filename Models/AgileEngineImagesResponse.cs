using System.Collections.Generic;

namespace Photos.Models
{
    public class AgileEngineImagesResponse
    {
        public List<AgileEnginePicture> pictures { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }
        public bool hasMore { get; set; }
    }   
}