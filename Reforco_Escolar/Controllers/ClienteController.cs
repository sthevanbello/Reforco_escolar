using Microsoft.AspNetCore.Authorization;
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


        [Authorize]
        public IActionResult Cadastro()
        {

            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Lista()
        {
            var clientes = await _clienteRepository.GetClientesAsync();

            List<ClienteViewModel> clienteViews = new List<ClienteViewModel>();

            foreach (var cliente in clientes)
            {
                clienteViews.Add(new ClienteViewModel(cliente));
            }
            return View(clienteViews);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Resumo(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteRepository.IncluirClienteAsync(cliente);

                ClienteViewModel clienteViewModel = new ClienteViewModel(cliente);

                return View(clienteViewModel);
            }
            return RedirectToAction("Cadastro");

        }

        [Authorize]
        public async Task<IActionResult> Deletar(int id)
        {
            var cliente = await _clienteRepository.GetClienteUnicoAsync(id);

            ClienteViewModel clienteViewModel = new ClienteViewModel(cliente);
            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Deletar(int id, Cliente cliente)
        {
            try
            {
                await _clienteRepository.DeletarClienteAsync(id);
                return RedirectToAction(nameof(Lista));
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível deletar o cliente");
            }

        }

        [Authorize]
        public async Task<IActionResult> Editar(int id)
        {
            var cliente = await _clienteRepository.GetClienteUnicoAsync(id);


            ClienteViewModel clienteViewModel = new ClienteViewModel(cliente);

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Editar(int id, Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _clienteRepository.UpdateCadastroAsync(id, cliente);
                    return RedirectToAction(nameof(Lista));
                }
                return RedirectToAction("Cadastro");
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível editar o cliente");
            }

        }
        [Authorize]
        public async Task<IActionResult> Detalhes(int id)
        {
            var clienteAsync = await _clienteRepository.GetClientesAsync();

            var cliente = clienteAsync.FirstOrDefault(c => c.Id == id);

            ClienteViewModel clienteView = new ClienteViewModel(cliente);

            return View(clienteView);
        }

    }
}
