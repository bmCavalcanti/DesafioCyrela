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
            try
            {
                IList<Scheduling> list = new SchedulingDAL().List();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Get(int Id)
        {
            try
            {
                Scheduling scheduling = new SchedulingDAL().Get(Id);
                
                if (scheduling == null)
                {
                    return NotFound();
                }

                return Ok(scheduling);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post([FromBody] Scheduling scheduling)
        {
            try
            {
                GetErrors(scheduling);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

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
                SchedulingDAL schedulingDAL = new SchedulingDAL();

                if (schedulingDAL.GetSimple(Id) == null)
                {
                    return NotFound();
                }

                schedulingDAL.Delete(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(int Id, [FromBody] Scheduling scheduling)
        {
            if (Id != scheduling.Id)
            {
                return BadRequest("Os IDs de identificação não podem ser diferentes");
            }

            try
            {
                SchedulingDAL schedulingDAL = new SchedulingDAL();

                Scheduling schedulingOld = schedulingDAL.GetSimple(scheduling.Id);

                if (schedulingOld == null)
                {
                    return NotFound();
                } 
                else if (scheduling.HomeId != schedulingOld.HomeId)
                {
                    return BadRequest("O empreendimento não pode ser alterado.");
                }

                GetErrors(scheduling);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                schedulingOld.SchedulingDate = scheduling.SchedulingDate;
                schedulingOld.EmployeeId = scheduling.EmployeeId;
                schedulingOld.SchedulingStatusId = scheduling.SchedulingStatusId;
                schedulingOld.SchedulingTypeId = scheduling.SchedulingTypeId;
                schedulingOld.ServiceId = scheduling.ServiceId;

                schedulingDAL.Update(schedulingOld);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public void GetErrors(Scheduling scheduling)
        {
            if (scheduling.SchedulingTypeId.Equals(SchedulingType.TECHNICAL_ASSISTANCE) && scheduling.ServiceId == null)
            {
                ModelState.AddModelError("scheduling.ServiceId", "Agendamentos do tipo '1 - ASSISTÊNCIA TÉCNICA' devem possuir um serviço.");
            }

            if (scheduling.SchedulingTypeId.Equals(SchedulingType.INSPECTION) && scheduling.ServiceId != null)
            {
                ModelState.AddModelError("scheduling.ServiceId", "Agendamentos do tipo '2 - VISTORIA' não podem possuir serviço.");
            }
        }
    }
}
