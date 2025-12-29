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
    public class FirebaseUserRepository : IUserRepository
    {
        private readonly FirestoreDb _firestoreDb;
        private readonly string _collectionName = "users";

        public FirebaseUserRepository(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        public async Task AddAsync(User user)
        {
            DocumentReference docRef = _firestoreDb.Collection(_collectionName).Document(user.Id);

            await docRef.SetAsync(new
            {
                user.Id,
                user.Email,
                user.PasswordHash
            });
        }

        public async Task DeleteAsync(string id)
        {
            DocumentReference docRef = _firestoreDb.Collection(_collectionName).Document(id);
            await docRef.DeleteAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            CollectionReference usersRef = _firestoreDb.Collection(_collectionName);
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();

            return snapshot.Documents.Select(doc =>
            {
                var data = doc.ToDictionary();
                return new User(
                    id: data["Id"].ToString(),
                    email: data["Email"].ToString(),
                    passwordHash: data["PasswordHash"].ToString()
                );
            }).ToList();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            DocumentReference docRef = _firestoreDb.Collection(_collectionName).Document(email);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                var data = snapshot.ToDictionary();
                return new User(
                    id: data["Id"].ToString(),
                    email: data["Email"].ToString(),
                    passwordHash: data["PasswordHash"].ToString()
                );
            }

            return null;
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            DocumentReference docRef = _firestoreDb.Collection(_collectionName).Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                var data = snapshot.ToDictionary();
                return new User(
                    id: data["Id"].ToString(),
                    email: data["Email"].ToString(),
                    passwordHash: data["PasswordHash"].ToString()
                );
            }

            return null;
        }

        public async Task UpdateAsync(User user)
        {
            DocumentReference docRef = _firestoreDb.Collection(_collectionName).Document(user.Id);
            await docRef.SetAsync(new
            {
                user.Id,
                user.Email,
                user.PasswordHash
            });
        }
    }
}
