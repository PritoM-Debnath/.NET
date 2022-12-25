using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class JobProviderRepo : IRepo<JobProvider, int, JobProvider>, IAuth <JobProvider, bool>
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
        public Token Authenticate(JobProvider obj)
        {
            var u = db.JobProviders.FirstOrDefault(x => x.Id.Equals(obj.Id)&& x.Pass.Equals(obj.Pass));
            Token t = null;
            if(u != null)
            {
                string token = Guid.NewGuid().ToString();
                t = new Token();
                t.UserId=obj.Id;
                t.AccessToken = token;
                t.CreatedAt = DateTime.Now;
                db.Tokens.Add(t); 
                db.SaveChanges();
            }
            return t;
        }
        public bool IsAuthenticated(string token)
        {
            var result = db.Tokens.Any(e=>e.AccessToken.Equals(token)&& e.ExpiredAt ==null);
            return result;
        }

        public bool Logout(string token)
        {
            var t = db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token));
            if(t != null)
            {
                t.ExpiredAt=DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
