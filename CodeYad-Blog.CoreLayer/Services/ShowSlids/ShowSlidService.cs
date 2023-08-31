using CodeYad_Blog.CoreLayer.DTOs.ShowSlids;
using CodeYad_Blog.CoreLayer.Mappers;
using CodeYad_Blog.CoreLayer.Services.FileManager;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.ShowSlids
{

    public class ShowSlidService : IShowSlidService
    {
        private readonly BlogContext _context;
        private readonly IFileManager _fileManger;
        public ShowSlidService(BlogContext context,IFileManager fileManager)
        {
            _context = context;
            _fileManger = fileManager;
        }

     

        public OperationResult EditShoweSlid(EditShowSlidDto showSlidDto)
        {
           
                var ShowSlid = _context.showSlids.FirstOrDefault(c => c.Id == showSlidDto.Id);
                if (ShowSlid == null)
                    return OperationResult.NotFound();

            var oldImage = ShowSlid.ImageName;
            //var newSlug = command.Slug.ToSlug();



            ShowSlidMapper.EditShowSlid(showSlidDto, ShowSlid);
                if (showSlidDto.ImageFile != null)
                ShowSlid.ImageName = _fileManger.SaveImageAndReturnImageName(showSlidDto.ImageFile, Directories.PostImage);

                _context.SaveChanges();

            if (showSlidDto.ImageFile != null)
                _fileManger.DeleteFile(oldImage, Directories.PostImage);



            return OperationResult.Success();
            }
        

        public List<ShowSlidDto> GetAllShowSlid()
        {
            return _context.showSlids.Select(p => ShowSlidMapper.MapToDto(p)).ToList();
        }

        public ShowSlidDto GetShowSlidById(int Id)
        {
            var showslid = _context.showSlids.FirstOrDefault(c => c.Id == Id);
            return ShowSlidMapper.MapToDto(showslid);
        
       
       
        }

        public OperationResult ShowSlidSabt(CreateShowSlidDto showSlidDto)
        {
            if (showSlidDto.ImageFile == null)
                return OperationResult.Error();
            var showSlid = ShowSlidMapper.MapCreateDtoToShowSlid(showSlidDto);


            var isShowSlidExist = _context.showSlids.Any(s => s.Title == showSlidDto.Title);
            if (isShowSlidExist)
              return  OperationResult.Error(" متن تکراری است");

            showSlid.ImageName = _fileManger.SaveImageAndReturnImageName(showSlidDto.ImageFile, Directories.PostImage);
            _context.showSlids.Add(showSlid);
        
            _context.SaveChanges();
          return  OperationResult.Success();

        }

           public ShowSlidDto DeletShowSlidById(int id)
        {
            var showslid = _context.showSlids.FirstOrDefault(x=>x.Id==id);
            if(showslid != null)
            {
             _context.Remove(showslid);
                _context.SaveChanges();
                return ShowSlidMapper.MapToDto(showslid);
            }


            return null;
        
        }
    }
}
