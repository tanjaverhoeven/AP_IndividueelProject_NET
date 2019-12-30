using AutoMapper;
using InvoiceSystem.DAL;
using InvoiceSystem.DAL.Models;
using InvoiceSystem.DTO;
using System.Collections.Generic;

namespace InvoiceSystem.BLL
{
    public class CityBusinessLogic
    {
        private UnitOfWork _unitOfWork;

        public CityBusinessLogic()
        {
            _unitOfWork = new UnitOfWork();
        }

        public static City Map(CityDTO e)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, City>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            City model = mapper.Map<City>(e);
            return model;
        }

        public static CityDTO Map(City e)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<City, CityDTO>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            CityDTO dto = mapper.Map<CityDTO>(e);
            return dto;
        }

        public List<CityDTO> GetAll()
        {
            List<CityDTO> cityDTOs = new List<CityDTO>();
            List<City> cities = _unitOfWork.CityRepo.All();

            foreach (var city in cities)
            {
                cityDTOs.Add(Map(city));
            }

            return cityDTOs;
        }

        public void Update(CityDTO t)
        {
            _unitOfWork.CityRepo.Update(Map(t));
            _unitOfWork.Save();
        }

        public void InsertorUpdate(CityDTO t)
        {
            _unitOfWork.CityRepo.Insert(Map(t));
            _unitOfWork.Save();
        }

        public void Delete(CityDTO t)
        {        
            _unitOfWork.CityRepo.Delete(Map(t));
            _unitOfWork.Save();
        }

        public CityDTO FindById(int? id) => Map(_unitOfWork.CityRepo.FindById(id));
    }
}
