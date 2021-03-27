using DesafioBack.DAO;
using DesafioBack.Domain.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TituloController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        //private readonly IRepository _repository;
        public TituloController(ILogger<TituloController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            //_repository = repository;
        }

        [HttpPost]
        public IActionResult Inclusao([FromBody] Titulo titulo)
        {
            if (titulo == null)
                return BadRequest();

            var Dao = new TituloDAO();
            Dao.Adiciona(titulo);

            return Accepted(titulo);
        }

        [HttpGet]
        [Route("Consulta/{id}")]
        public IActionResult ConsultaPorId(int id)
        {

            return Accepted();
        }

        [HttpGet]
        [Route("Consulta/Atrasados")]
        public IActionResult ConsultaAtrasados()
        {

            return Accepted();
        }
    }
}
