using Examen.Models.Generic;

namespace Examen.Models.Many_to_Many
{
    public class Profesor:GenericModel
    {
        public string Nume { get; set; }
        public string Prenume {  get; set; }
        public int? Varsta {  get; set; }
        public string Tip { get; set; }
        public ICollection<ModelsRelation> ModelRelations { get; set; }
    }
}
