using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TransFastControlLibrary
{
    internal class CLSCCountry
    {
        private string _codeISO2;
        private string _codeISO3;
        private string _name;
        private string _phoneCode;

        public string CodeISO2
        {
            get { return _codeISO2; }
            set { _codeISO2 = value; }
        }
        
        public string CodeISO3
        {
            get { return _codeISO3; }
            set { _codeISO3 = value; }
        }
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string PhoneCode
        {
            get { return _phoneCode; }
            set { _phoneCode = value; }
        }

        internal static List<CLSCCountry> GetList()
        {
            using (SqlConnection connection = new SqlConnection(RemittancePartnerConfiguration.DBRemittanceConnectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.PROC_GetCountryList", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    List<CLSCCountry> items = new List<CLSCCountry>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            return items;
                        }

                        while (reader.Read())
                        {
                            CLSCCountry item = new CLSCCountry();
                            item._codeISO2 = reader["fldCountryCodeISO2"].ToString();
                            item._codeISO3 = reader["fldCountryCodeISO3"].ToString();
                            item._name = reader["fldCountryName"].ToString();
                            item._phoneCode = reader["fldCountryPhoneCode"].ToString();
                            items.Add(item);
                        }
                    }

                    return items;
                }
            }
        }
    }
}
