using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVentas.Models;
using WSVentas.Models.Response;

namespace WSVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {

                // una vez que termina lo del using todo lo de adentro se elimina, en este caso la conexion a la db que es el contexto
                using (VentaHDLContext db = new VentaHDLContext())
                {
                    // Dentro del using se hacen las consultas, en este caso con Entity Framework
                    var lst = db.Cliente.ToList();

                    oRespuesta.Exito = 1;

                    oRespuesta.Data = lst;

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);

        }


    }




}


