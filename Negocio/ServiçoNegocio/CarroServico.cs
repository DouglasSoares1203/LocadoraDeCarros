using Negocio.Models;
using Negocio.RepositorioDados;
using Negocio.ServiçoNegocio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.ServiçoNegocio
{
    public class CarroServico : ICarroServico
    {

        private readonly ICarroRepositorio _carroRepositorio;



        public CarroServico(ICarroRepositorio carroRepositorio)
        {
            _carroRepositorio = carroRepositorio;
        }

        public Carro ObterCarroPorMarca(string marca)
        {
            return _carroRepositorio.ObterCarroPorMarca(marca);
        }

        public Carro ObterCarroPorID(int id)
        {
            return _carroRepositorio.ObterCarro(id);
        }

       
        public List<Carro> ObterListaCarros()
        {
            return _carroRepositorio.ObterListaCarro();
        }

        public bool Editar(Carro carroEditado)
        {
            return _carroRepositorio.Editar(carroEditado);
        }

        public bool Excluir(int id)
        {
            return _carroRepositorio.Excluir(id);
        }

        public bool Inserir(Carro novoCarro)
        {
            return _carroRepositorio.Inserir(novoCarro);
        }

        
    }
}
