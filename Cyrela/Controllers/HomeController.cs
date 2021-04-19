using Cyrela.DAL;
using Cyrela.Models;
using System;
using System.Collections.Generic;
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
                    if (homeStatus[i].Id == home.HomeStatus.Id)
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
