using Domain.Entities;
using Domain.Request;
using Microsoft.AspNetCore.Mvc.Testing;
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
            _client?.Dispose();
        }

        [Test]
        public async Task ShouldAddContactSuccessfully()
        {

            var request = new CreateContactRequest()
            {
                DDD = 21,
                Email = "12345@outlook.com",
                Name = "Test",
                Telephone = "976436563"
            };

            var body = JsonSerializer.Serialize(request);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(baseRoute, content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            await Task.Delay(500);

            var getResponse = await _client.GetAsync($"{baseRoute}?DDD={21}");
            var contacts = (await getResponse.Content.ReadFromJsonAsync<IEnumerable<Contact>>())!;

            Assert.That(contacts.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task ShouldEditContactSuccessfully()
        {
            var request = new CreateContactRequest()
            {
                DDD = 22,
                Email = "12345@outlook.com",
                Name = "Test",
                Telephone = "976436593"
            };

            var body = JsonSerializer.Serialize(request);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(baseRoute, content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            await Task.Delay(500);

            var getResponse = await _client.GetAsync($"{baseRoute}?DDD={22}");
            var contact = (await getResponse.Content.ReadFromJsonAsync<IEnumerable<Contact>>())?.FirstOrDefault()!;
            contact.Name = "Test_Update";

            var updateRequest = new UpdateContactRequest()
            {
                DDD = contact.DDD,
                Id = contact.Id,
                Email = contact.Email,
                Name = contact.Name,
                Telephone = contact.Telephone,
            };

            body = JsonSerializer.Serialize(updateRequest);
            content = new StringContent(body, Encoding.UTF8, "application/json");

            response = await _client.PutAsync(baseRoute, content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            await Task.Delay(500);

            getResponse = await _client.GetAsync($"{baseRoute}?DDD={22}");
            contact = (await getResponse.Content.ReadFromJsonAsync<IEnumerable<Contact>>())?.FirstOrDefault()!;

            Assert.That(contact.Name, Is.EqualTo("Test_Update"));
        }

        [Test]
        public async Task ShouldRemoveContactSuccessfully()
        {
            var request = new CreateContactRequest()
            {
                DDD = 27,
                Email = "12345@outlook.com",
                Name = "Test",
                Telephone = "976436583"
            };

            var body = JsonSerializer.Serialize(request);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(baseRoute, content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            await Task.Delay(500);

            var getResponse = await _client.GetAsync($"{baseRoute}?DDD={27}");
            var contacts = (await getResponse.Content.ReadFromJsonAsync<IEnumerable<Contact>>())!;

            Assert.That(contacts.Count(), Is.EqualTo(1));

            response = await _client.DeleteAsync($"{baseRoute}?id={contacts?.FirstOrDefault()?.Id}");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            await Task.Delay(500);

            getResponse = await _client.GetAsync($"{baseRoute}?DDD={27}");
            contacts = (await getResponse.Content.ReadFromJsonAsync<IEnumerable<Contact>>())!;

            Assert.That(contacts.Count(), Is.EqualTo(0));
        }

    }
}
