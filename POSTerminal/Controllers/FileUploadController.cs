using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace POSTerminal.Controllers
{
    public class FileUploadController: Controller
    {
        // GET: Upload
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine("~/UploadedFiles", _FileName);
                    using (var stream = new FileStream(_path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
}