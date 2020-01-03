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
    public class DetailLineController : Controller
    {
        private DetailLineBusinessLogic _detailLogic;
        private InvoiceBusinessLogic _invoiceLogic;
        
        public DetailLineController()
        {
            _detailLogic = new DetailLineBusinessLogic();
            _invoiceLogic = new InvoiceBusinessLogic();
        }

        // GET: DetailLine
        public ActionResult Index()
        {
            var detailLineDTOes = _detailLogic.GetAll();
            return View(detailLineDTOes.ToList());
        }

        // GET: DetailLine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailLineDTO detailLineDTO = _detailLogic.FindById(id);
            if (detailLineDTO == null)
            {
                return HttpNotFound();
            }
            return View(detailLineDTO);
        }

        // GET: DetailLine/Create
        public ActionResult Create(int? id)
        {
            ViewBag.InvoiceId = _invoiceLogic.FindById(id);
            return View();
        }

        // POST: DetailLine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InvoiceId,Item,UnitPrice,Discount,Amount,VATPercentage")] DetailLineDTO detailLineDTO, InvoiceDTO InvoiceId)
        {
            if (ModelState.IsValid)
            {
                detailLineDTO.InvoiceId = _invoiceLogic.FindById(InvoiceId.Id).Id;
                _detailLogic.Insert(detailLineDTO);
                return RedirectToAction("Details", "Invoice", new { id = detailLineDTO.InvoiceId });
            }

            ViewBag.InvoiceId = _invoiceLogic.FindById(detailLineDTO.InvoiceId);
            return View(detailLineDTO);
        }

        // GET: DetailLine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailLineDTO detailLineDTO = _detailLogic.FindById(id);
            if (detailLineDTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceId = _invoiceLogic.FindById(detailLineDTO.InvoiceId);
            return View(detailLineDTO);
        }

        // POST: DetailLine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InvoiceId,Item,UnitPrice,Discount,Amount,VATPercentage")] DetailLineDTO detailLineDTO)
        {
            if (ModelState.IsValid)
            {
                _detailLogic.Update(detailLineDTO);
                return RedirectToAction("Details", "Invoice", new { id = detailLineDTO.InvoiceId });
            }
            ViewBag.InvoiceId = _invoiceLogic.FindById(detailLineDTO.InvoiceId);
            return View(detailLineDTO);
        }

        // GET: DetailLine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailLineDTO detailLineDTO = _detailLogic.FindById(id);
            if (detailLineDTO == null)
            {
                return HttpNotFound();
            }
            return View(detailLineDTO);
        }

        // POST: DetailLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailLineDTO detailLineDTO = _detailLogic.FindById(id);
            _detailLogic.Delete(detailLineDTO);
            return RedirectToAction("Details", "Invoice", new { id = detailLineDTO.InvoiceId });
        }
    }
}
