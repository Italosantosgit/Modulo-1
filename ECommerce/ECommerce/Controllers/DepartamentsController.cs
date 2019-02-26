using ECommerce.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class DepartamentsController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: Departaments
        public ActionResult Index()
        {
            return View(db.Departaments.ToList());
        }

        // GET: Departaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departaments departaments = db.Departaments.Find(id);
            if (departaments == null)
            {
                return HttpNotFound();
            }
            return View(departaments);
        }

        // GET: Departaments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartamentsId,Name")] Departaments departaments)
        {
            if (ModelState.IsValid)
            {
                db.Departaments.Add(departaments);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    //VERIFICAÇÃO PARA NÃO ACEITAR 2 DEPARTAMENTOS IGUAIS
                    //VERIFICA SE A EXCEÇAO NULA A APLICAÇÃO E NO BANCO DE DADOS
                    if (ex.InnerException != null //VERIFICA QUANDO A REFERENCIA E NULA 
                        && ex.InnerException.InnerException != null //VERIFICA SE TEM UMA SEÇÃO QUE DEPENDE DA OUTRA EXCEÇÃO
                            && ex.InnerException.InnerException.Message.Contains("_Index"))
                    { //VERIFICA SE TEM A PALAVRA 'REFERENCE', ERRO DE CASCATE
                        ModelState.AddModelError(string.Empty, "NÃO É POSSIVEL INSERIR 2 DEPARTAMENTOS COM O MESMO NOME");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    return View(departaments);

                }
            }

            return View(departaments);
        }

        // GET: Departaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departaments departaments = db.Departaments.Find(id);
            if (departaments == null)
            {
                return HttpNotFound();
            }
            return View(departaments);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartamentsId,Name")] Departaments departaments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departaments).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    //VERIFICAÇÃO PARA NÃO ACEITAR 2 DEPARTAMENTOS IGUAIS
                    //VERIFICA SE A EXCEÇAO NULA A APLICAÇÃO E NO BANCO DE DADOS
                    if (ex.InnerException != null //VERIFICA QUANDO A REFERENCIA E NULA 
                        && ex.InnerException.InnerException != null //VERIFICA SE TEM UMA SEÇÃO QUE DEPENDE DA OUTRA EXCEÇÃO
                            && ex.InnerException.InnerException.Message.Contains("_Index"))
                    { //VERIFICA SE TEM A PALAVRA 'REFERENCE', ERRO DE CASCATE
                        ModelState.AddModelError(string.Empty, "NÃO É POSSIVEL ALTERAR, NOME JÁ EXISTENTE");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    
                }
            }
            return View(departaments);
        }

        // GET: Departaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departaments departaments = db.Departaments.Find(id);
            if (departaments == null)
            {
                return HttpNotFound();
            }
            return View(departaments);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departaments departaments = db.Departaments.Find(id);
            db.Departaments.Remove(departaments);
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                //VERIFICA SE A EXCEÇAO NULA A APLICAÇÃO E NO BANCO DE DADOS
                if (ex.InnerException != null //VERIFICA QUANDO A REFERENCIA E NULA 
                    && ex.InnerException.InnerException != null //VERIFICA SE TEM UMA SEÇÃO QUE DEPENDE DA OUTRA EXCEÇÃO
                        && ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                { //VERIFICA SE TEM A PALAVRA 'REFERENCE', ERRO DE CASCATE
                    ModelState.AddModelError(string.Empty, "NÃO E POSSIVEEL REMOVER O DEPARTAMENTO PORQUE EXISTE CIDADES RELACIONADAS A ELE, PRIMEIRO REMOVA A CIDADE E VOLTE A EXCLUIR O DEPARTAMENTO");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return View(departaments);
            }
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
