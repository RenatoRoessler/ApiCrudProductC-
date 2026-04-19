using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Service;

namespace MyApp.Namespace
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutosService produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            this.produtosService = produtosService;
        }


        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(produtosService.obterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = produtosService.ObterPorId(id);

            if (produto is null)
            {
                return NotFound($"Produto com o Id {id} não encontrado");
            }

            return Ok(produto);

        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Post(Produto novoProduto)
        {
            try
            {
                produtosService.Adicionar(novoProduto);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public ActionResult<Produto> Put(int id, Produto produtoAtualizado)
        {
            try
            {
                var produto = produtosService.Atualizar(id, produtoAtualizado);

                if (produto is null)
                {
                    return NotFound($"Produto com o Id {id} não encontrado");
                }

                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deletou = produtosService.Remover(id);

            if (deletou == false)
            {
                return NotFound($"Produto com o Id {id} não encontrado");
            }

            return NoContent();
        }

    }
}
