using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal
{
 
    public partial class DelitosCantXDependenciaXFechaDB
    {
        #region "Public Methods"





        public static DelitosCantXDependenciaXFechaList GetList(int claseDelito, string fechaDesde, string fechaHasta, int idDepto)
        {
            DelitosCantXDependenciaXFechaList tempList = new DelitosCantXDependenciaXFechaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosCantXDependenciaXFecha", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@claseDelito", claseDelito);
                    myCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    myCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                    myCommand.Parameters.AddWithValue("@IdDepartamento", idDepto);

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


        private static DelitosCantXDependenciaXFecha FillDataRecord(IDataRecord myDataRecord)
        {
            DelitosCantXDependenciaXFecha myDelitosCantXDependenciaXFecha = new DelitosCantXDependenciaXFecha();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
            {
                myDelitosCantXDependenciaXFecha.dependencia = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("cantidad")))
            {
                myDelitosCantXDependenciaXFecha.cantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("cantidad"));
            }
            return myDelitosCantXDependenciaXFecha;
        }
    }

}
