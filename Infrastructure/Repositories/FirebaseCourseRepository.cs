using Domain.Entities;
using Domain.Interfaces;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FirebaseCourseRepository : ICourseRepository
    {

        private readonly FirestoreDb _firestoreDb;

        public FirebaseCourseRepository(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        public async Task AddAsync(Course course)
        {
            await _firestoreDb.Collection("courses").Document(course.Id)
               .SetAsync(new { course.Title, course.Description });
        }

        public async Task<Course> GetByIdAsync(string id)
        {
            var doc = await _firestoreDb.Collection("courses").Document(id).GetSnapshotAsync();
            if (!doc.Exists) return null;
            return doc.ConvertTo<Course>();
        }

        public async Task UpdateAsync(Course course)
        {
            await _firestoreDb.Collection("courses").Document(course.Id)
               .SetAsync(new { course.Title, course.Description }, SetOptions.Overwrite);
        }
    }
}
