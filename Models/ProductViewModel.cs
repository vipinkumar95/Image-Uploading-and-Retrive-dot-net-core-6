namespace ImageuploadingandRetrive.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Price { get; set; }


        public IFormFile Photo { get; set; }
    }
}
