using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class JobSeekerRepo : IRepo<JobSeeker, int, bool>, IAuth<JobSeeker, bool>
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
        public Token Authenticate(JobSeeker obj)
        {
            var u = db.JobSeekers.FirstOrDefault(x => x.Id.Equals(obj.Id) && x.Pass.Equals(obj.Pass));
            Token t = null;
            if (u != null)
            {
                string token = Guid.NewGuid().ToString();
                t = new Token();
                t.UserId = obj.Id;
                t.AccessToken = token;
                t.CreatedAt = DateTime.Now;
                db.Tokens.Add(t);
                db.SaveChanges();
            }
            return t;
        }
        public bool IsAuthenticated(string token)
        {
            var result = db.Tokens.Any(e => e.AccessToken.Equals(token) && e.ExpiredAt == null);
            return result;
        }

        public bool Logout(string token)
        {
            var t = db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token));
            if (t != null)
            {
                t.ExpiredAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        
    }
}
