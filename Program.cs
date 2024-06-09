using baltaio_DapperEndityframework.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace baltaio_DapperEndityframework
{
    internal class Program
    {
        private const string _connection = @"Server=localhost,1433;Database=Blog;User ID=SA;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //ReadUsers();
            //ReadUser();
            //CreateUser(new User { 
            //    Name = "Felipe Silva",
            //    Email = "Felip.silva@gmail.com",
            //    PasswordHash = "asdf",
            //    Bio = "Professor",
            //    Image = "Textando",
            //    Slug = "Felipe-Silva"
            //}); 
            //UpdateUser(new User
            //{
            //    Id = 3,
            //    Name = "Lucas Silva",
            //    Email = "Felip.silva@gmail.com",
            //    PasswordHash = "asdf",
            //    Bio = "Professor",
            //    Image = "Textando",
            //    Slug = "Felipe-Silva"
            //});
            DeleteUser(new User { Id = 3 });

        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(_connection)) {
                var users = connection.GetAll<User>();

                foreach (var user in users) {
                    Console.WriteLine(user.Name);
                }

            }        
        }
        public static void ReadUser()
        {
            using (var connection = new SqlConnection(_connection))
            {
                var user = connection.Get<User>(1);

                Console.WriteLine(user.Name);

            }
        }


        public static void CreateUser(User usuario)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var id = connection.Insert<User>(usuario);

                var user = connection.Get<User>(id);

                Console.WriteLine(user.Name);

            }
        }
        public static void UpdateUser(User usuario)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var id = connection.Update<User>(usuario);

                var user = connection.Get<User>(usuario.Id);

                Console.WriteLine(user.Name);

            }
        }
        public static void DeleteUser(User usuario)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var user = connection.Get<User>(usuario.Id);

                var id = connection.Delete<User>(user);

                Console.WriteLine($"Usuário {user.Name} excluído");

            }
        }
    }
}