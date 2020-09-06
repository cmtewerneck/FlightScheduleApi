using System.Collections.Generic;

namespace FlightScheduleApi.Business.Models
{
    public class Aeronave : Entity
    {
        public string Matricula { get; set; }
        public string Fabricante { get; set; }
        public string Categoria { get; set; }
        public string Modelo { get; set; }
    }
}
