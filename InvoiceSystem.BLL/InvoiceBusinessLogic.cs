using InvoiceSystem.DAL.Models;
using InvoiceSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.BLL
{
    public class InvoiceBusinessLogic
    {
        private InvoiceRepository _invoiceDA = new InvoiceRepository();
        private DetailLineBusinessLogic _detailLineDA = new DetailLineBusinessLogic();

        public void InsertorUpdate(Invoice invoice) => _invoiceDA.InsertorUpdate(invoice);

        public void Delete(Invoice invoice) => _invoiceDA.Delete(invoice);

        public Invoice FindById(int? id) => _invoiceDA.FindById(id);

        public List<Invoice> GetAll() => _invoiceDA.All().Where(i => i.IsActive == true).ToList();

        public void SetInvoiceInactive(int? id)
        {
            Invoice invoice = _invoiceDA.FindById(id);
            invoice.IsActive = false;
            _invoiceDA.InsertorUpdate(invoice);
        }

        public bool HasDetailLines(Invoice invoice)
        {
            bool hasDetailLines;
            List<DetailLine> detailLines = _detailLineDA.FindByInvoice(invoice);
            if (detailLines.Count > 0)
            {
                hasDetailLines = true;
            }
            else
            {
                hasDetailLines = false;
            }
            return hasDetailLines;
        }


        public decimal GetTotalAmount(List<DetailLine> detailLines)
        {
            decimal totalAmount = 0;
            foreach (DetailLine detailLine in detailLines)
            {
                totalAmount += detailLine.Amount * detailLine.UnitPrice;
            }
            return totalAmount;
        }

        public decimal GetDiscount(List<DetailLine> detailLines)
        {
            decimal totalDiscount = 0;
            foreach (DetailLine detailLine in detailLines)
            {
                decimal percentage = detailLine.Discount / 100;
                totalDiscount += detailLine.UnitPrice * detailLine.Amount * percentage;
            }
            return totalDiscount;
        }

        public decimal GetVAT(List<DetailLine> detailLines)
        {
            decimal totalVAT = 0;
            foreach (DetailLine detailLine in detailLines)
            {
                decimal percentage = detailLine.Discount / 100;
                totalVAT += detailLine.UnitPrice * detailLine.Amount * percentage;
            }
            return totalVAT;
        }

        public decimal GetTotalPrice(List<DetailLine> detailLines)
        {
            decimal totalAmount = this.GetTotalAmount(detailLines);
            decimal totalDiscount = this.GetDiscount(detailLines);
            decimal totalVAT = this.GetVAT(detailLines);

            decimal total = totalAmount - totalDiscount + totalVAT;
            return total;
        }

        //calculate the counter based on the month
        public int GetCounter(DateTime date)
        {
            List<Invoice> invoices = this._invoiceDA.All().Where(i => i.InvoiceDate.Month == date.Month).ToList();
            if (invoices.Count == 0)
            {
                return 0;
            }
            else
            {
                return invoices.Max(i => int.Parse(i.Code.Split('-')[2]));
            }
        }

        //calculate the invoice code
        public string GetCode(DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString("D2");
            int counter = GetCounter(date);
            string output = $"{year}-{month}-{++counter:0000}";
            return output;
        }

        //compare months to reset counter after each month
        public bool HasDifferentMonth(Invoice oldInvoice, Invoice newInvoice)
        {
            bool output = false;
            if (oldInvoice.InvoiceDate.Month != newInvoice.InvoiceDate.Month)
            {
                output = true;
            }
            return output;
        }
    }
}
