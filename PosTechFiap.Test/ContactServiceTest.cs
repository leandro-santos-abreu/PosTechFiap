using Application.Contracts;
using Application.Mediator.Command;
using Application.Services;
using Domain.Entities;
using Moq;
using Persistence.Contract;

namespace Tests;

[TestFixture]
public class ContactServiceTest
{
    private readonly IContactService _contactService;
    private readonly Mock<IContactRepository> _contactRepository = new Mock<IContactRepository>();
    private readonly Mock<IDDDRepository> _DDDRepository = new Mock<IDDDRepository>();
    private List<Contact> contacts;
    public ContactServiceTest()
    {
        _contactService = new ContactService(_contactRepository.Object, _DDDRepository.Object);
        contacts = new List<Contact>
        {
            new Contact (1){ Name = "John Doe", Email = "john.doe@example.com", DDD = 13 , Telephone = "912162549"},
            new Contact (2){Name = "Jane Smith", Email = "jane.smith@example.com", DDD = 11, Telephone = "912162549"},
            new Contact (3){Name = "Mike Johnson", Email = "mike.johnson@example.com", DDD = 14, Telephone = "912162549"}
        };
    }

    [SetUp]
    public void SetUp()
    {
        _contactRepository.Setup(i => i.Get()).ReturnsAsync(contacts);
        _contactRepository.Setup(i => i.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(true);
        _contactRepository.Setup(i => i.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(true);
        _contactRepository.Setup(i => i.Delete(It.IsAny<int>())).ReturnsAsync(true);
        
        _DDDRepository.Setup(i => i.Exists(It.IsAny<int>())).ReturnsAsync(true);
    }

    [Test]
    public async Task Test_Get()
    {
        var result = await _contactService.Get(null);
        Assert.That(result.Count(), Is.EqualTo(3));
        Assert.That(result, Is.EqualTo(contacts));
    }

    [Test]
    public async Task Test_Get_By_DDD()
    {
        var result = await _contactService.Get(11);
        Assert.That(result.Count(), Is.EqualTo(1)); 
        Assert.That(result, Is.EqualTo(contacts.Where(i => i.DDD == 11)));
    }

    [Test]
    public async Task Test_Create()
    {
        _contactRepository.Setup(i => i.Exists(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(false);

        CreateContactCommand request = new CreateContactCommand("New User",  15, "912345678", "new.user@example.com");

        var result = await _contactService.Create(request);

        Assert.IsTrue(result);
    }

    [Test]
    public async Task Test_Update()
    {
        _contactRepository.Setup(i => i.Exists(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(true);

        UpdateContactCommand request = new UpdateContactCommand(1, "Updated User", 15, "912345678", "updated.user@example.com");

        var result = await _contactService.Update(request);

        Assert.IsTrue(result);
    }

    [Test]
    public async Task Test_Delete()
    {
        int contactIdToDelete = 1;

        var result = await _contactService.Delete(contactIdToDelete);

        Assert.IsTrue(result);
    }
}
