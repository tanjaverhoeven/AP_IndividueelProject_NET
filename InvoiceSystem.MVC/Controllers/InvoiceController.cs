using InvoiceSystem.BLL;
using InvoiceSystem.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace InvoiceSystem.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        private InvoiceBusinessLogic _invoiceLogic;
        private CustomerBusinessLogic _customerLogic;
        private DetailLineBusinessLogic _detailLogic;

        public InvoiceController()
        {
            _invoiceLogic = new InvoiceBusinessLogic();
            _customerLogic = new CustomerBusinessLogic();
            _detailLogic = new DetailLineBusinessLogic();
        }

        // GET: InvoiceDTOes
        public ActionResult Index()
        {
            return View(_invoiceLogic.GetAll());
        }
        
        // GET: InvoiceDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDTO invoiceDTO = _invoiceLogic.FindById(id);
            List<DetailLineDTO> detailLines = _detailLogic.GetAll().Where(i => i.InvoiceId == invoiceDTO.Id).ToList();
            invoiceDTO.DetailLines = detailLines;
            ViewBag.TotalPriceExcl = _invoiceLogic.GetTotalAmountExcl(invoiceDTO);
            ViewBag.TotalPriceIncl = _invoiceLogic.GetTotalAmountIncl(invoiceDTO);
            if (invoiceDTO == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDTO);
        }

        // GET: InvoiceDTOes/Create
        public ActionResult Create()
        {
            ViewBag.CustumorId = new SelectList(_customerLogic.GetActiveCustomers(), "Id", "Name");
            return View();
        }

        // POST: InvoiceDTOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustumorId,InvoiceDate,Code,State,IsActive,Reason")] InvoiceDTO invoiceDTO)
        {
            if (ModelState.IsValid)
            {
                _invoiceLogic.Insert(invoiceDTO);
                return RedirectToAction("Index");
            }
            ViewBag.CustumorId = new SelectList(_customerLogic.GetActiveCustomers(), "Id", "Name", invoiceDTO.CustumorId);
            return View(invoiceDTO);
        }

        // GET: InvoiceDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDTO invoiceDTO = _invoiceLogic.FindById(id);
            if (invoiceDTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustumorId = new SelectList(_customerLogic.GetActiveCustomers(), "Id", "Name", invoiceDTO.CustumorId);
            return View(invoiceDTO);
        }

        // POST: InvoiceDTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustumorId,InvoiceDate,Code,State,IsActive,Reason")] InvoiceDTO invoiceDTO)
        {
            if (ModelState.IsValid)
            {
                _invoiceLogic.Update(invoiceDTO);                
                return RedirectToAction("Index");
            }
            ViewBag.CustumorId = new SelectList(_customerLogic.GetActiveCustomers(), "Id", "Name", invoiceDTO.CustumorId);
            return View(invoiceDTO);
        }

        // GET: InvoiceDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDTO invoiceDTO = _invoiceLogic.FindById(id);
            if (invoiceDTO == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDTO);
        }

        // POST: InvoiceDTOes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "Id,CustumorId,InvoiceDate,Code,State,IsActive,Reason")] InvoiceDTO invoiceDTO)
        {
            if (ModelState.IsValid)
            {
                if (invoiceDTO.DetailLines.Count == 0)
                {
                    invoiceDTO.IsActive = false;
                    _invoiceLogic.Update(invoiceDTO);
                    return RedirectToAction("Index");
                }  
            }
            return View(invoiceDTO);
        }
    }
}
