
namespace Dataflow.Shared.Models
{
    public class PunchDaily
    {
        public int IdUser { get; set; }
        public string Empleado { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string NameDay { get; set; } = string.Empty;
        public int ShiftId { get; set; }
    }
}
