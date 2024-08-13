using System.ComponentModel.DataAnnotations;

namespace ImageuploadingandRetrive.Models
{
    public class Uploadimage
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Price { get; set; }


        public string Image_path { get; set; }
    }
}
