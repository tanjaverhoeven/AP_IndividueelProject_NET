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
        private DetailLineBusinessLogic _detailLogic;

        public InvoiceBusinessLogic()
        {
            _unitOfWork = new UnitOfWork();
            _detailLogic = new DetailLineBusinessLogic();
        }

        public static Invoice Map(InvoiceDTO e)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InvoiceDTO, Invoice>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            Invoice model = mapper.Map<Invoice>(e);
            model.CustumorId = e.CustumorId;
            model.Customer = unitOfWork.CustomerRepo.FindById(model.CustumorId);
            return model;
        }

        public static InvoiceDTO Map(Invoice e)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Invoice, InvoiceDTO>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            InvoiceDTO dto = mapper.Map<InvoiceDTO>(e);
            CustomerBusinessLogic customerLogic = new CustomerBusinessLogic();
            dto.CustumorId = e.CustumorId;
            dto.Customer = customerLogic.FindById(dto.CustumorId);
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

        public void Update(InvoiceDTO invoice)
        {
            _unitOfWork.InvoiceRepo.Update(Map(invoice));
            _unitOfWork.Save();
        }

        public void Insert(InvoiceDTO invoice)
        {           
            invoice.IsActive = true;
            invoice.State = false;
            invoice.Code = GetCode(invoice.InvoiceDate);
            _unitOfWork.InvoiceRepo.Insert(Map(invoice));
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
            _unitOfWork.InvoiceRepo.Update(invoice);
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

        public decimal GetTotalAmountExcl(InvoiceDTO invoice)
        {
            decimal totalPriceExcl = 0;
            List<DetailLineDTO> details = _detailLogic.GetAll().Where(i => i.InvoiceId == invoice.Id).ToList();
            foreach (var detail in details)
            {
                totalPriceExcl += _detailLogic.GetTotalPriceExcl(detail);
            }

            return totalPriceExcl;
        }

        public decimal GetTotalAmountIncl(InvoiceDTO invoice)
        {
            decimal totalPriceIncl = 0;
            List<DetailLineDTO> details = _detailLogic.GetAll().Where(i => i.InvoiceId == invoice.Id).ToList();
            foreach (var detail in details)
            {
                totalPriceIncl += _detailLogic.GetTotalPriceIncl(detail);
            }

            return totalPriceIncl;
        }

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
                return invoices.Max(i => int.Parse(i.Code.Split('-')[1]));
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

        public int GetDetaillinesCount(InvoiceDTO invoice)
        {
            int counter = 0;
            List<DetailLineDTO> detailLineDTOs = _detailLogic.GetAll();
            foreach (var item in detailLineDTOs)
            {
                if (item.InvoiceId == invoice.Id)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
