using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Alumnos.Models;

namespace CRUD_Alumnos.Controllers
{
    public class PacienteEnfermedadController : Controller
    {
        // GET: PacienteEnfermedad
        public ActionResult Index()
        {
            try
            {
                using (var db=new testDataBaseEntities1())
                {
                    var pacienteEnfermedad = db.pacienteEnfermedad.ToList();                    

                    foreach(pacienteEnfermedad item in pacienteEnfermedad)
                    {
                        item.NombreCompleto = db.paciente.Find(item.idPaciente).NombreCompleto;
                        item.NombreEnfermedad = db.enfermedad.Find(item.idEnfermedad).Enfermedad1;
                    }

                    return View(pacienteEnfermedad);
                }
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",  "Ha ocurrido un maldito error" + ex.Message);
                return View();
            }

            
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db=new testDataBaseEntities1())
                {
                    db.pacienteEnfermedad.Remove(db.pacienteEnfermedad.Find(id));
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito error" + ex.Message);
                return View();
            }
        }


        public ActionResult Create()
        {
            try
            {

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito error" + ex.Message);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(pacienteEnfermedad pacienteEnfermedad)
        {
            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    int count = db.pacienteEnfermedad.Count();
                    pacienteEnfermedad.id = count + 1;
                    db.pacienteEnfermedad.Add(pacienteEnfermedad);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                    
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito error" + ex.Message);
                return View();
            }
        }

        public ActionResult ListaPacientes()
        {
            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    return PartialView(db.paciente.ToList());

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito error" + ex.Message);
                return View();
            }
        }

        public ActionResult ListaEnfermedad()
        {
            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    return PartialView(db.enfermedad.ToList());
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito error" + ex.Message);
                return View();
            }
        }

        public ActionResult CreatePaciente()
        {            
            return RedirectToAction("Create", "Paciente");
        }

        public ActionResult CreateEnfermedad()
        {
            return RedirectToAction("Create", "Enfermedad");
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db= new testDataBaseEntities1())
                {
                    return View(db.pacienteEnfermedad.Find(id));
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito error" + ex.Message);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(pacienteEnfermedad pacienteEnfermedad)
        {
            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito error" + ex.Message);
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    pacienteEnfermedad pacienteEnfermedad = db.pacienteEnfermedad.Find(id);
                    pacienteEnfermedad.NombreCompleto = db.paciente.Find(pacienteEnfermedad.idPaciente).NombreCompleto;
                    pacienteEnfermedad.NombreEnfermedad = db.enfermedad.Find(pacienteEnfermedad.idEnfermedad).Enfermedad1;
                    return View(pacienteEnfermedad);
                }                
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito error" + ex.Message);
                return View();
            }
        }
    }
}