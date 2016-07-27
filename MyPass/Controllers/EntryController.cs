using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPass.Core;
using MyPass.Core.ViewModels;

namespace MyPass.Controllers
{
    public class EntryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Create()
        {

            var viewModel =  new EntryFormViewModel();

            viewModel.Categories = _unitOfWork.CategoryRepository.GetCategories();

            return View(viewModel);
        }
    }
}