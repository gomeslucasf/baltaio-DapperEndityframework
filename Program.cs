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
            ReadUsersWithRole(sqlConnection);
            //ReadRole(sqlConnection);
            //ReadTags(sqlConnection);
            sqlConnection.Close();

        }

        #region User
        public static void ReadUsersWithRole(SqlConnection sqlConnection)
        {
            var users = new UserRepository(sqlConnection).getUsersWithRoles();

            foreach (var user in users) {
                Console.WriteLine(user.Name);
                foreach (var role in user.roles)
                { 
                    Console.WriteLine($" Role: {role.Name}");
                }
            }
  
        }
        public static void ReadUser(int id,SqlConnection sqlConnection)
        {
            var user = new BaseRepository<User>(sqlConnection).Get(id);
            Console.WriteLine(user.Name);

        }
        public static void CreateUser(User usuario, SqlConnection sqlConnection)
        {
            var id = new BaseRepository<User>(sqlConnection).Insert(usuario);
            var user = new BaseRepository<User>(sqlConnection).Get(id);

            Console.WriteLine($"Usuário {user.Name} foi criado");

        }
        public static void UpdateUser(User usuario, SqlConnection sqlConnection)
        {
            var hasUpdate = new BaseRepository<User>(sqlConnection).Update(usuario);

            var user = new BaseRepository<User>(sqlConnection).Get(usuario.Id);

            Console.WriteLine($"Usuário {user.Name} foi atualizado");

        }
        public static void DeleteUser(User usuario, SqlConnection sqlConnection)
        {

            var user = new BaseRepository<User>(sqlConnection).Get(usuario.Id);

            var id = new BaseRepository<User>(sqlConnection).Delete(user);

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

        #region Tags
        public static void ReadTags(SqlConnection sqlConnection)
        {
            var tags = new BaseRepository<Tag>(sqlConnection).GetAll();

            foreach (var tag in tags)
            {
                Console.WriteLine(tag.Name);
            }

        }
        #endregion
    }
}