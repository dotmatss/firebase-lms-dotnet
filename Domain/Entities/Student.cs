using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student
    {
        public string Id { get; private set; }
        public string UserId { get; private set; }
        public string FullName { get; private set; }

        public Student(string userId, string fullName)
        {
            Id = Guid.NewGuid().ToString();
            UserId = userId;
            FullName = fullName;
        }
    }

}
