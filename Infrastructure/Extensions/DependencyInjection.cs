using Domain.Interfaces;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            string credentialsPath = Path.Combine(AppContext.BaseDirectory, "Configs", "firebase-service-account.json");

            if (!File.Exists(credentialsPath))
            {
                throw new FileNotFoundException($"Credential file missing at: {credentialsPath}");
            }

            // 1. Load the credential once from the file
            GoogleCredential credential;
            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                credential = GoogleCredential.FromStream(stream);
            }

            // 2. Initialize Firebase Admin (for Auth, Messaging, etc.)
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = credential
                });
            }

            // 3. Initialize Firestore using the SAME credential
            // This resolves the "Default credentials not found" error
            var firestoreDb = new FirestoreDbBuilder
            {
                ProjectId = "adhikademy",
                Credential = credential
            }.Build();

            services.AddSingleton(firestoreDb);

            // Repositories
            services.AddScoped<IStudentRepository, FirebaseStudentRepository>();
            services.AddScoped<ICourseRepository, FirebaseCourseRepository>();
            services.AddScoped<IEnrollmentRepository, FirebaseEnrollmentRepository>();

            return services;
        }
    }
}
