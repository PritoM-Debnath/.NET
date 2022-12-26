using DAL;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CountService
    {
        public static int Numcnt(){ 
        
            return DataAccessFactory.PortfolioCountDataAccess().NumberCount();
        }
        public static int NumcntJobVacancy()
        {
            return DataAccessFactory.JobVacancyCountDataAccess().NumberCount();
        }
    }
}
