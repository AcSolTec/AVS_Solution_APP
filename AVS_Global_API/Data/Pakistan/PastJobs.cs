using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Data.Pakistan
{
    public class PastJobs
    {
        public static string InsertPastJobs(Entities.enpkSavePastJobs model)
        {
            using var context = new Models.AVS_DBContext();
            string msjeOut = string.Empty;
            try
            {


                if (model.DescAddContr == null)
                {
                    model.DescAddContr = DBNull.Value.ToString();
                }

                var parameters = new[] {
                    new SqlParameter("@IdForm", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.IdForm
                    },
                    new SqlParameter("@Designation", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.Designation
                    },
                    new SqlParameter("@Depto", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.Depto
                    },
                    new SqlParameter("@DateStart", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.DateStart
                    },
                    new SqlParameter("@DateFinish", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.DateFinish
                    },
                    new SqlParameter("@Duties", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.Duties
                    },
                    new SqlParameter("@Address", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.Address
                    },
                    new SqlParameter("@Phone", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.Phone
                    },
                    new SqlParameter("@Descp", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.DescAddContr
                    },
                    new SqlParameter("@BitApply", SqlDbType.Bit)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.BitApply
                    },
                    new SqlParameter("@Name", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.Name
                    }

                    };

                context.Database.ExecuteSqlRaw(
                  "exec sp_pk_SavePastJobs @IdForm, @Designation, @Depto, @DateStart, @DateFinish, @Duties,  @Address, @Phone," +
                  "@Descp, @BitApply, @Name ", parameters:
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
