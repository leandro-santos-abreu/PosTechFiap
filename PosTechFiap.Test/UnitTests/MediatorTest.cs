using Application.Contracts;
using Application.Mediator.Command;
using Domain.Entities;
using Moq;

namespace PosTechFiap.Test.UnitTests;

[TestFixture]
public class MediatorTest
{
    private readonly CreateContactCommandHandler createContactCommandHandler;
    private readonly DeleteContactCommandHandler deleteContactCommandHandler;
    private readonly UpdateContactCommandHandler updateContactCommandHandler;
    private readonly Mock<IContactService> _contactService = new Mock<IContactService>();
    private readonly CancellationToken token = new CancellationToken();
    private IEnumerable<Contact> contacts;

    public MediatorTest()
    {
        contacts = new List<Contact>
        {
            new Contact (1){ Name = "John Doe", Email = "john.doe@example.com", DDD = 13 , Telephone = "912162549"},
            new Contact (2){Name = "Jane Smith", Email = "jane.smith@example.com", DDD = 11, Telephone = "912162549"},
            new Contact (3){Name = "Mike Johnson", Email = "mike.johnson@example.com", DDD = 14, Telephone = "912162549"}
        };

        createContactCommandHandler = new CreateContactCommandHandler(_contactService.Object);
        deleteContactCommandHandler = new DeleteContactCommandHandler(_contactService.Object);
        updateContactCommandHandler = new UpdateContactCommandHandler(_contactService.Object);
    }

    [SetUp]
    public void SetUp()
    {
        _contactService.Setup(i => i.Create(It.IsAny<CreateContactCommand>())).ReturnsAsync(true);
        _contactService.Setup(i => i.Get(It.IsAny<int?>())).ReturnsAsync(contacts);
        _contactService.Setup(i => i.Update(It.IsAny<UpdateContactCommand>())).ReturnsAsync(true);
        _contactService.Setup(i => i.Delete(It.IsAny<int>())).ReturnsAsync(true);
    }

    [Test]
    public async Task Test_Create()
    {
        _contactService.Setup(i => i.Exists(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(false);

        CreateContactCommand request = new CreateContactCommand("New User", 15, "912345678", "new.user@example.com");

        var result = await createContactCommandHandler.Handle(request, token);

        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public async Task Test_Update()
    {
        _contactService.Setup(i => i.Exists(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(true);

        UpdateContactCommand request = new UpdateContactCommand(1, "Updated User", 15, "912345678", "updated.user@example.com");

        var result = await updateContactCommandHandler.Handle(request, token);

        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public async Task Test_Delete()
    {
        var command = new DeleteContactCommand(1);

        var result = await deleteContactCommandHandler.Handle(command, token);

        Assert.That(result, Is.EqualTo(true));
    }
}