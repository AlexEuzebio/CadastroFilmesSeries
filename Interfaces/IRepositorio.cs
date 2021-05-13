using System.Collections.Generic;

namespace CadastroFilmesSeries.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> lista(Tipo tipo);
        T retornaPorId(int id);
        void insere(T entidade);
        void exclui(int id);
        void atualiza(int id, T entidade);
        int proximoId();
    }
}