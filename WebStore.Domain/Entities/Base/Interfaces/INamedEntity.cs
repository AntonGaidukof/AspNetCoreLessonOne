namespace WebStore.Domain.Entities.Base.Interfaces
{
    public interface INamedEntity
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
