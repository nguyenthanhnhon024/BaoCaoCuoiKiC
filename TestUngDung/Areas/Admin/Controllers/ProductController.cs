using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(int page=1,int pageSize=5)
        {
            var dao = new ProductDao();
            var model = dao.ListAllProduct(page, pageSize);
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var pro = new ProductDao().FindProduct(id);
            return View(pro);
        }
        public ActionResult Create(Product product)
        {
            setViewBag();
            if (ModelState.IsValid)
            {
                
                var dao = new ProductDao();
                long id = dao.InsertPro(product);
                if (id > 0)
                {
                    return RedirectToAction("Create", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            return View("Create");
        }
        public void setViewBag(int? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.ID_Category = new SelectList (dao.ListAll(), "ID", "Name", selectedId);
        }


    }
}