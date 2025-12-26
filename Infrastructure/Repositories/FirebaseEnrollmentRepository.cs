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
    public class FirebaseEnrollmentRepository : IEnrollmentRepository
    {

        private readonly FirestoreDb _firestoreDb;
        public FirebaseEnrollmentRepository(FirestoreDb firestoreDb) => _firestoreDb = firestoreDb;


        public async Task AddAsync(Enrollment enrollment)
        {
            await _firestoreDb.Collection("enrollments").Document(enrollment.Id)
                .SetAsync(new { enrollment.StudentId, enrollment.CourseId, enrollment.EnrolledOn });
        }

        public async Task<List<Enrollment>> GetEnrollmentsByStudentId(string studentId)
        {
            var snapshot = await _firestoreDb.Collection("enrollments")
                .WhereEqualTo("StudentId", studentId)
                .GetSnapshotAsync();

            return snapshot.Documents.Select(d => d.ConvertTo<Enrollment>()).ToList();
        }
    }
}
