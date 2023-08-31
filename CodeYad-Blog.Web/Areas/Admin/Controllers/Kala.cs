using CodeYad_Blog.CoreLayer.DTOs.Kalas;
using CodeYad_Blog.CoreLayer.Services.Kalas;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.Web.Areas.Admin.Models.Kalas;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodeYad_Blog.Web.Areas.Admin.Controllers
{
    public class Kala : AdminControllerBase
    {
        private readonly IKalaService _kalaService;
        public Kala(IKalaService kalaService)
        {
            _kalaService = kalaService;
        }

        public IActionResult Index()
        {
         
            return View();
        }



        [HttpPost]
        public IActionResult SendMessages(SendMessageViewModel kalamod)
        {
            if (!ModelState.IsValid)
            {
                return View(kalamod);
            }
            var result = _kalaService.CreateKala(new CoreLayer.DTOs.Kalas.CreateKalaDto()
            {
                Name = kalamod.Name,
                PhoneNumber=kalamod.PhoneNumber,
               Message=kalamod.Message,
               Subject = kalamod.Subject
            });
            if (result.Status != OperationResultStatus.Success)
            {
                return View(kalamod);
            }
            return Redirect("/Admin/Kala/Messages");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateKalaVIiewModel crateViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(crateViewModel);
            }
            var result = _kalaService.CreateKala(new CoreLayer.DTOs.Kalas.CreateKalaDto()
            {
                Name = crateViewModel.Name
            });
            if (result.Status != OperationResultStatus.Success)
            {
                return View(crateViewModel);
            }
            return RedirectToAction("Kalaha");
        }

        public IActionResult Kalaha(KalaDto kalaDto)
        {
            return View();
        }
    }
}
