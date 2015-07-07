using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal
{
 
    public partial class DelitosCantXDeptoXFechaDB
    {
        #region "Public Methods"





        public static DelitosCantXDeptoXFechaList GetList(int claseDelito, string fechaDesde, string fechaHasta)
        {
            DelitosCantXDeptoXFechaList tempList = new DelitosCantXDeptoXFechaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosCantXDeptoXFecha", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@claseDelito", claseDelito);
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


        private static DelitosCantXDeptoXFecha FillDataRecord(IDataRecord myDataRecord)
        {
            DelitosCantXDeptoXFecha myDelitosCantXDeptoXFecha = new DelitosCantXDeptoXFecha();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("departamento")))
            {
                myDelitosCantXDeptoXFecha.departamento = myDataRecord.GetString(myDataRecord.GetOrdinal("departamento"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("cantidad")))
            {
                myDelitosCantXDeptoXFecha.cantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("cantidad"));
            }
            return myDelitosCantXDeptoXFecha;
        }
    }

}
