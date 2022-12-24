using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class JobVacancyrepo : IRepo<JobVacancy, int, JobVacancy>
    {
        JOBEntities db;
        internal JobVacancyrepo()
        {
            db = new JOBEntities();
        }
        public JobVacancy Add(JobVacancy obj)
        {
            db.JobVacancies.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            db.JobVacancies.Remove(db.JobVacancies.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<JobVacancy> Get()
        {
            return db.JobVacancies.ToList();
        }

        public JobVacancy Get(int id)
        {
            return db.JobVacancies.Find(id);
        }

        public bool Update(JobVacancy obj)
        {
            var ext = db.JobVacancies.Find(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;

        }
    }

}
