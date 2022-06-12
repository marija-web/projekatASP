using Microsoft.AspNetCore.Http;
using projekatASP.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.Api.DTO
{
    public class UploadFileDTO : CreatePostDTO
    {
        public IFormFile FileImage { get; set; }
    }
}
