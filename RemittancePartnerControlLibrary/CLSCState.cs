using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TransFastControlLibrary
{
    internal class CLSCState
    {
        private string _code;
        private string _name;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        internal static List<CLSCState> GetList(string countryCodeISO2)
        {
            using (SqlConnection connection = new SqlConnection(RemittancePartnerConfiguration.DBRemittanceConnectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.PROC_GetStateList", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CountryCode", countryCodeISO2);

                    connection.Open();
                    List<CLSCState> items = new List<CLSCState>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            return items;
                        }

                        while (reader.Read())
                        {
                            CLSCState item = new CLSCState();
                            item._code = reader["fldStateCode"].ToString();
                            item._name = reader["fldStateName"].ToString();
                            items.Add(item);
                        }
                    }

                    return items;
                }
            }
        }
    }
}
