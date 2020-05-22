using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//conexion
using System.Data.SqlClient;
//clases.net
using System.Data;
//base helper
using MVCLaboratorio.Utilerias;

namespace MVCLaboratorio.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            ViewData["Video"] = BaseHelper.ejecutarConsulta("SP_video_Consultar", CommandType.StoredProcedure);
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int idVideo, string titulo,
                                    int repro, string url)
        {
            //guardar los datos
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idVideo",idVideo));
            parametros.Add(new SqlParameter("@titulo",titulo));
            parametros.Add(new SqlParameter("@repro",repro));
            parametros.Add(new SqlParameter("@url",url));

            BaseHelper.ejecutarSentencia("sp_video_insertar",
                                     CommandType.StoredProcedure,
                                     parametros);
            return RedirectToAction("Index", "Video");
        }
        
        //Actualizar
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string titulo, int repro, string url, int idVideo)
        {
            //Actualizar Datos
            string sentencia = "SP_video_ACTUALIZAR";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@repro", repro));
            parametros.Add(new SqlParameter("@url", url));
            parametros.Add(new SqlParameter("@idVideo", idVideo));
            BaseHelper.ejecutarSentencia(sentencia, CommandType.StoredProcedure, parametros);
            return RedirectToAction("Index", "Video");
        }

        //Eliminar
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int idVideo)
        {
            //eliminar datos
            List<SqlParameter> parametro = new List<SqlParameter>();
            parametro.Add(new SqlParameter("@idVideo", idVideo));

            BaseHelper.ejecutarSentencia("SP_video_ELIMINAR", CommandType.StoredProcedure, parametro);

            return RedirectToAction("Index", "Video");
        }
    }
}
