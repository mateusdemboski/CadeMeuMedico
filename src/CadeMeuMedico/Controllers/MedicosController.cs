using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {
        private CadeMeuMedicoBDContext db = new CadeMeuMedicoBDContext();

        // GET: /Medicos/
        public IActionResult Index()
        {
            var medico = db.Medicos.Include(x => x.IDCidadeNavigation).Include(x => x.IDEspecialidadeNavigation);
            return View(medico.ToList());
        }

        // GET /Medicos/Adicionar
        public IActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");

            return View();
        }

        //POST /Medicos/Adicionar
        [HttpPost]
        public IActionResult Adicionar(Medicos medico)
        {
            if(ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");

            return View(medico);

        }

        //GET /Medicos/Edit
        public IActionResult Editar(long id)
        {
            var medicof = from m in db.Medicos select m;
            medicof = medicof.Where(s => s.IDMedico == id);
            Medicos medico = medicof.First();

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);
        }

        //POST /Medicos/Editar
        [HttpPost]
        public IActionResult Editar(Medicos medico)
        {
            if(ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);
            return View(medico);
        }

        //POST /Medicos/Excluir
        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                var medicof = from m in db.Medicos select m;
                medicof = medicof.Where(s => s.IDMedico == id);
                Medicos medico = medicof.First();

                db.Medicos.Remove(medico);
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
