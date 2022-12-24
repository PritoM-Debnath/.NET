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
    public class JobVacancyService
    {
        public static List<JobVacancyDTO> GetJobVacancys()
        {
            var dto = DataAccessFactory.JobVacancyDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobVacancy, JobVacancyDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<JobVacancyDTO>>(dto);
            return data;
        }
        public static JobVacancyDTO Get(int id)
        {
            var data = DataAccessFactory.JobVacancyDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobVacancy, JobVacancyDTO>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<JobVacancyDTO>(data);
            return dto;
        }
        public static JobVacancyDTO Add(JobVacancyDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JobVacancyDTO, JobVacancy>();
                cfg.CreateMap<JobVacancy, JobVacancyDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<JobVacancy>(dto);
            var result = DataAccessFactory.JobVacancyDataAccess().Add(data);
            return mapper.Map<JobVacancyDTO>(result);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.JobVacancyDataAccess().Delete(id);
        }
        public static bool Update(JobVacancyDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JobVacancyDTO, JobVacancy>();
                cfg.CreateMap<JobVacancy, JobVacancyDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<JobVacancy>(dto);
            var result = DataAccessFactory.JobVacancyDataAccess().Update(data);
            return (result);
        }
    }
}
