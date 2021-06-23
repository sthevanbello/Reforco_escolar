using Microsoft.AspNetCore.Mvc;
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
    }
}
