using Microsoft.AspNetCore.Mvc;
using Reforco_Escolar.Models;
using Reforco_Escolar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reforco_Escolar.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Cadastro()
        {

            return View();
        }

        public IActionResult Lista()
        {
            var clientes = _clienteRepository.GetClientes();

            return View(clientes);
        }

        //[HttpPost]
        //public IActionResult Resumo(Cliente cliente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return View( _clienteRepository.UpdateCadastro(cliente));
        //    }
        //    return RedirectToAction("Cadastro");

        //}

        public IActionResult Deletar(int id)
        {
            var cliente = _clienteRepository.GetClienteUnico(id);

            ClienteViewModel clienteViewModel = new ClienteViewModel(cliente);
            return View(clienteViewModel);
        }
        [HttpPost]
        public IActionResult Deletar(int id, Cliente cliente)
        {
            try
            {
                _clienteRepository.DeletarCliente(id);
                return RedirectToAction(nameof(Lista));
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível deletar o cliente");
            }

        }


        public IActionResult Editar(int id)
        {
            var cliente = _clienteRepository.GetClienteUnico(id);


            ClienteViewModel clienteViewModel = new ClienteViewModel(cliente);

            return View(clienteViewModel);
        }

        [HttpPost]
        public IActionResult Editar(int id, Cliente cliente)
        {
            try
            {

                _clienteRepository.UpdateCadastro(id, cliente);
                return RedirectToAction(nameof(Lista));
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível editar o cliente");
            }

        }


    }
}
