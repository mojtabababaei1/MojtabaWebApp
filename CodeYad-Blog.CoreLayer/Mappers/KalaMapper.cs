using CodeYad_Blog.CoreLayer.DTOs.Kalas;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Mappers
{
    public class KalaMapper
    {
        public static Kala MapCrateDtoToKala(CreateKalaDto dto)
        {
            return new Kala()
            {
                Name = dto.Name,
                PhoneNumber=dto.PhoneNumber,
                subject=dto.Subject,
                Message=dto.Message
                
            };
        }

        public static Kala MapSendMessageToKala(SendMessagesDto dto)
        {
            return new Kala()
            {
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                subject = dto.Subject,
                Message = dto.Message

            };
        }
        public static KalaDto MapToDto(Kala kala)
        {
            return new KalaDto()
            {
                KalaId=kala.Id,
                Name=kala.Name,
                PhoneNumber=kala.PhoneNumber,
                Subject=kala.subject,
                Message= kala.Message
            };
        }
    }
}
