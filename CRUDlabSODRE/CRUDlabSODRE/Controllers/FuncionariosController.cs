
using CRUDlabSODRE.Data;
using CRUDlabSODRE.Models;
using Microsoft.AspNetCore.Mvc;


namespace CRUDlabSODRE.Controllers
{
    public class FuncionariosController : Controller
    {
        readonly private ApplicationDbContext _db;
        public FuncionariosController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SodreModel> funcionarios = _db.Sodre;
            return View(funcionarios);
        }

        public IActionResult Cadastrar() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id) 
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            SodreModel funcionario = _db.Sodre.FirstOrDefault(x => x.Id == id);
            
            
            return View(funcionario);
        }
        [HttpGet]
        public IActionResult Excluir(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            SodreModel funcionario = _db.Sodre.FirstOrDefault(x => x.Id == id);

            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Cadastrar(SodreModel funcionarios)
        {
            if (ModelState.IsValid)
            {
                
                _db.Sodre.Add(funcionarios);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }
        [HttpPost]
        public IActionResult Editar(SodreModel funcionarios)
        {
            if(ModelState.IsValid)
            {
                _db.Sodre.Update(funcionarios);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionarios);
        }

        [HttpPost]
        public IActionResult Excluir(SodreModel funcionarios) 
        {
             
            if(funcionarios == null)
            {
                return NotFound();
            }
            _db.Sodre.Remove(funcionarios);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
