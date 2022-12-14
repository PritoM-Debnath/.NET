using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo< JobSeeker, int, bool> JobSeekerDataAccess()
        {
            return new JobSeekerRepo();
        }
        public static IAuth<JobProvider, bool> JobProviderAuthDataAccess()
        {
            return new JobProviderRepo();
        }
        public static IAuth<JobSeeker, bool> JobSeekerAuthDataAccess()
        {
            return new JobSeekerRepo();
        }
        public static IRepo<JobProvider, int, JobProvider> JobProviderDataAccess()
        {
            return new JobProviderRepo();
        }
        public static IRepo<Portfolio , int, Portfolio> PortfolioDataAccess()
        {
            return new PortfolioRepo();
        }
        public static IRepo<JobVacancy, int, JobVacancy> JobVacancyDataAccess()
        {
            return new JobVacancyrepo();
        }
        public static ICount<int> PortfolioCountDataAccess()
        {
            return new PortfolioRepo();
        }
        public static ICount<int> JobVacancyCountDataAccess()
        {
            return new JobVacancyrepo();
        }
    }
}
