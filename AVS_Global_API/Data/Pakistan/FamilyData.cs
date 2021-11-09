using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Data.Pakistan
{
    public class FamilyData
    {
        public static string InsertFamilyDetails(Entities.enpkSaveFamilyData model)
        {
            using var context = new Models.AVS_DBContext();
            string msjeOut = string.Empty;
            try
            {


                if (model.SpouseName == null)
                {
                    model.SpouseName = DBNull.Value.ToString();
                }
                if (model.DateBirth == null)
                {
                    model.DateBirth = DBNull.Value.ToString();
                }
                if (model.PlaceBirth == null)
                {
                    model.PlaceBirth = DBNull.Value.ToString();
                }
                if (model.Profesion == null)
                {
                    model.Profesion = DBNull.Value.ToString();
                }


                if (model.NameEmployerSpouse == null)
                {
                    model.NameEmployerSpouse = DBNull.Value.ToString();
                }
                if (model.AddressEmployerSpouse == null)
                {
                    model.AddressEmployerSpouse = DBNull.Value.ToString();
                }
                if (model.TelEmployerSpouse == null)
                {
                    model.TelEmployerSpouse = DBNull.Value.ToString();
                }



                var parameters = new[] {
                    new SqlParameter("@IdForm", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.IdForm
                    },
                    new SqlParameter("@NMother", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.Nmother
                    },
                    new SqlParameter("@NPather", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.Npather
                    },
                    new SqlParameter("@IdNatMother", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.IdNatMother
                    },
                    new SqlParameter("@IdNatPather", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.IdNatFather
                    },
                    new SqlParameter("@SpouseName", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.SpouseName
                    },
                    new SqlParameter("@IdNatSpouse", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.IdNatSpouse
                    },
                    new SqlParameter("@DateBirth", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.DateBirth
                    },
                    new SqlParameter("@PlaceBirth", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.PlaceBirth
                    },
                    new SqlParameter("@Profesion", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.Profesion
                    },
                    new SqlParameter("@BitChildrens", SqlDbType.Bit)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.BitChildrens
                    },
                    new SqlParameter("@NameEmpSpouse", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.NameEmployerSpouse
                    },
                    new SqlParameter("@AddressEmoSpo", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.AddressEmployerSpouse
                    },
                    new SqlParameter("@TelEmpSpouse", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.TelEmployerSpouse
                    }

                    };

                context.Database.ExecuteSqlRaw(
                  "exec sp_pk_SaveFamilyDetails @IdForm, @NMother, @NPather, @IdNatMother, @IdNatPather, @SpouseName, @IdNatSpouse, " +
                  "@DateBirth, @PlaceBirth, @Profesion, @BitChildrens, @NameEmpSpouse, @AddressEmoSpo, @TelEmpSpouse ", parameters:
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
