using CodeYad_Blog.CoreLayer.DTOs.Kalas;
using CodeYad_Blog.CoreLayer.Mappers;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.Kalas
{
    public class KalaService : IKalaService
    {
        private readonly BlogContext _context;
        public KalaService(BlogContext context)
        {
            _context = context;
        }

     

        public OperationResult CreateKala(CreateKalaDto command)
        {
               if (command == null)
                return OperationResult.Error();
            var kala = KalaMapper.MapCrateDtoToKala(command);

            _context.Kalas.Add(kala);
            _context.SaveChanges();

            return OperationResult.Success();
        }

        public List<KalaDto> GetAllKala()
        {
            return _context.Kalas.Select(k => KalaMapper.MapToDto(k)).ToList();
        }

        public KalaDto GetKalaById(int id)
        {
            var kala = _context.Kalas
              
               .Include(c => c.Id)
               .FirstOrDefault(c => c.Id ==id);
            return KalaMapper.MapToDto(kala);
        }

        public OperationResult SendMessages(SendMessagesDto command)
        {
            if (command == null)
                return OperationResult.Error();
            var kala = KalaMapper.MapSendMessageToKala(command);

            _context.Kalas.Add(kala);
            _context.SaveChanges();

            return OperationResult.Success();
        }
    }
}
