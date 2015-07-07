using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{

    public partial class PersHalladaCantXDeptoXFechaDB
    {
        #region "Public Methods"





        public static PersHalladaCantXDeptoXFechaList GetList(string fechaDesde, string fechaHasta)
        {
            PersHalladaCantXDeptoXFechaList tempList = new PersHalladaCantXDeptoXFechaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasCantXDeptoXFecha", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    myCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);

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


        private static PersHalladaCantXDeptoXFecha FillDataRecord(IDataRecord myDataRecord)
        {
            PersHalladaCantXDeptoXFecha myPersHalladaCantXDeptoXFecha = new PersHalladaCantXDeptoXFecha();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("departamento")))
            {
                myPersHalladaCantXDeptoXFecha.departamento = myDataRecord.GetString(myDataRecord.GetOrdinal("departamento"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("cantidad")))
            {
                myPersHalladaCantXDeptoXFecha.cantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("cantidad"));
            }
            return myPersHalladaCantXDeptoXFecha;
        }
    }

}
