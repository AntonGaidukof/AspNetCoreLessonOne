namespace WebStore.Domain.Entities.Base
{
    public abstract class NamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
