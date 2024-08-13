using ImageuploadingandRetrive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ImageuploadingandRetrive.Controllers
{
    public class UploadController : Controller
    {
        private readonly ApplicationDbContext db;

        IWebHostEnvironment env;


        public UploadController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            this.db = db;   
            this.env = env;
        }
        public IActionResult Index()
        {
            return View(db.uploadimages.ToList());
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel model)
        {
            string Filname = "";
            if (model.Photo != null) 
            {
                var ext = Path.GetExtension(model.Photo.FileName);
                var size = model.Photo.Length;

                if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg"));
                {
                    if (size <= 1000000)
                    {
                        string folder = Path.Combine(env.WebRootPath, "images");
                        Filname = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                        string filepath = Path.Combine(folder, Filname);
                        model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));

                        Uploadimage p = new Uploadimage()
                        {
                            Name = model.Name,
                            Price = model.Price,
                            Image_path = Filname,
                        };
                        db.uploadimages.Add(p);
                        db.SaveChanges();
                        TempData["Success"] = "Product Added";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["size"] = "image less then only 1 MB";
                    }   
                }
            }
            else
            {
                TempData["file"] = "image only png, jpg, jpeg";
            }
            return View();
        }
         
    }
}
