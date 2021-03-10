using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.ServiçoNegocio.Base
{
   public interface ICarroServico
    {
        Carro ObterCarroPorMarca(string marca);

        Carro ObterCarroPorID(int id);

        List<Carro> ObterListaCarros();
        bool Inserir(Carro novoCarro);
        bool Editar(Carro carroEditado);
        bool Excluir(int id);
    }
}
