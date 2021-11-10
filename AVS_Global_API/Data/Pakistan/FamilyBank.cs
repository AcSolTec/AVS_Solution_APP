using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Data.Pakistan
{
    public class FamilyBank
    {
        public static string InsertFamilyBankData(Entities.enpkSaveFamilyBank model)
        {
            using var context = new Models.AVS_DBContext();
            string msjeOut = string.Empty;
            try
            {


                if (model.bankName == null)
                {
                    model.bankName = DBNull.Value.ToString();
                }
                if (model.branch == null)
                {
                    model.branch = DBNull.Value.ToString();
                }
                if (model.acNumber == null)
                {
                    model.acNumber = DBNull.Value.ToString();
                }
                if (model.addressBank == null)
                {
                    model.addressBank = DBNull.Value.ToString();
                }
                if (model.verieferDet == null)
                {
                    model.verieferDet = DBNull.Value.ToString();
                }


                var parameters = new[] {
                    new SqlParameter("@IdForm", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idForm
                    },
                    new SqlParameter("@nameBank", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.bankName
                    },
                    new SqlParameter("@branch", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.branch
                    },
                    new SqlParameter("@acNumber", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.acNumber
                    },
                    new SqlParameter("@address", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.addressBank
                    },
                    new SqlParameter("@veriefer", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.verieferDet
                    }

                    };

                context.Database.ExecuteSqlRaw(
                  "exec sp_pk_SaveFamilyBank @IdForm, @nameBank, @branch, @acNumber, @address, @veriefer ", parameters:
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
