using Jasons_Personal_Blog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Jasons_Personal_Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            //Call A repository
            var imgeUrl = await imageRepository.UploadAsync(file);

            if (imgeUrl == null)
            {
                return Problem("Something Went Wrong!", null, (int)HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new {link = imgeUrl});
        }
    }
}
