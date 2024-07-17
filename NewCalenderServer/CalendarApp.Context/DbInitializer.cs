using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Context
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            //if (context.UserTypes.Any())
            //{
            //    return;   // DB has been seeded
            //}
            //var userTypes = new UserType[]
            //{
            //   new UserType { Name = "Admin" },
            //   new UserType { Name = "Editor" },
            //   new UserType { Name = "Viewer" }
            //};

            //context.UserTypes.AddRange(userTypes);
            //context.SaveChanges();
        }
    }
}
