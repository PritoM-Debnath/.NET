using AutoMapper;
using BLL.DTO;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PortfolioService
    {
        public static List<PortfolioDTO> GetPortfolios()
        {
            var dto = DataAccessFactory.PortfolioDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Portfolio, PortfolioDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<PortfolioDTO>>(dto);
            return data;
        }
        public static PortfolioDTO Get(int id)
        {
            var data = DataAccessFactory.PortfolioDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Portfolio, PortfolioDTO>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<PortfolioDTO>(data);
            return dto;
        }
        public static PortfolioDTO Add(PortfolioDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PortfolioDTO, Portfolio>();
                cfg.CreateMap<Portfolio, PortfolioDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Portfolio>(dto);
            var result = DataAccessFactory.PortfolioDataAccess().Add(data);
            return mapper.Map<PortfolioDTO>(result);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.JobProviderDataAccess().Delete(id);
        }
        public static bool Update(PortfolioDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PortfolioDTO, Portfolio>();
                cfg.CreateMap<Portfolio, PortfolioDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Portfolio>(dto);
            var result = DataAccessFactory.PortfolioDataAccess().Update(data);
            return (result);
        }
    }
}
