using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagement.DLL.Entity;


namespace StudentManagement.DLL.Entity
{
    public class StudentIdentity : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int UserType { get; set; }
        public DateTime CreatedDate  { get; set; }       

    }
}
