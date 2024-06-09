using baltaio_DapperEndityframework.Models;
using baltaio_DapperEndityframework.Repositories;
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

            SqlConnection sqlConnection = new SqlConnection(_connection);
            sqlConnection.Open();
            ReadUsers(sqlConnection);
            ReadRole(sqlConnection);
            sqlConnection.Close();

        }

        #region User
        public static void ReadUsers(SqlConnection sqlConnection)
        {
            var users = new BaseRepository<User>(sqlConnection).GetAll();

            foreach (var user in users) {
                Console.WriteLine(user.Name);
            }
  
        }
        public static void ReadUser(int id,SqlConnection sqlConnection)
        {
            var user = new UserRepository(sqlConnection).Get(id);
            Console.WriteLine(user.Name);

        }
        public static void CreateUser(User usuario, SqlConnection sqlConnection)
        {
            var id = new UserRepository(sqlConnection).Insert(usuario);
            var user = new UserRepository(sqlConnection).Get(id);

            Console.WriteLine($"Usuário {user.Name} foi criado");

        }
        public static void UpdateUser(User usuario, SqlConnection sqlConnection)
        {
            var hasUpdate = new UserRepository(sqlConnection).Update(usuario);

            var user = new UserRepository(sqlConnection).Get(usuario.Id);

            Console.WriteLine($"Usuário {user.Name} foi atualizado");

        }
        public static void DeleteUser(User usuario, SqlConnection sqlConnection)
        {

            var user = new UserRepository(sqlConnection).Get(usuario.Id);

            var id = new UserRepository(sqlConnection).Delete(user);

            Console.WriteLine($"Usuário {user.Name} excluído");

        }

        #endregion

        #region Role 
        public static void ReadRole(SqlConnection sqlConnection)
        {
            var roles = new BaseRepository<Role>(sqlConnection).GetAll();

            foreach (var role in roles)
            {
                Console.WriteLine(role.Name);
            }

        }
        #endregion
    }
}