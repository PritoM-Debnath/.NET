using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CountRepo : ICount<int>
    {
        JOBEntities db;
        public CountRepo()
        {
            db = new JOBEntities();
        }
        public int NumberCount()
        {
            var count = db.Portfolios.Count();
            return count;
        }
    }
}
