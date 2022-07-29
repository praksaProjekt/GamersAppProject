using GamersApp.DTO;
using GamersApp.Services.FileServices;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : BaseController
    {
        private readonly IFileServices fileService;

        public FilesController(IFileServices fileService)
        {
            this.fileService = fileService;// ?? throw new ArgumentNullException(nameof(fileService));
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> Upload([FromBody]FileModel model)
        {
            if (await fileService.UploadFileAsync(model) != null)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}