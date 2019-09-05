using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using ContaBancaria.API;
using System.Net;
using System.Collections.Generic;
using ContaBancaria.API.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace ContaBancaria.API.IntegrationTests
{
    public class ContaCorrenteControllerIntegrationTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;

        public ContaCorrenteControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory) => this.client = factory.CreateClient();

        [Fact]
        public async void TestGetContasAsync()
        {
            var response = await this.client.GetAsync("/api/contas");

            var stringResponse = await response.Content.ReadAsStringAsync();
            var contas = JsonConvert.DeserializeObject<IEnumerable<ContaCorrente>>(stringResponse);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains(contas, c => c.Id.Equals(1));
            Assert.Contains(contas, c => c.Id.Equals(2));
            Assert.Contains(contas, c => c.Id.Equals(3));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void TestGetContaByIdAsync(int id)
        {
            var response = await this.client.GetAsync($"/api/contas/{id}");

            var stringResponse = await response.Content.ReadAsStringAsync();

            var conta = JsonConvert.DeserializeObject<ContaCorrente>(stringResponse);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(id, conta.Id);
        }

        [Fact]
        public async void TestPostContaAsync()
        {
            var conta = new ContaCorrente(0, 100);

            var response = await this.client.PostAsJsonAsync<ContaCorrente>("/api/contas", conta);

            var stringResponse = await response.Content.ReadAsStringAsync();

            conta = JsonConvert.DeserializeObject<ContaCorrente>(stringResponse);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(4, conta.Id);
            Assert.Equal("http://localhost/api/contas/4", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async void TestPutContaAsync()
        {
            var conta = new ContaCorrente(2, 100);

            var response = await this.client.PutAsJsonAsync<ContaCorrente>("/api/contas/2", conta);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(2, conta.Id);
            
        }

        [Fact]
        public async void TestDeleteContaAsync()
        {
            var response = await this.client.DeleteAsync("/api/contas/1");

            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.True(string.IsNullOrEmpty(stringResponse));
        }

        [Fact]
        public async void TestURIInvalidaNoCadastroDeConta()
        {
            var conta = new ContaCorrente(0, 100);

            var response = await this.client.PostAsJsonAsync<ContaCorrente>("/api/conta", conta);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
