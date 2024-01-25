namespace Examen.Models.Generic
{
    public interface IGenericModel
    {
        Guid Id { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? LastModified { get; set; }
    }
}
