﻿using Blazor_Admin.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Blazor_Admin.Data.Services
{
    public class RoleService : IRoleService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public RoleService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Role>> GetRoles()
        {
            List<Role> roles = new List<Role>();

            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                {
                    const string query = "select * from dbo.AspNetRoles";
                    SqlCommand cmd = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text
                    };

                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                    while (rdr.Read())
                    {
                        Role role = new Role
                        {
                            Id = Guid.Parse(rdr["Id"].ToString()),
                            Name = rdr["Name"].ToString(),
                            NormalizedName = rdr["NormalizedName"].ToString(),
                            ConcurrencyStamp = Guid.Parse(rdr["ConcurrencyStamp"].ToString())
                        };
                        roles.Add(role);
                    }
                    cmd.Dispose();
                }
                return roles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Role>> GetRolesUser(Guid id)
        {
            List<Role> userRoles = new List<Role>();
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                {
                    const string query = "select r.Name , r.NormalizedName " +
                                         "FROM AspNetRoles as r, AspNetUsers as u, AspNetUserRoles as ur " +
                                         "WHERE ur.UserId = @Id " +
                                         "AND ur.RoleId = r.Id " +
                                         "AND u.Id = ur.UserId";

                    SqlCommand cmd = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text,
                    };

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                    while (rdr.Read())
                    {
                        Role userRole = new Role
                        {
                            Name = rdr["Name"].ToString(),
                            NormalizedName = rdr["NormalizedName"].ToString()
                        };
                        userRoles.Add(userRole);
                    }
                    cmd.Dispose();
                }
                return userRoles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificaSeRoleExiste(Role role)
        {
            bool flag = false;
            using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
            {
                const string query = "Select Name from dbo.AspNetRoles Where Name=@Name";

                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text,
                };

                cmd.Parameters.AddWithValue("@Name", role.Name);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                con.Close();
                cmd.Dispose();
            }
            return flag;
        }

        public async Task<bool> CreateRole(Role role)
        {
            if (!VerificaSeRoleExiste(role))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                    {
                        const string query = "insert into dbo.AspNetRoles " +
                            "(Id,Name,NormalizedName,ConcurrencyStamp) " +
                            "values(@Id,@Name,@NormalizedName,@ConcurrencyStamp)";

                        SqlCommand cmd = new SqlCommand(query, con)
                        {
                            CommandType = CommandType.Text,
                        };

                        cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@Name", role.Name);
                        cmd.Parameters.AddWithValue("@NormalizedName", role.Name.ToUpper());
                        cmd.Parameters.AddWithValue("@ConcurrencyStamp", Guid.NewGuid());

                        con.Open();
                        await cmd.ExecuteNonQueryAsync();

                        con.Close();
                        cmd.Dispose();
                    }
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<Role> GetRole(Guid id)
        {
            Role role = new Role();
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                {
                    const string query = "select * from dbo.AspNetRoles where Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text,
                    };

                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                    if (rdr.Read())
                    {
                        role.Id = Guid.Parse(rdr["Id"].ToString());
                        role.Name = rdr["Name"].ToString();
                        role.NormalizedName = rdr["NormalizedName"].ToString();
                        role.ConcurrencyStamp = Guid.Parse(rdr["ConcurrencyStamp"].ToString());
                    }
                    con.Close();
                    cmd.Dispose();
                }
                return role;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> EditRole(Guid id, Role role)
        {
            if (!VerificaSeRoleExiste(role))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                    {
                        const string query =
                        "update dbo.AspNetRoles set Name = @Name, " +
                        "NormalizedName = @NormalizedName, " +
                        "ConcurrencyStamp = @ConcurrencyStamp Where Id=@Id";

                        SqlCommand cmd = new SqlCommand(query, con)
                        {
                            CommandType = CommandType.Text,
                        };

                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", role.Name);
                        cmd.Parameters.AddWithValue("@NormalizedName", role.Name.ToUpper());
                        cmd.Parameters.AddWithValue("@ConcurrencyStamp", role.ConcurrencyStamp);

                        con.Open();
                        await cmd.ExecuteNonQueryAsync();
                        con.Close();
                        cmd.Dispose();
                    }
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteRole(Guid id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                {
                    const string query = "delete from dbo.AspNetRoles where Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, con)
                    {
                        CommandType = CommandType.Text,
                    };

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();

                    con.Close();
                    cmd.Dispose();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
