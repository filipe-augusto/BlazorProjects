using Blazor_Admin.Data;
using Blazor_Admin.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Admin.Services
{
    public class UserService : IUserService
    {
        private SqlConnectionConfiguration _configuration;

        public UserService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> DeleteUser(Guid id)
        {

            try
            {
                User user = new User();
                using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                {
                    const string query = "delete from dbo.AspNetUsers where Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text,
                    };
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                int result =  await cmd.ExecuteNonQueryAsync();

                    cmd.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<User> GetUser(Guid id)
        {
            try
            {
                User user = new User();
                using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                {
                    const string query = "select * from dbo.AspNetUsers where Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);
                        con.Open();

                        using(SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            if (rdr.Read())
                            {
                                user.Id = Guid.Parse(rdr["Id"].ToString());
                                user.UserName = rdr["UserName"].ToString();
                                user.Email = rdr["Email"].ToString();
                            }
                        }

                    }
                }
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                List<User> users = new List<User>();
                using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                {
                    const string query = "select * from dbo.AspNetUsers";
                    SqlCommand cmd = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text
                    };
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        User usuario = new User
                        {
                            Id = Guid.Parse(rdr["Id"].ToString()),
                            UserName = rdr["UserName"].ToString(),
                            Email = rdr["Email"].ToString(),
                            RoleId = new Guid()
                        };
                        users.Add(usuario);
                    }
                    cmd.Dispose();
                }
                return users;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> UpdateUserRole(Guid id, User user)
        {
            try
            {
          //      User user = new User();
                using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                {
                    const string query = "insert into dbo.AspNetUsersRoles (UserId,RoleId) values (@UserId, @RoleId)";


                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserId", id);
                        cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
                        con.Open();
                        int result = await cmd.ExecuteNonQueryAsync();
                    }

                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
