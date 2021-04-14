using System;
using System.Collections.Generic;
using System.Web.Http;
using Cyrela.Models;
using Cyrela.DAL;

namespace Cyrela.Controllers
{
    public class SchedulingController : ApiController
    {
        public IHttpActionResult Get()
        {
            IList<Scheduling> list = new SchedulingDAL().List();
            return Ok(list);
        }

        public IHttpActionResult Get(int Id)
        {
            try
            {
                return Ok(new SchedulingDAL().Get(Id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] Scheduling scheduling)
        {
            try
            {
                new SchedulingDAL().Insert(scheduling);

                string location = Url.Link("DefaultApi", new { controller = "scheduling", id = scheduling.Id });

                return Created(new Uri(location), scheduling);
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
                new SchedulingDAL().Delete(Id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put([FromBody] Scheduling scheduling)
        {
            try
            {
                new SchedulingDAL().Update(scheduling);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
