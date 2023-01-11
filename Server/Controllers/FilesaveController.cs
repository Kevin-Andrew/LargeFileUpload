using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LargeFileUpload.Shared;

namespace LargeFileUpload.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RequestFormLimits(MultipartBodyLengthLimit = Int64.MaxValue)]
    public class FilesaveController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> PostFile([FromForm] IFormFile file)
        {
            var result = String.Empty;

            try
            {
                Console.WriteLine($"{DateTime.Now}: Staring to read file.");

                var buffer = new byte[80 * 1000]; // Just under the Large Object Heap limit size.
                var bytesRead = 0;
                var totalBytes = 0;
                using var sr = file.OpenReadStream();

                while ((bytesRead = sr.Read(buffer, 0, buffer.Length)) > 0)
                {
                    totalBytes += bytesRead;
                }

                result = $"Read {totalBytes:#,##} bytes.";
            }
            catch (Exception ex)
            {
                result = $"Server error: {ex}";
            }

            Console.WriteLine(result);

            return Ok(result);
        }
    }
}