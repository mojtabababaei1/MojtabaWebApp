using CodeYad_Blog.CoreLayer.DTOs.ShowSlids;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.ShowSlids
{
    public interface IShowSlidService
    {
        OperationResult ShowSlidSabt(CreateShowSlidDto showSlidDto);
        List<ShowSlidDto> GetAllShowSlid();
        OperationResult EditShoweSlid(EditShowSlidDto showSlidDto);
        ShowSlidDto GetShowSlidById(int Id);
        ShowSlidDto DeletShowSlidById(int Id);
    }
}
