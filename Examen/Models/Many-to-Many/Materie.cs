using Examen.Models.Generic;

namespace Examen.Models.Many_to_Many
{
    public class Materie:GenericModel
    {
        public string Denumire { get; set; }
        public ICollection<ModelsRelation> ModelRelations { get; set; }
    }
}
