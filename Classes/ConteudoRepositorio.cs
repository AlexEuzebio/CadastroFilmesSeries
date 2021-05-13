using System.Collections.Generic;
using CadastroFilmesSeries.Interfaces;

namespace CadastroFilmesSeries
{
    public class ConteudoRepositorio : IRepositorio<Conteudo>
    {
        private List<Conteudo> listaConteudo = new List<Conteudo>();
        public void atualiza(int id, Conteudo objeto)
        {
            listaConteudo[id] = objeto;
        }

        public void exclui(int id)
        {
            listaConteudo[id].excluir();
        }

        public void insere(Conteudo objeto)
        {
            listaConteudo.Add(objeto);
        }

        public List<Conteudo> lista(Tipo tipo)
        {
            var listaRetorno = new List<Conteudo>();
            foreach (var conteudo in listaConteudo)
            {
                if ( tipo == Tipo.Generico || tipo == conteudo.retornaTipo())
                {
                    listaRetorno.Add(conteudo);
                }
            }
            return listaRetorno;
        }

        public int proximoId()
        {
            return listaConteudo.Count;
        }

        public Conteudo retornaPorId(int id)
        {
            return listaConteudo[id];
        }
    }
}