using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cyrela.Models;
using Cyrela.DAL;

namespace Cyrela.Controllers
{
    public class ClientController : ApiController
    {
        public IHttpActionResult Get()
        {
            IList<Client> clients = new ClientDAL().List();
            return Ok(clients);
        }

        public IHttpActionResult Get(int Id)
        {
            try
            {
                Client client = new ClientDAL().Get(Id);
                return Ok(client);
            } 
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] Client client)
        {
            try
            {
                ClientDAL clientDAL = new ClientDAL();
                clientDAL.Insert(client);

                string location = Url.Link("DefaultApi", new { controller = "client", id = client.Id });

                return Created(new Uri(location), client);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int Id)
        {
            try
            {
                ClientDAL clientDAL = new ClientDAL();
                clientDAL.Delete(Id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put([FromBody] Client client)
        {
            try
            {
                ClientDAL clientDAL = new ClientDAL();
                clientDAL.Update(client);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
