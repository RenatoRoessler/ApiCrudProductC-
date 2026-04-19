using System;
using MyApp.Model;

namespace MyApp.Service;

public interface IProdutosService
{
    private static List<Produto> produtos = new List<Produto>();
    public List<Produto> obterTodos();
    public Produto ObterPorId(int id);
    public void Adicionar(Produto novoProduto);
    public Produto Atualizar(int id, Produto produtoAtualizado);
    public bool Remover(int id);
}