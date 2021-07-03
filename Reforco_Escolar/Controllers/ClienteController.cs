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

        //[ValidateAntiForgeryToken]
        public IActionResult Lista()
        {
            var clientes = _clienteRepository.GetClientes();

            return View(clientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Resumo(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.IncluirCliente(cliente);

                ClienteViewModel clienteViewModel = new ClienteViewModel(cliente);

                return View(clienteViewModel);
            }
            return RedirectToAction("Cadastro");

        }

        
        public IActionResult Deletar(int id)
        {
            var cliente = _clienteRepository.GetClienteUnico(id);

            ClienteViewModel clienteViewModel = new ClienteViewModel(cliente);
            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepository.UpdateCadastro(id, cliente);
                    return RedirectToAction(nameof(Lista));
                }
                return RedirectToAction("Cadastro");
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível editar o cliente");
            }

        }

        public IActionResult Detalhes(int id)
        {
            var cliente = _clienteRepository.GetClientes().Where(c => c.Id == id).SingleOrDefault();
            ClienteViewModel clienteView = new ClienteViewModel(cliente);

            return View(clienteView);
        }

    }
}
