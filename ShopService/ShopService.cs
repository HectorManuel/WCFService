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

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string InsertData(int controlNumber, string paymentResponse, string description)
        {
            SqlConnection con = new SqlConnection(@"Data Source = GMTWKS13\GMTWKS13DB;Initial Catalog =CRIMShopManagement;User ID=User Name;Password=Password");
            SqlCommand cmd = new SqlCommand("SP_InsertProc", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("", controlNumber);
            cmd.Parameters.AddWithValue("", paymentResponse);
            cmd.Parameters.AddWithValue("", description);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return "Success";
        }
    }
}
