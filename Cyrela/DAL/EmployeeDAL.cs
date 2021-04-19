using Cyrela.DAL.Context;
using Cyrela.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cyrela.DAL
{
    public class EmployeeDAL
    {
        private readonly DataBaseContext context;

        public EmployeeDAL()
        {
            context = new DataBaseContext();
        }

        public Employee Get(int Id)
        {
            return context.Employee
                .Include(e => e.Role)
                .ThenInclude(Role => Role.RoleServices)
                .Include(e => e.EmployeeDaysOff)
                .Include(e => e.Schedules)
                .FirstOrDefault(s => s.Id == Id)
            ;
        }
    }
}