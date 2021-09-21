using ClimaTempo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClimaTempo.DAL
{
    public class ClimaTempoSimplesContext : DbContext
    {
        public DbSet<CidadeModel> Cidade { get; set; }
        public DbSet<EstadoModel> Estado { get; set; }
        public DbSet<PrevisaoClimaModel> PrevisaoClima { get; set; }

        public ClimaTempoSimplesContext() : base("ClimaTempoSimples")
        {

        }
    }
}