using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
    /// <summary>
    /// The PBParametrosGeneralesDB class is responsible for interacting with the database to retrieve and store information
    /// about PBParametrosGenerales objects.
    /// </summary>
    public partial class PBParametrosGeneralesDB
    {
        #region "Public Methods"






        /// <summary>
        /// Returns a list with PBParametrosGenerales objects.
        /// </summary>
        /// <returns>A generics List with the PBParametrosGenerales objects.</returns>
        public static PBParametrosGeneralesList GetList()
        {
            PBParametrosGeneralesList tempList = new PBParametrosGeneralesList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PBParametrosGeneralesSelectList", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
            }
            return tempList;
        }


        #endregion


        /// <summary>
        /// Initializes a new instance of the PBParametrosGenerales class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static PBParametrosGenerales FillDataRecord(IDataRecord myDataRecord)
        {
            PBParametrosGenerales myPBParametrosGenerales = new PBParametrosGenerales();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("cantTopeDeBusquedas")))
            {
                myPBParametrosGenerales.CantTopeDeBusquedas = myDataRecord.GetInt32(myDataRecord.GetOrdinal("cantTopeDeBusquedas"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("cantMaxDiasBusquedaActiva")))
            {
                myPBParametrosGenerales.CantMaxDiasBusquedaActiva = myDataRecord.GetInt32(myDataRecord.GetOrdinal("cantMaxDiasBusquedaActiva"));
            }
            return myPBParametrosGenerales;
        }
    }
}


     
