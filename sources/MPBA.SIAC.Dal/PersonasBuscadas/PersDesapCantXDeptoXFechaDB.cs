using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
 
    public partial class PersDesapCantXDeptoXFechaDB
    {
        #region "Public Methods"





        public static PersDesapCantXDeptoXFechaList GetList(string fechaDesde, string fechaHasta)
        {
            PersDesapCantXDeptoXFechaList tempList = new PersDesapCantXDeptoXFechaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasCantXDeptoXFecha", myConnection))
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


        private static PersDesapCantXDeptoXFecha FillDataRecord(IDataRecord myDataRecord)
        {
            PersDesapCantXDeptoXFecha myPersDesapCantXDeptoXFecha = new PersDesapCantXDeptoXFecha();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("departamento")))
            {
                myPersDesapCantXDeptoXFecha.departamento = myDataRecord.GetString(myDataRecord.GetOrdinal("departamento"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("cantidad")))
            {
                myPersDesapCantXDeptoXFecha.cantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("cantidad"));
            }
            return myPersDesapCantXDeptoXFecha;
        }
    }

}
