using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interface;

namespace TechnicalTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }
        
        public IActionResult Index()
        {
            var product = _product.GetAll();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product )
        {
            _product.Add(product);
            _product.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id) 
        {
        
               var product = _product.GetById(Id);
               return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _product.Update(product);
            _product.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {

            var product = _product.GetById(Id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _product.Delete(product);
            _product.Save();

            return RedirectToAction("Index");
        }
    }
}