using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tienda_compu.DAL;



namespace Tienda_compu.Models
{
    public class ProductoesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Productoes
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria);
            return View(producto.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Nombre");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create([Bind(Include = "Id,Nombre,Marca,Ram,Almacenamiento,Peso,Precio,Color,Teclado,TipoPantalla,CategoriaId")] Producto producto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {


                if (upload != null && upload.ContentLength > 0)
                {
                    string pic = System.IO.Path.GetFileName(upload.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images"), pic);

                    upload.SaveAs(path);
                    var photo = new Image
                    {
                        ImageName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Photo

                    };

                    producto.Images = new List<Image>();
                    producto.Images.Add(photo);

                }
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Nombre", producto.CategoriaId);
            return View(producto);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Marca,Ram,Almacenamiento,Peso,Precio,Color,Teclado,TipoPantalla,CategoriaId")] Producto product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    string pic = System.IO.Path.GetFileName(upload.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/Images"), pic);

                    upload.SaveAs(path);
                    var photo = new Image
                    {
                        ImageName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Photo

                    };
                    product.Images = new List<Image>();
                    product.Images.Add(photo);
                }

                
                db.Producto.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Name", product.CategoriaId);
            return View(product);
        }








        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Nombre", producto.CategoriaId);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Marca,Ram,Almacenamiento,Peso,Precio,Color,Teclado,TipoPantalla,CategoriaId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Nombre", producto.CategoriaId);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
