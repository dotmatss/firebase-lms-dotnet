using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetByIdAsync(string id);
        Task UpdateAsync(Course course);
        Task AddAsync(Course course);

        Task DeleteAsync(string id);
    }
}
