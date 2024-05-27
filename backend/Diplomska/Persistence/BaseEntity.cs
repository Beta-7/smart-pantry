namespace Diplomska.Persistence
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? LastModified { get; set; } = DateTime.UtcNow;
        public DateTime? Created { get; set; } = DateTime.UtcNow;
        public bool Deleted { get; set; }
    }

    public class OrderableEntity: BaseEntity
    {
        public int Order { get; set; }
    }
}