using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public ClienteController(IClienteRepository clienteRepository, UserManager<IdentityUser> userManager)
        {
            _clienteRepository = clienteRepository;
            _userManager = userManager;
        }


        [Authorize]
        public async Task<IActionResult> Cadastro()
        {
            var clientes = await _clienteRepository.GetClientesAsync();

            var usuario = await _userManager.GetUserAsync(this.User);

            var cliente = clientes.SingleOrDefault(c => c.Email == usuario.Email);

            if (cliente != null)
            {
                return View(cliente);
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Lista()
        {
            var clientes = await _clienteRepository.GetClientesAsync();

            IList<ClienteViewModel> clienteViews = new List<ClienteViewModel>();

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
            var clienteDb = await _clienteRepository.GetClientesAsync();
            var clienteUnico = clienteDb.SingleOrDefault(c => c.Email == cliente.Email);

            if (ModelState.IsValid)
            {
                if (clienteUnico != null)
                {
                    return RedirectToAction(nameof(Detalhes), new { id = clienteUnico.Id });
                }
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
                return RedirectToAction(nameof(Cadastro));
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

            var cliente = clienteAsync.SingleOrDefault(c => c.Id == id);

            ClienteViewModel clienteView = new ClienteViewModel(cliente);

            return View(clienteView);
        }

    }
}
