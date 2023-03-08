using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace WebAPI_upload_file.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileHandlingController : ControllerBase
    {
        private readonly string _directoryPath;

        public FileHandlingController()
        {
            _directoryPath = Directory.GetCurrentDirectory();
        }


        /// <summary>
        /// Creates a Directory.
        /// </summary>
        /// <response code="200">Directory created successfully</response>
        /// <response code="409">Directory already exist</response>
        /// <response code="500">An error occurred while creating directory</response>
        [HttpPost("CreateDirectory/{directoryName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateDirectory(string directoryName)
        {
            try
            {
                string newDirectoryPath = Path.Combine(_directoryPath, directoryName);
                if (Directory.Exists(newDirectoryPath))
                    return Conflict("Directory already exist");
                Directory.CreateDirectory(newDirectoryPath);
                return Ok("Directory created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating directory. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Uploads file
        /// </summary>
        /// <response code="200">File uploaded</response>
        /// <response code="400">File not in correct format or size or not found</response>
        /// <response code="409">File already exist</response>
        /// <response code="500">An error occurred while uploading file</response>
        
        [HttpPost("UploadFile/{directoryName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UploadFile([FromForm] string fileToCopy, string directoryName)
        {
            try
            {
                if (System.IO.File.Exists(fileToCopy))
                {
                    if (fileToCopy != "")
                    {
                        string[] allowedFileTypes = { ".txt", ".jpg", ".png", ".xlsx" };
                        string fileName = Path.GetFileName(fileToCopy);
                        string fileExtension = Path.GetExtension(fileToCopy);

                        if (!allowedFileTypes.Contains(fileExtension))
                            return BadRequest("File type not Allowed. Only txt/png/xls/jpg files are allowed.");

                        long minFileSize = 10485760;
                        long fileLength = new System.IO.FileInfo(fileToCopy).Length;
                        if (fileLength < minFileSize)
                            return BadRequest("File size should be greater than 10MB");

                        string newFilePath = Path.Combine(_directoryPath, directoryName, fileName);

                        if (System.IO.File.Exists(newFilePath))
                            return Conflict("File Already exist");

                        using (FileStream fileStreamToCopy = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                        {
                            using (FileStream fileStreamToRead = new FileStream(fileToCopy, FileMode.Open, FileAccess.Read))
                            {
                                fileStreamToRead.CopyTo(fileStreamToCopy);
                                return Ok("File Uplaoaded successfully");
                            }
                        }
                    }
                    return BadRequest("No file was uploaded");
                }

                return Conflict("File not found to copy");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while uploading the file. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes file
        /// </summary>
        /// <response code="200">File Deleted</response>
        /// <response code="400">File not found</response>
        /// <response code="500">An error occurred while deleting file</response>
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteFile([FromForm] string directoryName, [FromForm] string fileName)
        {
            try
            {
                string filePath = Path.Combine(_directoryPath, directoryName, fileName);
                if (!System.IO.File.Exists(filePath))
                    return BadRequest("File not found");
                System.IO.File.Delete(filePath);
                return Ok("File deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while deleting file. Error: {ex.Message}");
            }
        }
    }
}
