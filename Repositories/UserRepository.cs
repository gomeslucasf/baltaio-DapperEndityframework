using baltaio_DapperEndityframework.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baltaio_DapperEndityframework.Repositories
{
    internal class UserRepository : BaseRepository<User>
    {
        private readonly SqlConnection _sqlConnection;
        public UserRepository(SqlConnection sqlConnection) : base(sqlConnection)
            => _sqlConnection = sqlConnection;


        public List<User> getUsersWithRoles() {
            var query = @"
                    USE BLOG 
                    SELECT 
                        [USER].*,
                        [Role].*
                     FROM [USER] 
                        LEFT JOIN [UserRole] ON [USER].[Id] = [UserRole].[UserId]
                        LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
                ";

            List<User> users = new List<User>();

            _sqlConnection.Query<User,Role,User>(query, 
            (user,role) => {

                var us = users.FirstOrDefault(u => u.Id == user.Id);

                if (us is null)
                {
                    us = user;

                    if(role is not null)
                        us.roles.Add(role);

                    users.Add(us);
                }
                else
                    if (role is not null)
                        us.roles.Add(role);


                return user;
            
            },splitOn: "Id");

        
        
            return users;
        }
    }
}
