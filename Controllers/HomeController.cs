using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CNRegistoHorasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CNRegistoHorasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CNRegistoHorasContext _context;

        public HomeController(ILogger<HomeController> logger, CNRegistoHorasContext context)
        {
            _logger = logger;
            _context = context;
        }


        // LISTAR LISTA DE CLIENTES NA TABELA
        public IActionResult Index()
        {

            ViewBag.listadeclientes = _context.Cliente.ToList();
            return View();

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
            return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }

        // -----------> SECÇÃO PARA EDITAR CLIENTES

        // ---> METODO GET
        public IActionResult Edit()
        {

            ViewBag.listadeclientes = _context.Cliente.ToList();
            return View();

        }

        // ---> METODO POST
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int id)
        {

            Console.WriteLine(id);
            return RedirectToAction(nameof(Index));
        }
    }}
