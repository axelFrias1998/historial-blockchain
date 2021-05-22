using System.Collections.Generic;
using System.Threading.Tasks;
using historial_blockchain.Models.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace historial_blockchain.Data
{
    public class HospitalAdministradoresRepository
    {
        private readonly string connectionString;

        public HospitalAdministradoresRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HospitalAdminDTO>> GetAvailableAdmins(string type)
        {
            string cmdText = $"SELECT U.Id, U.Nombre, U.Apellido FROM AspNetUsers U INNER JOIN AspNetUserRoles UR ON UR.UserId = U.Id INNER JOIN AspNetRoles R ON R.Id = UR.RoleId WHERE (U.Id NOT IN (SELECT AdminId FROM HospitalAdministrador)) AND (R.Name = '{type}')";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    var response = new List<HospitalAdminDTO>();
                    await conn.OpenAsync();
                    using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                            response.Add(MapToValue(reader));
                    }
                    return response;
                }
            }
        }

        private HospitalAdminDTO MapToValue(SqlDataReader reader)
        {
            return new HospitalAdminDTO()
            {
                AdminId = reader["Id"].ToString(),
                Nombre = reader["Nombre"].ToString(),
                Apellido = reader["Apellido"].ToString()
            };
        }
    }
}