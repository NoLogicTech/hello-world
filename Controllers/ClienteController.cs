using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CNRegistoHorasMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using TriggerMe.VAT;

namespace CNRegistoHorasMVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private CNRegistoHorasContext _context;

        public ClienteController(ILogger<ClienteController> logger, CNRegistoHorasContext context)
        {
            _logger = logger;
            _context = context;
        }


        // LISTA DE CLIENTES NA TABELA , COM FILTRO, E DEVOLUÇÃO DO NOME, NO CASO DE TER PEDIDO PARA REGISTAR NOME DO VIES
        public IActionResult Index(string filtrar, string nome, string contribuinte)
        {
            if (string.IsNullOrEmpty(filtrar))
            {
                ViewBag.listadeclientes = _context.Cliente.ToList();
            }
            else
            {
                filtrar = filtrar.ToLower();
                ViewBag.listadeclientes = _context.Cliente.ToList().Where(s => s.ClienteNome.ToLower().Contains(filtrar) || s.ClienteId.ToString().ToLower().Contains(filtrar));
            }

            var model = new Cliente()
            {
                ClienteNome = nome,
                ClienteId = Convert.ToInt32(contribuinte)
            };

            return View(model);
        }

        // -----------> SECÇÃO PARA ADICIONAR NOVO CLIENTE

        // ---> METODO GET
        public IActionResult Create()
        {
            return RedirectToAction(nameof(Index));
        }

        // ---> METODO POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,ClienteNome,ClienteAbreviatura,ClienteDescricao,ClienteErpid,ClienteEmail")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.listadeclientes = _context.Cliente.ToList();

            var model = new Cliente()
            {
                ClienteNome = "",
                ClienteId = 0
            };

            return View("Index", model);
        }

        // -----------> SECÇÃO PARA APAGAR CLIENTE

        // ---> METODO GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            Console.WriteLine(id);

            return RedirectToAction(nameof(Index));
        }

        // ---> METODO POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            Console.WriteLine(id);
            return RedirectToAction(nameof(Index));
        }

        // -----------> SECÇÃO PARA EDITAR CLIENTES

        // ---> METODO GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // ---> METODO POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,ClienteNome,ClienteAbreviatura,ClienteDescricao,ClienteErpid,ClienteEmail")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }

        // -----------> SECÇÃO PARA FILTRAR TABELA

        // ---> METODO GET
        public IActionResult Filtrar()
        {

            return View();

        }

        //---> METODO POST
        [HttpPost, ActionName("Filtrar")]
        public async Task<IActionResult> FiltrarConfirmed()
        {
            var model = _context.Cliente.ToList();

            Console.WriteLine("Fui clicado POST");

            ViewBag.listadeclientes = await _context.Cliente.ToListAsync();

            return RedirectToAction(nameof(Index));
        }

        // -----------> SECÇÃO PARA IR BUSCAR DADOS AO VIES

        public IActionResult Vies()
        {

            return View();

        }

        [HttpPost, ActionName("Vies")]
        public async Task<IActionResult> ViesConfirmed(int ClienteId, string ClienteNome)
        {
            var vatQuery = new VATQuery();
            var vatResult = await vatQuery.CheckVATNumberAsync("PT", ClienteId.ToString());

            return RedirectToAction(nameof(Index), new { nome = vatResult.Name, contribuinte = vatResult.VatNumber });
        }
    }
}
