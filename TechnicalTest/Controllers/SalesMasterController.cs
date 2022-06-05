using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interface;

namespace TechnicalTest.Controllers
{
    public class SalesMasterController : Controller
    {
        private readonly ISalesMaster _salesMaster;
        public SalesMasterController(ISalesMaster salesMaster)
        {
            _salesMaster = salesMaster;
        }
        
        public IActionResult Index()
        {
            var product = _salesMaster.GetAll();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SalesMaster salesMaster)
        {
            _salesMaster.Add(salesMaster);
            _salesMaster.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id) 
        {
        
               var product = _salesMaster.GetById(Id);
               return View(product);
        }

        [HttpPost]
        public IActionResult Edit(SalesMaster salesMaster)
        {
            _salesMaster.Update(salesMaster);
            _salesMaster.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {

            var product = _salesMaster.GetById(Id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(SalesMaster salesMaster)
        {
            _salesMaster.Delete(salesMaster);
            _salesMaster.Save();

            return RedirectToAction("Index");
        }
    }
}