using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class JobSeekerRepo : IRepo<JobSeeker, int, bool>, IAuth
    {
        JOBEntities db;
        internal JobSeekerRepo()
        {
            db = new JOBEntities();
        }
        public bool Add(JobSeeker obj)
        {
            db.JobSeekers.Add(obj);
            return db.SaveChanges() > 0;
        }
        public JobSeeker Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            db.JobSeekers.Remove(db.JobSeekers.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<JobSeeker> Get()
        {
            return db.JobSeekers.ToList();
        }

        public JobSeeker Get(int id)
        {
            return db.JobSeekers.Find(id);
        }

        public bool Update(JobSeeker obj)
        {
            var ext = db.JobSeekers.Find(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
