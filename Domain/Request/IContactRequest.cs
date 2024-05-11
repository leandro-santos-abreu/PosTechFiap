namespace Domain.Request;
public interface IContactRequest
{
    public string Name { get; set; }
    public int DDD { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
}