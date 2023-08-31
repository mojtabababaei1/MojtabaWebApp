using CodeYad_Blog.CoreLayer.DTOs.ShowSlids;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeYad_Blog.CoreLayer.Mappers
{
    public class ShowSlidMapper
    {
        public static ShowSlid MapCreateDtoToShowSlid(CreateShowSlidDto dto)
        {
            return new ShowSlid()
            {
                Title = dto.Title,


            };
        }


        public static ShowSlidDto MapToDto(ShowSlid showSlid)
        {
            return new ShowSlidDto()
            {
             Id=showSlid.Id,
                Title = showSlid.Title,
                ImageName = showSlid.ImageName

            };
        }
        public static ShowSlid EditShowSlid(EditShowSlidDto editDto, ShowSlid showSlid)
        {
            
            showSlid.Title = editDto.Title;
        
            return showSlid;
        }
        public static ShowSlid DeleteShowSlid(deletShowSlidDto delettDto, ShowSlid showSlid)
        {

            showSlid.Id = delettDto.Id;
            showSlid.Title = delettDto.Title;
            showSlid.ImageName = delettDto.ImageName;


            return showSlid;
        }
    }
}
