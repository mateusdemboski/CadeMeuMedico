using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using CadeMeuMedico.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CadeMeuMedico.Controllers
{
    public class EspecialidadesController : Controller
    {
        private CadeMeuMedicoBDContext db = new CadeMeuMedicoBDContext();

        // GET: /Especialidades/
        public IActionResult Index()
        {
            var especialidades = db.Especialidades.ToList();
            return View(especialidades);
        }

        //GET /Especialidades/Adicionar
        public IActionResult Adicionar()
        {
            return View();
        }

        //POST /Especialidades/Adicionar
        [HttpPost]
        public IActionResult Adicionar(Especialidades especialidade)
        {
            if(ModelState.IsValid)
            {
                db.Especialidades.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        //GET /Especialidades/Editar
        public IActionResult Editar(long id)
        {
            var especialidadef = from c in db.Especialidades select c;
            especialidadef = especialidadef.Where(x => x.IDEspecialidade == id);
            Especialidades especialidade = especialidadef.First();

            return View(especialidade);
        }

        //POST /Especialidades/Editar
        [HttpPost]
        public IActionResult Editar(Especialidades especialidade)
        {
            if(ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        //POST /Especialidades/Excluir
        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                var especialidadef = from c in db.Especialidades select c;
                especialidadef = especialidadef.Where(x => x.IDEspecialidade == id);
                Especialidades especialidade = especialidadef.First();

                db.Especialidades.Remove(especialidade);
                db.SaveChanges();
                return Boolean.TrueString;

            }
            catch
            {
                return Boolean.FalseString;
            }

        }
    }
}
