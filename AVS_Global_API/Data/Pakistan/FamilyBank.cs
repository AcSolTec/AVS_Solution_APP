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


                if (model.nameBank == null)
                {
                    model.nameBank = DBNull.Value.ToString();
                }
                if (model.branch == null)
                {
                    model.branch = DBNull.Value.ToString();
                }
                if (model.acNumber == null)
                {
                    model.acNumber = DBNull.Value.ToString();
                }
                if (model.address == null)
                {
                    model.address = DBNull.Value.ToString();
                }
                if (model.verifierDetails == null)
                {
                    model.verifierDetails = DBNull.Value.ToString();
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
                      Value = model.nameBank
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
                      Value = model.address
                    },
                    new SqlParameter("@veriefer", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.verifierDetails
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
