using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace AVS_Global_API.Data.Pakistan
{
    public class AppDetails
    {
        public static string InsertAppDetails(Entities.enpkSaveAppDetails model)
        {
            using var context = new Models.AVS_DBContext();
            string msjeOut = string.Empty;
            try
            {


                if (model.natPresent == null)
                {
                    model.natPresent = DBNull.Value.ToString();
                }

                if (model.natPrevious == null)
                {
                    model.natPrevious = DBNull.Value.ToString();
                }

                if (model.natDual == null)
                {
                    model.natDual = DBNull.Value.ToString();
                }


                var parameters = new[] {
                    new SqlParameter("@IdForm", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idForm
                    },
                    new SqlParameter("@Name", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.name
                    },
                    new SqlParameter("@MidName", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.middleName
                    },
                    new SqlParameter("@LasName", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.lastName
                    },
                    new SqlParameter("@DateBirth", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.dateBirth
                    },
                    new SqlParameter("@CityBirth", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.cityBirth
                    },
                    new SqlParameter("@IdCountry", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idCountry
                    },
                    new SqlParameter("@BitSex", SqlDbType.Bit)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.bitSex
                    },
                    new SqlParameter("@BitMarital", SqlDbType.Bit)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.bitMarital
                    },
                    new SqlParameter("@BloodGroup", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.bloodGroup
                    },
                    new SqlParameter("@IdMark", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idMark
                    },
                    new SqlParameter("@NativeLan", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.natLanguage
                    },
                    new SqlParameter("@Religion", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.religion
                    },
                    new SqlParameter("@NatPresent", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.natPresent
                    },
                    new SqlParameter("@NatPrevious", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.natPrevious
                    },
                    new SqlParameter("@NatDual", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.natDual
                    }

                    };

                context.Database.ExecuteSqlRaw(
                  "exec sp_pk_SaveApplicantsDetails @IdForm, @Name, @MidName, @LasName, @DateBirth, @CityBirth,  @IdCountry, @BitSex, " +
                  "@BitMarital, @BloodGroup, @IdMark, @NativeLan, @Religion, @NatPresent, @NatPrevious, @NatDual ", parameters:
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
