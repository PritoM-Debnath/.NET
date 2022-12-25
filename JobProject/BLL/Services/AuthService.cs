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
    public class AuthService
    {
        static AuthService()
        {
           //            
        }
        public static TokenDTO AuthenticateJobProvider(JobProviderDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JobProviderDTO, JobProvider>();
                cfg.CreateMap<JobProvider, JobProviderDTO>();
                cfg.CreateMap<Token, TokenDTO>();
                cfg.CreateMap<TokenDTO, Token>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<JobProvider>(dto);
            var result=DataAccessFactory.JobProviderAuthDataAccess().Authenticate(data);
            var token = mapper.Map<TokenDTO>(result);
            return token;
        }
        public static bool IsAuthenticatedJobProvider(string token)
        {
            var result = DataAccessFactory.JobProviderAuthDataAccess().IsAuthenticated(token);
            return result;
        }
        public static bool LogoutProvider(string token)
        {
            return DataAccessFactory.JobProviderAuthDataAccess().Logout(token);
        }
        ///
        public static TokenDTO AuthenticateJobSeeker(JobSeekerDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JobSeekerDTO, JobSeeker>();
                cfg.CreateMap<JobSeeker, JobSeekerDTO>();
                cfg.CreateMap<Token, TokenDTO>();
                cfg.CreateMap<TokenDTO, Token>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<JobSeeker>(dto);
            var result = DataAccessFactory.JobSeekerAuthDataAccess().Authenticate(data);
            var token = mapper.Map<TokenDTO>(result);
            return token;
        }
        public static bool IsAuthenticatedJobSeeker(string token)
        {
            var result = DataAccessFactory.JobSeekerAuthDataAccess().IsAuthenticated(token);
            return result;
        }
        public static bool LogoutSeeker(string token)
        {
            return DataAccessFactory.JobSeekerAuthDataAccess().Logout(token);
        }
    }
}
