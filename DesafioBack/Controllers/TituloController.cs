using DesafioBack.DAO;
using DesafioBack.Domain.Domains;
using DesafioBack.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        [Route("Incluir")]
        public IActionResult Inclusao([FromBody] TituloInclusao tituloInclusao)
        {
            if (tituloInclusao == null)
                return BadRequest("Forneça dados validos!");
            else if (tituloInclusao.Numero == 0)
                return BadRequest("Forneça dados validos!");
            else if (tituloInclusao.Parcelas.Count == 0)
                return BadRequest("Forneça dados validos!");

            var Dao = new TituloDAO();
            Dao.Adiciona(tituloInclusao);

            return Accepted(tituloInclusao);
        }

        [HttpGet]
        [Route("Consultar/{id}")]
        public IActionResult ConsultaPorId(int id)
        {
            if (id == 0)
                return BadRequest();

            var Dao = new TituloDAO();
            var tituloConsulta = Dao.BuscaPorId(id);

            return Ok(tituloConsulta);
        }

        [HttpGet]
        [Route("Consultar/Atrasados")]
        public IActionResult ConsultaAtrasados()
        {
            var Dao = new TituloDAO();
            var titulos = Dao.Lista();
            return Ok(titulos);
        }

        [HttpGet]
        [Route("Consultar/Dapper")]
        public IActionResult ConsultaDapper()
        {
            var Dao = new TituloDAO();
            var titulos = Dao.ListaDapper();
            return Ok(titulos);
        }
    }
}
