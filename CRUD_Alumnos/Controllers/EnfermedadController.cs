using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class EnfermedadController : Controller
    {
        // GET: Enfermedad
        public ActionResult Index()
        {
            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    return View(db.enfermedad.ToList());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito Error" + ex.Message);
                return View();
            }

        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(enfermedad enfermedad)
        {
            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    int count = db.enfermedad.Count();
                    enfermedad.id = count + 1;
                    db.enfermedad.Add(enfermedad);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito Error: " + ex.Message);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    return View(db.enfermedad.Find(id));
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito Error: " + ex.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(enfermedad enfermedad)
        {
            try
            {
                using (var db = new testDataBaseEntities1()) {
                    enfermedad enfermedadInput = db.enfermedad.Find(enfermedad.id);
                    enfermedadInput.Descripción = enfermedad.Descripción;
                    enfermedadInput.Enfermedad1 = enfermedad.Enfermedad1;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            } catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito Error: " + ex.Message);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                using (var db=new testDataBaseEntities1())
                {
                    return View(db.enfermedad.Find(id));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito Error: " + ex.Message);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db=new testDataBaseEntities1())
                {                    
                    db.enfermedad.Remove(db.enfermedad.Find(id));
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito Error: " + ex.Message);
                return View();
            }
        }
    }    
}