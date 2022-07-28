using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using System;
using GamersApp.Services.FileServices;
using GamersApp.DTO;

namespace MyAppBackend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
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