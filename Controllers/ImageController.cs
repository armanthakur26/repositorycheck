//using imageupload.Data;
//using imageupload.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace imageupload.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImageController : ControllerBase
//    {
//        private  readonly Applicationdbcontext _context;
//        private readonly IWebHostEnvironment _environment;
        
//        public ImageController(Applicationdbcontext context,IWebHostEnvironment environment)
//        {
//            _context = context;
//            _environment = environment;
//        }
//        //[HttpPost]
//        //public async Task<string> Post([FromForm]Image image)
//        //{


//        //    try 
//        //    {
//        //        if (image.image.Length > 0)
//        //        {
//        //            string path = _environment.WebRootPath + "\\uploads\\";
//        //            if (!Directory.Exists(path))
//        //            {
//        //                Directory.CreateDirectory(path);
//        //            }
//        //            using (FileStream fileStream = System.IO.File.Create(path + image.image.FileName))
//        //            {
//        //                image.image.CopyTo(fileStream);
//        //                fileStream.Flush();
//        //                return "upload done";
//        //            }
//        //        }
//        //        else
//        //        { 
//        //            return "upload failed";
//        //        }

//        //    }
//        //catch(Exception ex)
//        //    {
//        //    return ex.Message;
//        //    }
//        //}


//        [HttpPost]
//        public async Task<string> Post([FromForm] Image imageWithFile)
//        {
//            try
//            {
//                if (imageWithFile.image.Length > 0)
//                {
//                    string path = Path.Combine(_environment.WebRootPath, "uploads");
//                    if (!Directory.Exists(path))
//                    {
//                        Directory.CreateDirectory(path);
//                    }

//                    using (FileStream fileStream = new FileStream(Path.Combine(path, imageWithFile.image.FileName), FileMode.Create))
//                    {
//                        await imageWithFile.image.CopyToAsync(fileStream);

                      
//                        var image = new Image
//                        {
//                            Id = imageWithFile.Id,
//                            Name = imageWithFile.Name
//                        };
//                        _context.images.Add(image);
//                        _context.SaveChanges();

//                        return "Upload";
//                    }
//                }
//                else
//                {
//                    return "Upload failed";
//                }
//            }
//            catch (Exception ex)
//            {
//                return ex.Message;
//            }
//        }

//        //[HttpGet]
//        //public ActionResult<IEnumerable<Image>> GetImages()
//        //{
//        //    var images = _context.images.ToList();
//        //    return Ok(images);
//        //}


//        //[HttpGet]
//        //public async Task<IActionResult> Get([FromRoute] string filename)
//        //{
//        //    string path = _environment.WebRootPath + "uploads";
//        //    var filepath = path + filename + ".jpg";
//        //    if(System.IO.File.Exists(filepath))
//        //    {
//        //        byte[] b=System.IO.File.ReadAllBytes(filepath);
//        //        return File(b, "image/jpg");
//        //    }
//        //    return null;
//        //}   


//        [HttpGet("{identifier}")]
//        public async Task<IActionResult> Get(string identifier)
//        {
//            if (int.TryParse(identifier, out int id))
//            {
//                var image = _context.images.FirstOrDefault(i => i.Id == id);
//                if (image == null)
//                {
//                    return NotFound("Image not found");
//                }

//                string filename = id + ".jpg";
//                string path = Path.Combine(_environment.WebRootPath, "uploads", filename);

//                if (System.IO.File.Exists(path))
//                {
//                    byte[] b = System.IO.File.ReadAllBytes(path);
//                    return File(b, "image/jpg");
//                }
//                else
//                {
//                    return NotFound("Image file not found");
//                }
//            }
//            else
//            {
//                string filename = identifier + ".jpg";
//                string path = Path.Combine(_environment.WebRootPath, "uploads", filename);

//                if (System.IO.File.Exists(path))
//                {
//                    byte[] b = System.IO.File.ReadAllBytes(path);
//                    return File(b, "image/jpg");
//                }
//                else
//                {
//                    return NotFound("Image file not found");
//                }
//            }
//        }
//    }
//}

