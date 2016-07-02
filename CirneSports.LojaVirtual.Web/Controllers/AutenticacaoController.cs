using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Dominio.Repositorio;

namespace CirneSports.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        // GET: Autenticacao
        public ActionResult Index()
        {
            return View();
        }

        public void Login()
        {
            Administrador administrador = new Administrador();
            administrador.Login = "Aluno";

            AdministradoresRepositorio repositorio = new AdministradoresRepositorio();
            var adm = repositorio.ObterAdiministrador(administrador);
        }
    }
}