using Domain.Entities;

namespace Domain.Models;
public class Contact : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int DDD { get; set; }
    public string Telephone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
