using AutoMapper;
using InvoiceSystem.DAL;
using InvoiceSystem.DAL.Models;
using InvoiceSystem.DAL.Repositories;
using InvoiceSystem.DTO;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.BLL
{
    public class DetailLineBusinessLogic
    {
        private UnitOfWork _unitOfWork;

        public DetailLineBusinessLogic()
        {
            _unitOfWork = new UnitOfWork();
        }

        public static DetailLine Map(DetailLineDTO e)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DetailLineDTO, DetailLine>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            DetailLine model = mapper.Map<DetailLine>(e);
            return model;
        }

        public static DetailLineDTO Map(DetailLine e)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DetailLine, DetailLineDTO>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            DetailLineDTO dto = mapper.Map<DetailLineDTO>(e);
            return dto;
        }

        public List<DetailLineDTO> GetAll()
        {
            List<DetailLineDTO> detailLineDTOs = new List<DetailLineDTO>();
            List<DetailLine> detailLines = _unitOfWork.DetailLineRepo.All();

            foreach (var detail in detailLines)
            {
                detailLineDTOs.Add(Map(detail));
            }

            return detailLineDTOs;
        }

        public void InsertOrUpdate(DetailLineDTO detailLine)
        {
            _unitOfWork.DetailLineRepo.InsertorUpdate(Map(detailLine));
            _unitOfWork.Save();
        }

        public void Delete(DetailLineDTO detailLine)
        {
            _unitOfWork.DetailLineRepo.Delete(Map(detailLine));
            _unitOfWork.Save();
        }

        public DetailLineDTO FindById(int? id) => Map(_unitOfWork.DetailLineRepo.FindById(id));    
    }
}
