using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;
using ContaBancaria.API.Domain.Models;
using ContaBancaria.API.Domain.DTOs;

namespace ContaBancaria.API.IntegrationTests
{
    public class TransacaoControllerIntegrationTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;

        public TransacaoControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory) => this.client = factory.CreateClient();

        [Fact]
        public async void TestGetTransacoesAsync()
        {
            var response = await this.client.GetAsync("/api/contas/1/transacoes");

            var stringResponse = await response.Content.ReadAsStringAsync();
            var transacoes = JsonConvert.DeserializeObject<IEnumerable<Transacao>>(stringResponse);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains(transacoes, t => t.Id.Equals(1));
        }

        [Fact]
        public async void TestPostDepositoAsync()
        {
            var deposito = new DepositoRequestDTO(1, 10.0m);

            var response = await this.client.PostAsJsonAsync<DepositoRequestDTO>("/api/contas/1/depositos", deposito);

            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            
            Assert.Equal("api/contas/1", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async void TestPostSaqueAsync()
        {
            var saque = new SaqueRequestDTO(1, 10.0m);

            var response = await this.client.PostAsJsonAsync<SaqueRequestDTO>("/api/contas/1/saques", saque);

            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            
            Assert.Equal("api/contas/1", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async void TestPostTransferenciaAsync()
        {
            var transferencia = new TransferenciaRequestDTO(1, 2, 10);

            var response = await this.client.PostAsJsonAsync<TransferenciaRequestDTO>("/api/contas/1/transferencias", transferencia);

            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}