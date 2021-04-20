using System;
using System.Collections.Generic;
using System.Web.Http;
using Cyrela.Models;
using Cyrela.DAL;
using System.Linq;

namespace Cyrela.Controllers
{
    public class SchedulingController : ApiController
    {
        private static string TYPE_BY_ID = "BY_ID";
        private static string TYPE_BY_CLIENT = "BY_CLIENT_ID";

        public IHttpActionResult Get(int Id, string type = "BY_ID")
        {
            try
            {
                if (type == TYPE_BY_ID)
                {
                    Scheduling scheduling = new SchedulingDAL().Get(Id);

                    if (scheduling == null)
                    {
                        return NotFound();
                    }

                    return Ok(scheduling);
                }
                else if (type == TYPE_BY_CLIENT)
                {
                    IList<Scheduling> list = new SchedulingDAL().ListByClient(Id);
                    return Ok(list);
                }
                else
                {
                    return BadRequest();
                }
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
                if (scheduling.SchedulingDate < DateTime.Now)
                {
                    ModelState.AddModelError("scheduling.SchedulingDate", "A data do agendamento não pode ser anterior a atual.");
                }

                ModelErrors(scheduling);

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
                Scheduling scheduling = schedulingDAL.GetSimple(Id);

                if (scheduling == null)
                {
                    return NotFound();
                }

                scheduling.SchedulingStatusId = SchedulingStatus.CANCELED;
                schedulingDAL.Update(scheduling);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int Id, [FromBody] Scheduling scheduling)
        {
            try
            {
                if (Id != scheduling.Id)
                {
                    return BadRequest("Os IDs de identificação não podem ser diferentes");
                }

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

                bool isUpdate = (scheduling.EmployeeId == schedulingOld.EmployeeId);

                ModelErrors(scheduling, isUpdate);

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
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private void ModelErrors(Scheduling scheduling, bool isUpdate = false)
        {
            try
            {
                Employee employee = new EmployeeDAL().Get(scheduling.EmployeeId);
                Home home = new HomeDAL().Get(scheduling.HomeId);
                Service service = new ServiceDAL().Get(scheduling.ServiceId);

                if (scheduling.SchedulingTypeId.Equals(SchedulingType.TECHNICAL_ASSISTANCE) && scheduling.ServiceId == null)
                {
                    ModelState.AddModelError("scheduling.ServiceId", "Agendamentos do tipo '1 - ASSISTÊNCIA TÉCNICA' devem possuir um serviço.");
                }

                if (scheduling.SchedulingTypeId.Equals(SchedulingType.INSPECTION) && scheduling.ServiceId != null)
                {
                    ModelState.AddModelError("scheduling.ServiceId", "Agendamentos do tipo '2 - VISTORIA' não podem possuir serviço.");
                }

                if (scheduling.SchedulingTypeId == SchedulingType.TECHNICAL_ASSISTANCE && scheduling.SchedulingDate.Date > home.DeliveryDate.AddMonths(service.MonthsWarranty))
                {
                    ModelState.AddModelError("scheduling.ServiceId", "Esse serviço está fora da garantia para esse empreendimento.");
                }

                if (scheduling.SchedulingTypeId == SchedulingType.TECHNICAL_ASSISTANCE && employee.Role.RoleServices.All(rs => rs.ServiceId != service.Id))
                {
                    ModelState.AddModelError("scheduling.EmployeeId", "Esse funcionário não realiza esse serviço.");
                }

                if (scheduling.SchedulingTypeId == SchedulingType.INSPECTION && employee.Role.Id != Role.INSPECTION)
                {
                    ModelState.AddModelError("scheduling.EmployeeId", "Esse funcionário não realiza vistoria.");
                }

                if (employee.EmployeeDaysOff.Any(edo => edo.DayOffDate.Date == scheduling.SchedulingDate.Date))
                {
                    ModelState.AddModelError("scheduling.EmployeeId", "Esse funcionário não está disponível para essa data de agendamento.");
                }

                if (scheduling.SchedulingDate.Hour < employee.WorkStartsAt || scheduling.SchedulingDate.Hour >= employee.WorkEndsAt)
                {
                    ModelState.AddModelError("scheduling.EmployeeId", "Esse funcionário não está disponível para esse horário de agendamento.");
                }

                if (!isUpdate)
                {
                    if (employee.Schedules.Any(s => 
                            scheduling.SchedulingDate >= s.SchedulingDate && 
                            scheduling.SchedulingDate <= s.SchedulingDate.AddHours(service.ServiceDuration) &&
                            s.SchedulingStatusId == SchedulingStatus.WAITING
                        )
                    )
                    {
                        ModelState.AddModelError("scheduling.EmployeeId", "Esse funcionário não está disponível para essa data e/ou horário de agendamento.");
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("Message", "Erro interno.");
            }
        }
    }
}
