using AutoMapper;
using Dados.Contexts;
using Dados.Models;
using Negocio.Models;
using Negocio.RepositorioDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Dados.Repositorio
{
   

    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly IMapper _mapper;
        private readonly LocadoraDbContext _dbContext;

        public CarroRepositorio(IMapper mapper, LocadoraDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Carro ObterCarro(int id)
        {
            CarroDataModel carroDM = _dbContext.Carro.FirstOrDefault(carro => carro.Id == id);
            return _mapper.Map<Carro>(carroDM);
        }

        public Carro ObterCarroPorMarca(string marca)
        {
            CarroDataModel carroDM = _dbContext.Carro.FirstOrDefault(cliente => cliente.Marca == marca);
            return _mapper.Map<Carro>(carroDM);
        }

        public List<Carro> ObterListaCarro()
        {
            List<CarroDataModel> lstCarros = _dbContext.Carro.ToList();
            return _mapper.Map<List<Carro>>(lstCarros);
        }
        public bool Editar(Carro carroEditado)
        {
            try
            {
                var carroUpdate = _dbContext.Carro.FirstOrDefault(carro => carro.Id == carroEditado.Id);
                _mapper.Map(carroEditado, carroUpdate);
                _dbContext.Carro.Update(carroUpdate);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                var carroExcluir = _dbContext.Carro.FirstOrDefault(carro => carro.Id == id);
                _dbContext.Carro.Remove(carroExcluir);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Inserir(Carro novoCarro)
        {
            try
            {
                _dbContext.Carro.Add(_mapper.Map<CarroDataModel>(novoCarro));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
