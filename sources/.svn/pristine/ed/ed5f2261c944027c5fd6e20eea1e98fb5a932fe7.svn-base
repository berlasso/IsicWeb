using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{

    public partial class PersDesapCantXDependenciaXFechaDB
    {
        #region "Public Methods"





        public static PersDesapCantXDependenciaXFechaList GetList(string fechaDesde, string fechaHasta, int idDepartamento)
        {
            PersDesapCantXDependenciaXFechaList tempList = new PersDesapCantXDependenciaXFechaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasCantXDependenciaXFecha", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    myCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                    myCommand.Parameters.AddWithValue("@IdDepartamento", idDepartamento);

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


        private static PersDesapCantXDependenciaXFecha FillDataRecord(IDataRecord myDataRecord)
        {
            PersDesapCantXDependenciaXFecha myPersDesapCantXDependenciaXFecha = new PersDesapCantXDependenciaXFecha();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
            {
                myPersDesapCantXDependenciaXFecha.dependencia = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("cantidad")))
            {
                myPersDesapCantXDependenciaXFecha.cantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("cantidad"));
            }
            return myPersDesapCantXDependenciaXFecha;
        }
    }

}
