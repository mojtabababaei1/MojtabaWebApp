using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.DTOs.ShowSlids
{
    public class ShowSlidDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public DateTime CreationDate { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
