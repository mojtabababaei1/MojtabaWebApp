using CodeYad_Blog.CoreLayer.DTOs.Kalas;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.Kalas
{
    public interface IKalaService
    {
        List<KalaDto> GetAllKala();
        OperationResult CreateKala(CreateKalaDto command);
        OperationResult SendMessages(SendMessagesDto command);
        KalaDto GetKalaById(int id);
    }
}
