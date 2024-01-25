namespace Examen.Models.DTO
{
    public class ProfDTO
    {
        Guid Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int? Varsta { get; set; }
        public string Tip {  get; set; }
    }
}
