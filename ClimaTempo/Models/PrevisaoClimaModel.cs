using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ClimaTempo.Models
{
    [Table("PrevisaoClima")]
    public class PrevisaoClimaModel
    {
        public int Id { get; set; }
        public int CidadeId { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Clima { get; set; }
        public decimal TemperaturaMinima { get; set; }
        public decimal TemperaturaMaxima { get; set; }
        public CidadeModel Cidade { get; set; }

        public string RetornaSemana()
        {
            //Não encontrei uma forma mais simples de traduzir o dia da semana
            string semana = "";

            switch (DataPrevisao.DayOfWeek.ToString())
            {
                case "Monday":
                    semana = "Segunda-feira";
                        break;
                case "Tuesday":
                    semana = "Terça-feira";
                    break;
                case "Wednesday":
                    semana = "Quarta-feira";
                    break;
                case "Thursday":
                    semana = "Quinta-feira";
                    break;
                case "Friday":
                    semana = "Sexta-feira";
                    break;
                case "Saturday":
                    semana = "Sábado";
                    break;
                case "Sunday":
                    semana = "Domingo";
                    break;
            }
            return semana;
        }

        public string ImagemClima()
        {
            return $"/Images/{Clima}.png";
        }
    }
}