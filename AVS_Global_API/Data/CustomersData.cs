using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Data
{
    public class CustomersData
    {
        public static string InsertCustomer(int IdCountry, string Mail, string Pass)
        {
            using var context = new Models.AVS_DBContext();
            string msjeOut = string.Empty;
            try
            {
                
                var parameters = new[] {
                    new SqlParameter("@IdCountry", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = IdCountry
                    },
                    new SqlParameter("@Mail", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = Mail
                    },
                    new SqlParameter("@Pass", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = Pass
                    },
                    new SqlParameter("@Msje", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Output,
                      Value = msjeOut
                    }

                    };

                context.Database.ExecuteSqlRaw(
                  "exec sp_insertCustomer @IdCountry,@Mail,@Pass, @Msje out", parameters:
                  parameters);

                msjeOut = "OK";

            }
            catch (Exception ex)
            {
                msjeOut = ex.Message;
            }

            return msjeOut;
        }
    }
}
