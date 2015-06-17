using System.Linq;
using System.Web.Mvc;
using MPBA.DataAccess;

namespace ISICWeb.Areas.Usuarios.Controllers
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
            var Usuarios = _repository.Set<ISIC.Entities.Usuarios>().ToList();
            return View(Usuarios);
        }
    }
}