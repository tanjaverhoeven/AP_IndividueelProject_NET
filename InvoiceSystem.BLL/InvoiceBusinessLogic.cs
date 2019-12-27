using AutoMapper;
using InvoiceSystem.DAL;
using InvoiceSystem.DAL.Models;
using InvoiceSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.BLL
{
    public class InvoiceBusinessLogic
    {
        private UnitOfWork _unitOfWork;

        public InvoiceBusinessLogic()
        {
            _unitOfWork = new UnitOfWork();
        }

        public static Invoice Map(InvoiceDTO e)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InvoiceDTO, Invoice>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            Invoice model = mapper.Map<Invoice>(e);
            return model;
        }

        public static InvoiceDTO Map(Invoice e)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Invoice, InvoiceDTO>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            InvoiceDTO dto = mapper.Map<InvoiceDTO>(e);
            return dto;
        }

        public List<InvoiceDTO> GetAll()
        {
            List<InvoiceDTO> invoiceDTOs = new List<InvoiceDTO>();
            List<Invoice> invoices = _unitOfWork.InvoiceRepo.All().Where(i => i.IsActive == true).ToList();

            foreach (var invoice in invoices)
            {
                invoiceDTOs.Add(Map(invoice));
            }

            return invoiceDTOs;
        }

        public void InsertorUpdate(InvoiceDTO invoice)
        {
            _unitOfWork.InvoiceRepo.InsertorUpdate(Map(invoice));
            _unitOfWork.Save();
        }

        public void Delete(InvoiceDTO invoice)
        {
            _unitOfWork.InvoiceRepo.Delete(Map(invoice));
            _unitOfWork.Save();
        }

        public InvoiceDTO FindById(int? id) => Map(_unitOfWork.InvoiceRepo.FindById(id));

        public void SetInvoiceInactive(int? id)
        {
            Invoice invoice = _unitOfWork.InvoiceRepo.FindById(id);
            invoice.IsActive = false;
            _unitOfWork.InvoiceRepo.InsertorUpdate(invoice);
            _unitOfWork.Save();
        }

        public bool HasDetailLines(InvoiceDTO invoice)
        {
            int amountLines = Map(invoice).DetailLines.Count;
            if (invoice.DetailLines.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public decimal GetTotalAmount(List<DetailLine> detailLines)
        //{
        //    decimal totalAmount = 0;
        //    foreach (DetailLine detailLine in detailLines)
        //    {
        //        totalAmount += detailLine.Amount * detailLine.UnitPrice;
        //    }
        //    return totalAmount;
        //}

        //public decimal GetDiscount(List<DetailLine> detailLines)
        //{
        //    decimal totalDiscount = 0;
        //    foreach (DetailLine detailLine in detailLines)
        //    {
        //        decimal percentage = detailLine.Discount / 100;
        //        totalDiscount += detailLine.UnitPrice * detailLine.Amount * percentage;
        //    }
        //    return totalDiscount;
        //}

        //public decimal GetVAT(List<DetailLine> detailLines)
        //{
        //    decimal totalVAT = 0;
        //    foreach (DetailLine detailLine in detailLines)
        //    {
        //        decimal percentage = detailLine.Discount / 100;
        //        totalVAT += detailLine.UnitPrice * detailLine.Amount * percentage;
        //    }
        //    return totalVAT;
        //}

        //public decimal GetTotalPrice(List<DetailLine> detailLines)
        //{
        //    decimal totalAmount = this.GetTotalAmount(detailLines);
        //    decimal totalDiscount = this.GetDiscount(detailLines);
        //    decimal totalVAT = this.GetVAT(detailLines);

        //    decimal total = totalAmount - totalDiscount + totalVAT;
        //    return total;
        //}

        //calculate the counter based on the month
        private  int GetCounter(DateTime date)
        {
            List<Invoice> invoices = this._unitOfWork.InvoiceRepo.All().Where(i => i.InvoiceDate.Month == date.Month).ToList();
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

        ////compare months to reset counter after each month
        //public bool HasDifferentMonth(Invoice oldInvoice, Invoice newInvoice)
        //{
        //    bool output = false;
        //    if (oldInvoice.InvoiceDate.Month != newInvoice.InvoiceDate.Month)
        //    {
        //        output = true;
        //    }
        //    return output;
        //}
    }
}
