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
    public class JobSeekerService
    {
        public static List<JobSeekerDTO> GetJobSeekers() 
        {
            var dto = DataAccessFactory.JobSeekerDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobSeeker, JobSeekerDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<JobSeekerDTO>>(dto);
            return data;
        }
        public static JobSeekerDTO Get(int id)
        {
            var data = DataAccessFactory.JobSeekerDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobSeeker, JobSeekerDTO>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<JobSeekerDTO>(data);
            return dto;
        }
        public static bool Add(JobSeekerDTO dto) // return bool
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JobSeekerDTO, JobSeeker>();
                cfg.CreateMap<JobSeeker, JobSeekerDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<JobSeeker>(dto);
            var result = DataAccessFactory.JobSeekerDataAccess().Add(data);
            return result;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.JobSeekerDataAccess().Delete(id);
        }
        public static bool Update(JobSeekerDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<JobSeekerDTO, JobSeeker>());
            var mapper = new Mapper(config);
            var data = mapper.Map<JobSeeker>(dto);
            var result = DataAccessFactory.JobSeekerDataAccess().Update(data);
            return (result);
        }
    }
}

