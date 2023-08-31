using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.Web.Areas.Admin.Models.ShowSlids
{
    public class CreateShowSlidViewModel
    {
        [Display(Name = "متن کاروسل ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }
 
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; }
    }
    public class EditShowSlidViewModel
    {
   


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

    

  

        [Display(Name = "عکس")]
        public IFormFile ImageFile { get; set; }

       
    }
}
