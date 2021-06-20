using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;

namespace ModelEF.DAO
{
    public class UserDao
    {
        NTNhonContext db = null;
        public UserDao()
        {
            db = new NTNhonContext();
        }
        public int Insert(UserAccount entity)
        {
            db.UserAccounts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<UserAccount> listAllPaging(string searchString, int page,int pageSize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Password.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page,pageSize);
        }
        public UserAccount GetById (string userName)
        {
            return db.UserAccounts.SingleOrDefault(x => x.UserName == userName);
        }
        public bool Login(string User,string Pass)
        {
            var result = db.UserAccounts.Count(x => x.UserName == User && x.Password == Pass);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }        
        }    
    }
}
