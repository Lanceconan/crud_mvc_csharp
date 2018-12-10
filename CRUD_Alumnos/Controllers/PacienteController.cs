using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Alumnos.Models;


namespace CRUD_Alumnos.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
        {
            testDataBaseEntities1 db = new testDataBaseEntities1();


            //List<paciente> lista = db.paciente.Where(a => a.nombre != null).toList();
            return View(db.paciente.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(paciente paciente)
        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    int count = db.paciente.Count();
                    paciente.id = count + 1;
                    paciente.altura = new Decimal(0.00);
                    paciente.peso = new Decimal(0.00);
                    db.paciente.Add(paciente);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar Alumno: " + ex.Message);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    paciente pacienteEditar = db.paciente.Find(id);
                    return View(pacienteEditar);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un error puntual: " + ex.Message);
                return View();
            }
        }


        [HttpPost]
        public ActionResult Edit(paciente paciente)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new testDataBaseEntities1())
                {

                    paciente pacienteEditar = db.paciente.Find(paciente.id);

                    pacienteEditar.altura = new decimal(0.00);
                    pacienteEditar.peso = new decimal(0.00);
                    pacienteEditar.nombre = paciente.nombre;
                    pacienteEditar.apellido = paciente.apellido;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un error puntual: " + ex.Message);
                return View();

            }
        }


        public ActionResult Details(int id)
        {

            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    var pacienteVista = db.paciente.Find(id);
                    return View(pacienteVista);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha ocurrido un maldito error" + ex.Message);
                return View();
            }            
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new testDataBaseEntities1())
                {
                    db.paciente.Remove(db.paciente.Find(id));
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


    }
}