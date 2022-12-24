using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class PortfolioRepo : IRepo<Portfolio, int, Portfolio>
    {
        JOBEntities db;
        internal PortfolioRepo()
        {
            db = new JOBEntities();
        }
        public Portfolio Add(Portfolio obj)
        {
            db.Portfolios.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            db.Portfolios.Remove(db.Portfolios.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Portfolio> Get()
        {
            return db.Portfolios.ToList();
        }

        public Portfolio Get(int id)
        {
            return db.Portfolios.Find(id);
        }

        public bool Update(Portfolio obj)
        {
            var ext = db.Portfolios.Find(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
