using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class JobProviderRepo : IRepo<JobProvider, int, JobProvider>
    {
        JOBEntities db;
        internal JobProviderRepo()
        {
            db = new JOBEntities();
        }
        public JobProvider Add(JobProvider obj)
        {
            db.JobProviders.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            db.JobProviders.Remove(db.JobProviders.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<JobProvider> Get()
        {
            return db.JobProviders.ToList();
        }

        public JobProvider Get(int id)
        {
            return db.JobProviders.Find(id);
        }
        public bool Update(JobProvider obj)
        {
            var ext = db.JobProviders.Find(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return (db.SaveChanges() > 0);
        }

    }
}
