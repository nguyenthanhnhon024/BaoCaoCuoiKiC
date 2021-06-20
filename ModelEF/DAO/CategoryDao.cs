using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        NTNhonContext db = null;
        public CategoryDao()
        {
            db = new NTNhonContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
    }
}
