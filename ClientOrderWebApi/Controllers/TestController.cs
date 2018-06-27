using ClientOrder.Domain.Entities;
using ClientOrder.Service.Plain;
using Microsoft.AspNetCore.Mvc;

namespace ClientOrderWebApi.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private ClientService clientService;
        public TestController(ClientService clientService)
        {
            this.clientService = clientService;
        }

        // GET api/test
        [HttpGet]
        public string Get()
        {
            var client = clientService.AddClient(new Client() { FirstName = "Dan", LastName = "Brezoi", MiddleName = "Alexandru" });
            var allClients = clientService.GetAllClients();
            var firstClient = clientService.GetClient(client.ClientId);
            var storeProcedureResult = clientService.GetClientsWithFirstName("Dan");

            clientService.Add10Clients();
            //clientService.AddClient(FirstName: "Oscar", LastName: "Lazlo");
            return string.Empty;
        }
    }
}
