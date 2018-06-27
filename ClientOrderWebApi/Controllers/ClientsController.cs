//using ClientOrder.Domain.Entities;
//using ClientOrder.Service.ClientServicies;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ClientOrderWebApi.Controllers
//{
//    [Route("api/[controller]")]
//    public class ClientsController : Controller
//    {
//        private readonly ClientService clientService;
//        public ClientsController(ClientService clientService)
//            => this.clientService = clientService;
        
//        // GET api/values
//        [HttpGet]
//        public IEnumerable<KeyValuePair<Guid, string>> Get()
//            => clientService.GetClientsReferenceList().ToList();

//        // GET api/values/5
//        [HttpGet("{id}")]
//        public Client Get(Guid id)
//            => clientService.LoadClientGraph(id);

//        // POST api/values
//        [HttpPost]
//        public void Post([FromBody]Client value)
//            => clientService.Save(value);

//        // PUT api/values/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]Client value)
//            => clientService.Save(value); 

//        // DELETE api/values/5
//        [HttpDelete("{id}")]
//        public void Delete(Guid id)
//            => clientService.CascadeDelete(id);
//    }
//}
