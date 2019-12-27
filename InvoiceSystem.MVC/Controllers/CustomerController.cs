using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvoiceSystem.DAL;
using InvoiceSystem.DTO;
using InvoiceSystem.BLL;

namespace InvoiceSystem.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerBusinessLogic _customerLogic;
        private CityBusinessLogic _cityLogic;

        public CustomerController()
        {
            _customerLogic = new CustomerBusinessLogic();
            _cityLogic = new CityBusinessLogic();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(_customerLogic.GetActiveCustomers());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDTO customerDTO = _customerLogic.FindById(id);
            if (customerDTO == null)
            {
                return HttpNotFound();
            }
            return View(customerDTO);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(_cityLogic.GetAll(), "Id", "Postal");
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsActive,Name,Mail,Street,HouseNr,Bus,CityId,PhoneNr,VAT")] CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                _customerLogic.InsertorUpdate(customerDTO);
                return RedirectToAction("Index");
            }

            ViewBag.CityDTO = new SelectList(_cityLogic.GetAll(), "Id", "Postal", customerDTO.CityId);
            return View(customerDTO);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDTO customerDTO = _customerLogic.FindById(id);
            if (customerDTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(_cityLogic.GetAll(), "Id", "Postal", customerDTO.CityId);
            return View(customerDTO);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsActive,Name,Mail,Street,HouseNr,Bus,CityId,PhoneNr,VAT")] CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                customerDTO.IsActive = true;
                _customerLogic.InsertorUpdate(customerDTO);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_cityLogic.GetAll(), "Id", "Postal", customerDTO.CityId);
            return View(customerDTO);
        }
    }
}