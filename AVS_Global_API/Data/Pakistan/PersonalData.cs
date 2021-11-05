using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Data.Pakistan
{
    public class PersonalData
    {
        public static string InsertPeronalDetails(Entities.enpkSavePersonalData model)
        {
            using var context = new Models.AVS_DBContext();
            string msjeOut = string.Empty;
            try
            {

                var parameters = new[] {
                    new SqlParameter("@IdForm", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idForm
                    },
                    new SqlParameter("@IdVisaAp", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idVisaAp
                    },
                    new SqlParameter("@IdPurpose", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idPurpose
                    },
                    new SqlParameter("@durationStay", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.durationStay
                    },
                    new SqlParameter("@IdVisasTime", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idVisasTime
                    },
                    new SqlParameter("@IdTypeVisa", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idTypeVisa
                    },
                    new SqlParameter("@IdPortsIn", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idPortIn
                    },
                    new SqlParameter("@IdPortsOut", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idPortOut
                    },
                    new SqlParameter("@PVPakistan", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.pvPakistan
                    },
                    new SqlParameter("@DOfProfesion", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.dOfProfesion
                    }

                    };

                context.Database.ExecuteSqlRaw(
                  "exec sp_pk_SavePersonDetails @IdForm, @IdVisaAp, @IdPurpose, @durationStay, @IdVisasTime, @IdTypeVisa,  @IdPortsIn, @IdPortsOut, " +
                  "@PVPakistan, @DOfProfesion ", parameters:
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
