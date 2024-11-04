using WebApplication1.Contracts;
using WebApplication1.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : Controller
    {
        private readonly ICadastro _CadastroContract;

        public CadastroController(ICadastro CadastroContract)
        {
            _CadastroContract = CadastroContract;
        }

        [HttpGet("/GetAllPessoa")]
        public ActionResult GetPessoas()
        {
            var pessoas = _CadastroContract.GetPessoas();
            return Json(pessoas);
        }

        [HttpGet("/GetAllEndereco")]
        public ActionResult GetEnderecos()
        {
            var enderecos = _CadastroContract.GetEnderecos();
            return Json(enderecos);
        }

        [HttpGet("/GetPessoaById/{id}")]
        public ActionResult SearchById(int id)
        {
            var pessoa = _CadastroContract.SearchById(id);
            return Json(pessoa);
        }

        [HttpGet("/GetEnderecoByPessoaId/{id}")]
        public ActionResult SearchByPessoaId(int id)
        {
            var endereco = _CadastroContract.SearchByPessoaId(id);
            return Json(endereco);
        }

        [HttpPost("/CreatePessoa/")]
        public ActionResult<Pessoa> CreatePessoa(Pessoa pessoa)
        {
            return Json(_CadastroContract.CreatePessoa(pessoa));
        }

        [HttpPost("/CreateEndereco/{idPessoa}")]
        public ActionResult<Endereco> CreateEndereco(Endereco endereco, int idPessoa)
        {
            return Json(_CadastroContract.CreateEndereco(endereco, idPessoa));
        }

        [HttpPut("/UpdatePessoa/{id}")]
        public ActionResult<Pessoa> UpdatePessoa(int id, Pessoa pessoa)
        {
            return Json(_CadastroContract.UpdatePessoa(id, pessoa));
        }

        [HttpPut("/UpdateEnderecoById/{id}")]
        public ActionResult<Endereco> UpdateEndereco(int id, Endereco endereco)
        {
            return Json(_CadastroContract.UpdateEndereco(id, endereco));
        }

        [HttpDelete("/DeletePessoa/{id}")]
        public ActionResult<Pessoa> DeletePessoa(int id)
        {
            _CadastroContract.DeletePessoa(id);
            return Ok();
        }

        [HttpDelete("/DeleteEnderecoByPessoaId/{idPessoa},{idEndereco}")]
        public ActionResult<Endereco> DeleteEndereco(int idPessoa, int idEndereco)
        {
            _CadastroContract.DeleteEnderecoByPessoaId(idPessoa, idEndereco);
            return Ok();
        }

        [HttpDelete("/DeleteAllEndereco/{idPessoa}")]
        public ActionResult<Endereco> DeleteAllEndereco(int idPessoa)
        {
            _CadastroContract.DeleteAllEndereco(idPessoa);
            return Ok();
        }
    }
}