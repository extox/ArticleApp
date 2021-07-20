using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleApp.MVC.Controllers
{
    public class UploadController : Controller
    {
        private readonly ILogger<UploadController> _logger;
        private readonly IHostingEnvironment _environment;

        public UploadController(ILogger<UploadController> logger, IHostingEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(IFormFile[] files)
        {
            //1. Path Setting
            var path = Path.Combine(_environment.WebRootPath, @"UploadFiles");

            foreach (var file in files)
            {
                //2. 파일 이름, 확장자 처리
                var fileFullName = file.FileName.Split('.'); // DB에서 fileSaveName과 매핑 필요
                var fileSaveName = $"{Guid.NewGuid()}.{fileFullName[1]}"; // ex) 4b169355-bdca-4dd1-aa9c-f745816022bb.pdf

                //3. 파일 스트림 > 저장
                using (var fileStream = new FileStream(Path.Combine(path, fileSaveName), FileMode.Create))
                {
                    //file.CopyTo(fileStream);
                    await file.CopyToAsync(fileStream);
                }
            }

            ViewBag.Message = files.Length + @"개 파일 업로드 성공";

            return View();
        }
    }
}
