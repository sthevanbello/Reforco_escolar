﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Lista()
        {
            return View();
        }
    }
}
