using baltaio_DapperEndityframework.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace baltaio_DapperEndityframework.Repositories
{
    internal class BaseRepository<T> where T : class
    {

        private readonly SqlConnection _sqlConnection;
        public BaseRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public IEnumerable<T> GetAll()
           => _sqlConnection.GetAll<T>();

        public T Get(long id)
            => _sqlConnection.Get<T>(id);

        public long Insert(T model)
            => _sqlConnection.Insert<T>(model);

        public bool Update(T model)
            =>  _sqlConnection.Update<T>(model);


        public bool Delete(T model)
            => _sqlConnection.Delete<T>(model);
            
    }
}
