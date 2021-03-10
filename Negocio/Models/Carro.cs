
using Negocio.ServiçoNegocio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models
{
    public class Carro
    {
        public int Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Ano { get; private set; }
        public string Cor { get; private set; }
        public string Foto { get; private set; }
        public int CategoriaCarroId { get; set; }

        public Carro()
        {

        }

        public Carro(int id, string marca, string modelo, string ano, string cor, string foto, int categoriaCarroId)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
            Foto = foto;
            CategoriaCarroId = categoriaCarroId;
        }

        public bool MarcaEstaDuplicado(ICarroServico carroServico)
        {
            var carroMarca = carroServico.ObterCarroPorMarca(this.Marca);
            if (carroMarca != null)
            {
                if (carroMarca.Id != this.Id)
                    return true;
            }
            return false;
        }
    }
}
