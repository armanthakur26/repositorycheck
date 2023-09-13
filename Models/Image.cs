using System.ComponentModel.DataAnnotations.Schema;

namespace imageupload.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string details { get;set; }
       
    }
}
