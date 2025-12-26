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
    public class FirebaseStudentRepository : IStudentRepository
    {
        private readonly FirestoreDb _firestoreDb;
        public FirebaseStudentRepository(FirestoreDb firestoreDb) => _firestoreDb = firestoreDb;

        public async Task AddAsync(Student student)
        {
            await _firestoreDb.Collection("students").Document(student.Id)
                .SetAsync(new { student.Name, student.Email });
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            var doc = await _firestoreDb.Collection("students").Document(id).GetSnapshotAsync();
            if (!doc.Exists) return null;
            return doc.ConvertTo<Student>();
        }
    }
}
