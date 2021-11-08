using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Data.Pakistan
{
    public class ConctactDetails
    {
        public static string InsertConctactDetails(Entities.enpkSaveConctactDetails model)
        {
            using var context = new Models.AVS_DBContext();
            string msjeOut = string.Empty;
            try
            {


                if (model.nameSpon == null)
                {
                    model.nameSpon = DBNull.Value.ToString();
                }
                if (model.addSponsor == null)
                {
                    model.addSponsor = DBNull.Value.ToString();
                }
                
                if (model.telHomeSpon == null)
                {
                    model.telHomeSpon = DBNull.Value.ToString();
                }
                if (model.telWorkSpon == null)
                {
                    model.telWorkSpon = DBNull.Value.ToString();
                }
                if (model.telCellSpon == null)
                {
                    model.telCellSpon = DBNull.Value.ToString();
                }
                if (model.citySpon == null)
                {
                    model.citySpon = DBNull.Value.ToString();
                }
                if (model.zipCodeSpon == null)
                {
                    model.zipCodeSpon = DBNull.Value.ToString();
                }

                if (model.nameSponB == null)
                {
                    model.nameSponB = DBNull.Value.ToString();
                }
                if (model.addSponsorB == null)
                {
                    model.addSponsorB = DBNull.Value.ToString();
                }

                if (model.telHomeSponB == null)
                {
                    model.telHomeSponB = DBNull.Value.ToString();
                }

                if (model.telWorkSponB == null)
                {
                    model.telWorkSponB = DBNull.Value.ToString();
                }
                if (model.telCellSponB == null)
                {
                    model.telCellSponB = DBNull.Value.ToString();
                }
                if (model.citySponB == null)
                {
                    model.citySponB = DBNull.Value.ToString();
                }
                if (model.zipCodeSponB == null)
                {
                    model.zipCodeSponB = DBNull.Value.ToString();
                }

                var parameters = new[] {
                    new SqlParameter("@IdForm", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idForm
                    },
                    new SqlParameter("@IdCountry", SqlDbType.Int)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.idCountry
                    },
                    new SqlParameter("@TelHome", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telHome
                    },
                    new SqlParameter("@TelWork", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telWork
                    },
                    new SqlParameter("@TelCell", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telCell
                    },
                    new SqlParameter("@Email", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.email
                    },
                    new SqlParameter("@TelHomeb", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telHomeb
                    },
                    new SqlParameter("@TelWorkb", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telWorkb
                    },
                    new SqlParameter("@TelCellb", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telCellb
                    },
                    new SqlParameter("@InPaikistan", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.inPakistan
                    },
                    new SqlParameter("@BitSponsor", SqlDbType.Bit)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.bitSponsor
                    },
                    new SqlParameter("@NameSponsor", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.nameSpon
                    },
                    new SqlParameter("@AddrSponsor", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.addSponsor
                    },
                   
                    new SqlParameter("@TelHomeSpon", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telHomeSpon
                    },
                    new SqlParameter("@TelWorkSpon", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telWorkSpon
                    },
                     new SqlParameter("@TelCellSpon", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telCellSpon
                    },
                    new SqlParameter("@CitySpon", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.citySpon
                    },
                    new SqlParameter("@ZipCodeSpon", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.zipCodeSpon
                    },
                    new SqlParameter("@BitSponsorB", SqlDbType.Bit)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.bitSponsorB
                    },
                    new SqlParameter("@NameSponsorB", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.nameSponB
                    },
                    new SqlParameter("@AddrSponsorB", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.addSponsorB
                    },
                    new SqlParameter("@TelHomeSponB", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telHomeSponB
                    },
                    new SqlParameter("@TelWorkSponB", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telWorkSponB
                    },
                     new SqlParameter("@TelCellSponB", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.telCellSponB
                    },
                    new SqlParameter("@CitySponB", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.citySponB
                    },
                    new SqlParameter("@ZipCodeSponB", SqlDbType.VarChar)
                    {
                      Direction = ParameterDirection.Input,
                      Value = model.zipCodeSponB
                    }

                    };

                context.Database.ExecuteSqlRaw(
                  "exec sp_pk_SaveContactDetails @IdForm, @IdCountry, @TelHome, @TelWork, @TelCell, @Email, @TelHomeb, @TelWorkb, @TelCellb, @InPaikistan, @BitSponsor," +
                  "@NameSponsor, @AddrSponsor,  @TelHomeSpon, @TelWorkSpon, @TelCellSpon, @CitySpon, @ZipCodeSpon, " +
                  "@BitSponsorB, @NameSponsorB, @AddrSponsorB,  @TelHomeSponB, @TelWorkSponB, @TelCellSponB, @CitySponB, @ZipCodeSponB", parameters:
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
