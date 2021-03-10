using AutoMapper;
using LocadoraDeCarros.Controllers.Base;
using LocadoraDeCarros.Models;
using Microsoft.AspNetCore.Mvc;
using Negocio.Models;
using Negocio.ServicoNegocio.Base;
using Negocio.ServiçoNegocio.Base;
using System.Collections.Generic;

namespace LocadoraDeCarros.Controllers
{
    public class CarroController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ICarroServico _carroServico;

        public CarroController(IMapper mapper, ICarroServico carroServico)
        {
            _mapper = mapper;
            _carroServico = carroServico;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var listaCarroVM = _mapper.Map<List<CarroViewModel>>(_carroServico.ObterListaCarros());
            return View(listaCarroVM);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            CarroViewModel carroVM = _mapper.Map<CarroViewModel>(_carroServico.ObterCarroPorID(id));
            return View(carroVM);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View(new CarroViewModel());
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarroViewModel carroVM)
        {
            try
            {

                var novoCarro = _mapper.Map<Carro>(carroVM);

                //TODO: validar regras de negocio
                if (novoCarro.MarcaEstaDuplicado(_carroServico))
                    ModelState.AddModelError("Email", "O email ja existe no banco de dados");

                if (ModelState.IsValid)
                {
                    if (_carroServico.Inserir(novoCarro))
                    {
                        Mensagem("O carro foi inserido com sucesso.", "Info");
                        return RedirectToAction(nameof(Index));
                    }
                }
                Mensagem("Ocorreu algum erro ao inserir o novo carro.", "Error");
                return View(carroVM);
            }
            catch
            {
                Mensagem("Ocorreu alguma exception ao inserir o novo carro.", "Error");
                return View(carroVM);
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var carroEditar = _mapper.Map<CarroViewModel>(_carroServico.ObterCarroPorID(id));
            return View(carroEditar);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarroViewModel carroVM)
        {
            try
            {

                var carroEditado = _mapper.Map<Carro>(carroVM);

                if (carroEditado.MarcaEstaDuplicado(_carroServico))
                    ModelState.AddModelError("Email", "O email ja existe no banco de dados");

                if (ModelState.IsValid)
                {

                    if (_carroServico.Editar(carroEditado))
                    {
                        Mensagem("O cliente foi editado com sucesso.", "Info");
                        return RedirectToAction(nameof(Index));
                    }
                }

                Mensagem("Ocorreu algum erro ao editar o cliente.", "Error");
                return View(carroVM);
            }
            catch
            {
                Mensagem("Ocorreu alguma exception ao editar o cliente.", "Error");
                return View(carroVM);
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var carroExcluir = _mapper.Map<ClienteViewModel>(_carroServico.ObterCarroPorID(id));
            return View(carroExcluir);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CarroViewModel carroExcluir)
        {
            try
            {
                if (_carroServico.Excluir(carroExcluir.id))
                {
                    Mensagem("O cliente foi excluido com sucesso.", "Info");
                    return RedirectToAction(nameof(Index));
                }

                Mensagem("Ocorreu alguma erro ao excluir o cliente.", "Error");
                return View(carroExcluir);
            }
            catch
            {
                Mensagem("Ocorreu alguma exception ao excluir o cliente.", "Error");
                return View(carroExcluir);
            }
        }
    }
}