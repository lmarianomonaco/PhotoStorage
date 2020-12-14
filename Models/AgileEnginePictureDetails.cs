using System.ComponentModel.DataAnnotations;

namespace Photos.Models
{
    public class AgileEnginePictureDetails
    {
        public string id { get; set; }
        public string author { get; set; }
        public string camera { get; set; }
        public string tags { get; set; }
        public string cropped_picture { get; set; }
        public string full_picture { get; set; }
    }
}