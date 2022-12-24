using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JobProviderService
    {
        public static List<JobProviderDTO> GetJobProviders()
        {
            var dto = DataAccessFactory.JobProviderDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobProvider, JobProviderDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<JobProviderDTO>>(dto);
            return data;
        }
        public static JobProviderDTO Get(int id)
        {
            var data = DataAccessFactory.JobProviderDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobProvider, JobProviderDTO>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<JobProviderDTO>(data);
            return dto;
        }
        public static JobProviderDTO Add(JobProviderDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JobProviderDTO, JobProvider>();
                cfg.CreateMap<JobProvider, JobProviderDTO>();
                });
            var mapper = new Mapper(config);
            var data = mapper.Map<JobProvider>(dto);
            var result = DataAccessFactory.JobProviderDataAccess().Add(data);
            return mapper.Map<JobProviderDTO>(result);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.JobProviderDataAccess().Delete(id);
        }
        public static bool Update(JobProviderDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JobProviderDTO, JobProvider>();
                cfg.CreateMap<JobProvider, JobProviderDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<JobProvider>(dto);
            var result = DataAccessFactory.JobProviderDataAccess().Update(data);
            return result;
        }
    }
}
