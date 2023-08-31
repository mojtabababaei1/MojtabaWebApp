using CodeYad_Blog.CoreLayer.DTOs.ShowSlids;
using CodeYad_Blog.CoreLayer.Services.ShowSlids;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.Web.Areas.Admin.Models.ShowSlids;
using Microsoft.AspNetCore.Mvc;

namespace CodeYad_Blog.Web.Areas.Admin.Controllers
{
    public class ShowSlid : AdminControllerBase
    {
        private readonly IShowSlidService _showSlidService;
        public ShowSlid(IShowSlidService showSlidService)
        {
            _showSlidService = showSlidService;
        }

        public IActionResult Index()
        {
            var model = _showSlidService.GetAllShowSlid();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateShowSlidViewModel createViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createViewModel);
            }
            var result = _showSlidService.ShowSlidSabt(new CreateShowSlidDto()
            {
                Title = createViewModel.Title,
                ImageFile=createViewModel.ImageFile
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(CreateShowSlidViewModel.Title), result.Message);
                return View(createViewModel);
            }
                return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var showslid = _showSlidService.GetShowSlidById(id);
            if (showslid == null)
                return RedirectToAction("Index");

            var model = new EditShowSlidViewModel()
            {
                
           Title= showslid.Title
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditShowSlidViewModel editviewmpdel)
        {
            if (!ModelState.IsValid)
            {
                return View(editviewmpdel);
            }

            var result = _showSlidService.EditShoweSlid(new EditShowSlidDto()
            {
            
                ImageFile = editviewmpdel.ImageFile,
              
                Title = editviewmpdel.Title,
                Id = id,
             
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(CreateShowSlidViewModel.Title), result.Message);
                return View(editviewmpdel);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _showSlidService.DeletShowSlidById(Id);

            return RedirectToAction("Index");
        }
        
      

    }
}
