using PosTechFiap.Test.IntegrationTests.BaseClasses;

[TestFixture]
public class CustomWebApplicationFactoryFixture
{
    public CustomWebApplicationFactory Factory { get; private set; }

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        Factory = new CustomWebApplicationFactory();
        await Factory.InitializeAsync();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await Factory.DisposeAsync();
    }
}
