using baltaio_DapperEndityframework.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baltaio_DapperEndityframework.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection sqlConnection;

        public UserRepository(SqlConnection _sqlConnection) {
            sqlConnection = _sqlConnection;
        }

        public IEnumerable<User> GetAll()
            => sqlConnection.GetAll<User>();

        public User  Get(long id)
            => sqlConnection.Get<User>(id);

        public long Insert(User usuario)
        {
            usuario.Id = 0;
            return sqlConnection.Insert<User>(usuario);
        }

        public bool Update(User usuario)
        { 
            if(usuario.Id != 0)
                return sqlConnection.Update<User>(usuario);
            return false;
        }


        public bool Delete(User usuario)
        {   
            if(usuario.Id != 0 )
                return sqlConnection.Delete<User>(usuario);
            return false;
        } 

    }
}
