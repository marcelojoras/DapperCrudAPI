using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUDAPI.Controllers.Model
{
    public class CityRepository
    {
        private string connectionString;

        public CityRepository()
        {
            connectionString = @"Persist Security Info=False;User ID=sa;password=123;Initial Catalog=DAPPERDB; Data Source=ASHRAFULDESKTOP\SQL2014;Connection Timeout=100000";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(City city)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Citys (Name, Uf) VALUES(@Name, @Uf)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, city);
            }
        }

        public IEnumerable<City> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Citys";
                dbConnection.Open();
                return dbConnection.Query<City>(sQuery);
            }
        }

        public City GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Citys WHERE CityId=@Id";
                dbConnection.Open();
                return dbConnection.Query<City>(sQuery, new { Id=id}).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE * FROM Citys WHERE CityId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(City city)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Citys SET Name=@Name,Uf=@Uf WHERE CityId=@CityId";
                dbConnection.Open();
                dbConnection.Query(sQuery, city);
            }
        }
    }
}
