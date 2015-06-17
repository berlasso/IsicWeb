using System.Linq;
using System.Web.Mvc;
using ISIC.Entities;
using MPBA.DataAccess;

namespace ISICWeb.Controllers
{

    [Authorize]
    public class UsuariosController : Controller
    {
        private IRepository _repository;
        public UsuariosController(IRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult AltaModificacionUsuario(int id=0)
        {
            return View();
        }

        public bool BorrarUsuario(int id)
        {
            return false;
        }

        public ActionResult Index()
        {
            var Usuarios = _repository.Set<Usuarios>().ToList();
            return View(Usuarios);
        }
    }
}