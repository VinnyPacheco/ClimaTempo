using ClimaTempo.DAL;
using ClimaTempo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ClimaTempo.Controllers
{
    public class HomeController : Controller
    {
        private ClimaTempoSimplesContext db = new ClimaTempoSimplesContext();
        public ActionResult Index()
        {
            ViewBag.ClimaCidadesQuentes = ClimaCidadesQuentes();
            ViewBag.ClimaCidadesFrias = ClimaCidadesFrias();
            ViewBag.PrevisaoCidade = PrevisaoCidade("São Paulo");
            ViewBag.CidadePesquisada = "São Paulo";

            return View();
        }

        [HttpPost]
        public ActionResult Index(string nomeCidade)
        {
            ViewBag.ClimaCidadesQuentes = ClimaCidadesQuentes();
            ViewBag.ClimaCidadesFrias = ClimaCidadesFrias();
            ViewBag.PrevisaoCidade = PrevisaoCidade(nomeCidade);
            ViewBag.CidadePesquisada = nomeCidade;
            return View();
        }

        private List<PrevisaoClimaModel> ClimaCidadesQuentes()
        {
            var ClimaCidades = new List<PrevisaoClimaModel>();
            ClimaCidades = db.PrevisaoClima
                .Where(d => d.DataPrevisao == DateTime.Today)
                .OrderByDescending(a => a.TemperaturaMaxima)
                .ThenBy(e => e.Cidade.Nome)
                .ThenBy(e => e.Cidade.Estado.Nome)
                .Include(b => b.Cidade)
                .Include(c => c.Cidade.Estado)
                .Take(3)
                .ToList();

            return ClimaCidades;
        }

        private List<PrevisaoClimaModel> ClimaCidadesFrias()
        {
            var ClimaCidades = new List<PrevisaoClimaModel>();
            ClimaCidades = db.PrevisaoClima
                .Where(d => d.DataPrevisao == DateTime.Today)
                .OrderBy(a => a.TemperaturaMaxima)
                .ThenBy(e => e.Cidade.Nome)
                .ThenBy(e => e.Cidade.Estado.Nome)
                .Include(b => b.Cidade)
                .Include(c => c.Cidade.Estado)
                .Take(3)
                .ToList();

            return ClimaCidades;
        }

        private List<PrevisaoClimaModel> PrevisaoCidade(string cidade)
        {
            var ClimaCidades = new List<PrevisaoClimaModel>();
            ClimaCidades = db.PrevisaoClima
                .Where(d => d.DataPrevisao >= DateTime.Today && d.Cidade.Nome == cidade)
                .OrderBy(a => a.DataPrevisao)
                .Include(b => b.Cidade)
                .Include(c => c.Cidade.Estado)
                .Take(7)
                .ToList();

            return ClimaCidades;
        }
    }
}