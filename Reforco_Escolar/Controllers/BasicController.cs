using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reforco_Escolar.Controllers
{
    public class BasicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Servico()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View();
        }
        //public IActionResult Cadastro()
        //{
        //    return View();
        //}
        public IActionResult Sobre()
        {
            return View();
        }
    }
}

/*  Implementar as Views na pasta 'Basic':
    - Index     -> Página Inicial
    - Contato   -> Formulário de Contato padrão. Nome / E-mail / Mensagem / Contato. Validação de campos
    - Serviços  -> Implementar uma View com os tipos de serviços separados em 'Box','Grids' ou algo similar.
    - Cadastro  -> Com integração com Via CEP - Validação no front (expressão regular) e no Back (banco de dados) - Persistir no BD SQL Server e/ou no MySQL
    - Sobre     -> View com um resumo dos tipos de serviço do site
    Implementar Repositório de cadastro
*/