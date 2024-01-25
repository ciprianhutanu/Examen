namespace Examen.Models.Many_to_Many
{
    public class ModelsRelation
    {
        public Guid ProfId { get; set; }
        public Profesor Prof {  get; set; }

        public Guid MatId { get; set; }
        public Materie Mat { get; set; }
    }
}
