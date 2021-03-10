using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.RepositorioDados
{
   public interface ICarroRepositorio
    {
        Carro ObterCarro(int id);
        Carro ObterCarroPorMarca(string marca);
        List<Carro> ObterListaCarro();
        bool Inserir(Carro novoCarro);
        bool Editar(Carro carroEditado);
        bool Excluir(int id);
    }
}
