using Domain.Entities;
using Domain.Request;
using PosTechFiap.Test.IntegrationTests.BaseClasses;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PosTechFiap.Test.IntegrationTests
{
    [TestFixture]
    public class ContactIntegrationTest
    {
        private readonly string baseRoute = "api/Contact";
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _factory = new CustomWebApplicationFactory();
            await _factory.InitializeAsync();
            _client = _factory.CreateClient();

        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _factory.DisposeAsync();
            _client.Dispose();
        }

        [Test]
        public async Task ShouldAddContactSuccessfully()
        {
            var request = new CreateContactRequest()
            {
                DDD = 27,
                Email = "12345@outlook.com",
                Name = "Test",
                Telephone = "976436563"
            };

            var body = JsonSerializer.Serialize(request);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(baseRoute, content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var getResponse = await _client.GetAsync(baseRoute);
            var contacts = (await getResponse.Content.ReadFromJsonAsync<IEnumerable<Contact>>())!;

            Assert.That(contacts.Count(), Is.EqualTo(1));
        }
    }
}
