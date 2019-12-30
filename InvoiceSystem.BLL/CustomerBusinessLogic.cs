using InvoiceSystem.DAL.Models;
using InvoiceSystem.DAL;
using System.Collections.Generic;
using System.Linq;
using InvoiceSystem.DTO;
using AutoMapper;

namespace InvoiceSystem.BLL
{
    public class CustomerBusinessLogic
    {
        private UnitOfWork _unitOfWork;

        public CustomerBusinessLogic()
        {
            _unitOfWork = new UnitOfWork();
        }

        public static Customer Map(CustomerDTO e)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDTO, Customer>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            Customer model = mapper.Map<Customer>(e);
            model.CityId = e.CityId;
            model.City = unitOfWork.CityRepo.FindById(model.CityId);
            return model;
        }

        public static CustomerDTO Map(Customer e)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            CustomerDTO dto = mapper.Map<CustomerDTO>(e);
            dto.CityId = e.CityId;
            CityBusinessLogic logic = new CityBusinessLogic();
            dto.City = logic.FindById(dto.CityId);
            return dto;
        }

        public List<CustomerDTO> GetActiveCustomers()
        {
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();
            List<Customer> customers = _unitOfWork.CustomerRepo.All().Where(c => c.IsActive == true).ToList();

            foreach (var customer in customers)
            {
                customerDTOs.Add(Map(customer));
            }
            return customerDTOs;
        }

        public void Insert(CustomerDTO customer)
        {
            _unitOfWork.CustomerRepo.Insert(Map(customer));
            _unitOfWork.Save();
        }

        public void Update(CustomerDTO customer)
        {
            _unitOfWork.CustomerRepo.Update(Map(customer));
            _unitOfWork.Save();
        }

        public void Delete(CustomerDTO customer)
        {
            _unitOfWork.CustomerRepo.Delete(Map(customer));
            _unitOfWork.Save();
        }

        public CustomerDTO FindById(int? id) => Map(_unitOfWork.CustomerRepo.FindById(id));

        public void SetInactive(int? id)
        {
            Customer customer = _unitOfWork.CustomerRepo.FindById(id);
            customer.IsActive = true;
            _unitOfWork.CustomerRepo.Update(customer);
            _unitOfWork.Save();
        }
    }
}
