using Cyrela.DAL;
using Cyrela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cyrela.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Get(int Id)
        {
            try
            {
                Home home = new HomeDAL().Get(Id);

                if (home == null)
                {
                    return NotFound();
                }

                IList<HomeStatus> homeStatus = new HomeStatusDAL().List();
                HomeStatus nextHomeStatus = null;

                int index = -1;

                for (int i = 0; i < homeStatus.Count; i++)
                {
                    if (homeStatus[i].Id == home.HomeStatusId)
                    {
                        index = ++i;
                        break;
                    }
                }

                if (index >= 0 && index < homeStatus.Count)
                {
                    nextHomeStatus = homeStatus[index];
                }

                return Ok(new { Home = home, HomeStatus = homeStatus, nextHomeStatus });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int Id, [FromBody] Home home)
        {
            try
            {
                if (Id != home.Id)
                {
                    return BadRequest("Os IDs de identificação não podem ser diferentes");
                }

                HomeDAL homeDAL = new HomeDAL();
                Home homeOld = homeDAL.Get(home.Id);

                if (homeOld == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                homeOld.HomeStatusId = home.HomeStatusId;
                homeOld.DeliveryDate = home.DeliveryDate;
                homeOld.Block = home.Block;
                homeOld.Apartment = home.Apartment;

                if (home.HomeAddress != null)
                {
                    homeOld.HomeAddress.CityId = home.HomeAddress.CityId;
                    homeOld.HomeAddress.Complement = home.HomeAddress.Complement;
                    homeOld.HomeAddress.District = home.HomeAddress.District;
                    homeOld.HomeAddress.HomeNumber = home.HomeAddress.HomeNumber;
                    homeOld.HomeAddress.Street = home.HomeAddress.Street;

                    new HomeAddressDAL().Update(homeOld.HomeAddress);
                }

                homeDAL.Update(homeOld);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
