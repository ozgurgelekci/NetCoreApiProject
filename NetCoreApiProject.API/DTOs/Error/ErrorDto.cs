using System.Collections.Generic;

namespace NetCoreApiProject.API.DTOs.Error
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }
    }
}
