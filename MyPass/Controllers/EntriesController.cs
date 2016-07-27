using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyPass.Core;
using MyPass.Core.Models;
using MyPass.Core.ViewModels;

namespace MyPass.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Create()
        {

            var viewModel =  new EntryFormViewModel();

            viewModel.Categories = _unitOfWork.CategoryRepository.GetCategories();
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(EntryFormViewModel viewModel)
        {

            //if (!ModelState.IsValid)
            //{
            //    viewModel.Categories = _unitOfWork.CategoryRepository.GetCategories();
            //    return View("GigForm", viewModel);
            //}

            var entry = new Entry
            {
                CreatedById = new Guid(User.Identity.GetUserId()),
                CreatedOn = viewModel.GetDateTime(),
                CategoryId = viewModel.CategoryId,
                Name = viewModel.Name,
                Description =  viewModel.Desription
            };

            _unitOfWork.EntryRepository.Add(entry);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}