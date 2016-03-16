using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ShopService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ShopService : IShopService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string InsertData(int controlNumber, string paymentResponse, string description)
        {
            //SqlConnection con = new SqlConnection(@"Data Source = HECTOR_CUSTOMS\MYOWNSQLSERVER;Initial Catalog =CRIMShopManagement;Trusted_Connection=Yes;");
            SqlConnection con = new SqlConnection(@"Data Source = GMTWKS13\GMTWKS13DB;Initial Catalog = CRIMShopManagement;Trusted_Connection=Yes;");
            string queryString = "INSERT into dbo.Orders (ControlNumber,PaymentRespone,Description)" +
                                "VALUES (@controlNumber,@response,@description)";
            SqlCommand cmd = new SqlCommand(queryString, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@controlNumber", controlNumber);
            cmd.Parameters.AddWithValue("@response", paymentResponse);
            cmd.Parameters.AddWithValue("@description", description);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return "Success";
        }
    }
}
