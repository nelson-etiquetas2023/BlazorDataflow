
namespace Dataflow.Shared.Models
{
    public class PunchDaily
    {
        public int IdUser { get; set; }
        public string Empleado { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string NameDay { get; set; } = string.Empty;
        public int ShiftId { get; set; }
        public string Horario { get; set; } = null!;
        public int IndexDay { get; set; }
        public string Entrada { get; set; } = null!;
        public string Salida { get; set; } = null!;
        public string Horas_Hor { get; set; } = null!;
        public string M1 { get; set; } = null!;
        public string M2 { get; set; } = null!;
        public string M3 { get; set; } = null!;
        public string M4 { get; set; } = null!;
        public Int64 Ponches { get; set; }
        public int Tardanza { get; set; }
        public int Temprano { get; set; }
        public decimal Hextras { get; set; }
        public int Mextras { get; set; }
        public decimal SalaryHour { get; set; }
    }
}
