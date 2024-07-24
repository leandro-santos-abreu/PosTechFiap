namespace Domain.Entities;
public interface IBaseEntity
{
    int Id { get; }
}

public abstract class BaseEntity : IEquatable<BaseEntity>
{
    public int Id { get; set; }

    public BaseEntity(int id) => Id = id;
    protected BaseEntity() => Id = default!;

    public override bool Equals(object? obj) => obj is BaseEntity entity && Equals(entity);
    public bool Equals(BaseEntity? other) => other != null && Id.Equals(other.Id);

    public static bool operator ==(BaseEntity? left, BaseEntity? right) => Equals(left, right);
    public static bool operator !=(BaseEntity? left, BaseEntity? right) => !Equals(left, right);

    public override int GetHashCode() => Id.GetHashCode();
}