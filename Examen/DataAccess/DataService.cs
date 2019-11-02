using Examen.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen.DataAccess
{
    public class DataService
    {
        private readonly SqlClient _client;
        private static DataService _DataService;
        private readonly string connectionString = "Data Source = DESKTOP-F4DEC2L\\SQLEXPRESS; initial catalog = clima;integrated security = True";

        private DataService()
        {
            _client = SqlClient.GetSqlClient(connectionString);
        }
        public static DataService GetDataService()
        {
            if (_DataService == null)
            {
                _DataService = new DataService();
            }
            return _DataService;
        }

        public List<User> GetUsers()
        {
            var result = new List<User>();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.GetConnection(),
                        CommandText = "getusers",
                        CommandType = CommandType.StoredProcedure
                    };

                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var amigo = new User
                        {
                            //idPersona = Convert.ToInt32(dataReader["idPersona"].ToString()),
                            username = dataReader["Username"].ToString(),
                            email = dataReader["email"].ToString(),
                            password = dataReader["pass"].ToString(),
                        };
                        result.Add(amigo);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                //do something
            }
            finally
            {
                _client.Close();
            }
            return result;
        }

        public User getUser(string username)
        {
            User result = new User();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.GetConnection(),
                        CommandText = "getuser",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@username", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = username
                    };

                    var par2 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);

                    var dataReader = command.ExecuteReader();
                    dataReader.Read();
                    var user = new User
                    {
                        id = Convert.ToInt32(dataReader["idUser"].ToString()),
                        username = dataReader["username"].ToString(),
                        email = dataReader["email"].ToString(),
                        password = dataReader["pass"].ToString(),
                    };
                    result = user;
                }
            }
            catch(Exception e)
            {

            }
            finally
            {
                _client.Close();
            }
            return result;
        }

        public List<string> getCities(int id)
        {
            List<string> cities = new List<string>();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.GetConnection(),
                        CommandText = "getcities",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idUser", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = id
                    };

                    var par2 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);

                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        cities.Add(dataReader["city"].ToString());
                    }
                    
                    
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                _client.Close();
            }
            return cities;
        }

        public bool addCity(int idUser, string city)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.GetConnection(),
                        CommandText = "addcity",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idUser", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idUser
                    };

                    var par2 = new SqlParameter("@city", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = city
                    };

                    var par3 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());

                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }
            return result;
        }

    }
}