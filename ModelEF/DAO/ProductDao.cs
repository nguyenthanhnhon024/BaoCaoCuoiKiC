using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        NTNhonContext db = null;
        public ProductDao()
        {
            db = new NTNhonContext();
        }
        public IEnumerable<Product> ListAllProduct(int page, int pageSize)
        {
            return db.Products.OrderByDescending(x => x.Quantity).ThenBy(y => y.UnitCost).ToPagedList(page, pageSize);
        }

        public long InsertPro(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Product FindProduct(int? id)
        {

            return db.Products.Find(id);
        }

        public List<Product> ListProduct(int top)
        {
            return db.Products.Take(top).ToList();
        }
    }
}
