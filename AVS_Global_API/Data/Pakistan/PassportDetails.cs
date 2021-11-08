using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Data.Pakistan
{
    public class PassportDetails
    {
        public static string InsertPassportDetails(Entities.enpkSavePassportData model)
        {
            using var context = new Models.AVS_DBContext();
            string msjeOut = string.Empty;
            try
            {

                var parameters = new[] {
                    new SqlParameter("@IdForm", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.IdForm
                    },
                    new SqlParameter("@IdTypePass", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.IdTypePass
                    },
                    new SqlParameter("@BitTravelDocs", SqlDbType.Bit)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.TravelDocs
                    },
                    new SqlParameter("@PassportNum", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.PassportNumber
                    },
                    new SqlParameter("@PlaceIssue", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.PlaceOfIssue
                    },
                    new SqlParameter("@DateIssue", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.DateOfIssue
                    },
                    new SqlParameter("@DateExpiry", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.DateOfExpiry
                    },
                    new SqlParameter("@IssuingAuth", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.IssuingAuth
                    }

                    };

                context.Database.ExecuteSqlRaw(
                  "exec sp_pk_SavePassportDetails @IdForm, @IdTypePass, @BitTravelDocs, @PassportNum, @PlaceIssue, @DateIssue,  @DateExpiry, @IssuingAuth", parameters:
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
