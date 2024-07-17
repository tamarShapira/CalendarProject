using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace RepProject.Mock
{
    public class MockContext //: IContext
    {
        public List<Role> roles { get; set; }

        public List<Permission> permissions { get; set; }

        public List<Claim> claims { get; set; }

        public MockContext()
        {
            roles = new List<Role>();
            permissions = new List<Permission>();

            roles.Add(new Role { Id = 1, Name = "admin" });
            roles.Add(new Role { Id = 2, Name = "user" });

            permissions.Add(new Permission { Id = 1, Name = "VIEW_ALL_ROLES" });
            permissions.Add(new Permission { Id = 2, Name = "ADD_ROLE" });

            claims.Add(new Claim { });
            claims.Add(new Claim { });
        }
    }
}
