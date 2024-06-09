using baltaio_DapperEndityframework.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baltaio_DapperEndityframework.Repositories
{
    public  class RoleRepository
    {

        private readonly SqlConnection _sqlConnection;
        public RoleRepository(SqlConnection sqlConnection) { 
            _sqlConnection = sqlConnection;
        }

        public IEnumerable<Role> GetAll()
           => _sqlConnection.GetAll<Role>();

        public Role Get(long id)
            => _sqlConnection.Get<Role>(id);

        public long Insert(Role role)
        {
            role.Id = 0;
            return _sqlConnection.Insert<Role>(role);
        }

        public bool Update(Role role)
        { 
            if(role.Id != 0 )
                return _sqlConnection.Update<Role>(role);
            return false;
        }

        public bool Delete(Role role)
        { 
            if(role.Id != 0 )
                return _sqlConnection.Delete<Role>(role);
            return false;
        }
    }
}
