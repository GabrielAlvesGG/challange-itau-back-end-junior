using desafio_itau.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace desafio_itau.ControllerApi
{
    
    [ApiController]
    public class TransacaoController : Controller
    {
        [DisableCors]
        [HttpPost("transacao")]
        public IActionResult transacao([FromBody] TransacaoModels transacao)
        {
            if (transacao.valor == null || transacao.dataHora == null || transacao.dataHora == DateTime.MinValue)
                return BadRequest("É necessário que os campos 'valor' e 'dataHora' venham preenchidos.");

            if (transacao.dataHora > DateTime.Now)
                return UnprocessableEntity("Não coloque transações no futuro só nomomento atual ou menor.");

            if(transacao.valor < 0)
                return UnprocessableEntity("O valor da transação atribuido tem que ser positivo.");

            return Created();
        }
    }
}
