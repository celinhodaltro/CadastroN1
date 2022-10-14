using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductViewModelService _productViewModelService;
        private readonly IClientViewModelService _clientViewModelService;
        public ProductsController(IProductViewModelService productViewModelService, IClientViewModelService clientViewModelService)
        {
            _productViewModelService = productViewModelService;
            _clientViewModelService = clientViewModelService;
        }

        // GET: Clients
        public ActionResult Index()
        {
            var list = _productViewModelService.GetAll();

            foreach (var product in list)
                product.Client = _clientViewModelService.Get(product.ClientId);

            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            viewModel.Client = _clientViewModelService.Get(viewModel.ClientId);

            return View(viewModel);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var ViewModel = new ProductTransferModel();
            ViewModel.Clients = _clientViewModelService.GetAll();

            if (ViewModel.Clients != null && ViewModel.Clients.Count() > 0)
                ViewModel.Clients = ViewModel.Clients.Where(tb => tb.Ative == true);

            return View(ViewModel);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductTransferModel viewModel)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    _productViewModelService.Insert(viewModel.Product);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {

            var ViewModel = new ProductTransferModel();

            
            ViewModel.Product = _productViewModelService.Get(id);

            if(ViewModel.Product.Value != 0)
                ViewModel.Product.InputValue = Convert.ToString(ViewModel.Product.Value).Replace(',','.');

            ViewModel.Clients = _clientViewModelService.GetAll();

            if (ViewModel.Clients != null && ViewModel.Clients.Count() > 0)
                ViewModel.Clients = ViewModel.Clients.Where(tb => tb.Ative == true);

            return View(ViewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductTransferModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Update(viewModel.Product);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            viewModel.Client = _clientViewModelService.Get(viewModel.ClientId);
            return View(viewModel);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
