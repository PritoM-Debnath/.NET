using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : IRepo<Token, int, Token>
    {
        JOBEntities db;
        internal TokenRepo()
        {
            db = new JOBEntities();
        }
        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            db.Tokens.Remove(db.Tokens.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(int id)
        {
            return db.Tokens.Find(id);
        }

        public bool Update(Token obj)
        {
            var ext = db.Tokens.Find(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return (db.SaveChanges() > 0);
        }
    }
}
