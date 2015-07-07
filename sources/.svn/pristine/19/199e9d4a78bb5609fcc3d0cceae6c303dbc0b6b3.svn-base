using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{

    public partial class PersHalladaCantXDependenciaXFechaDB
    {
        #region "Public Methods"





        public static PersHalladaCantXDependenciaXFechaList GetList(string fechaDesde, string fechaHasta, int idDepartamento)
        {
            PersHalladaCantXDependenciaXFechaList tempList = new PersHalladaCantXDependenciaXFechaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasCantXDependenciaXFecha", myConnection))
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


        private static PersHalladaCantXDependenciaXFecha FillDataRecord(IDataRecord myDataRecord)
        {
            PersHalladaCantXDependenciaXFecha myPersHalladaCantXDependenciaXFecha = new PersHalladaCantXDependenciaXFecha();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
            {
                myPersHalladaCantXDependenciaXFecha.dependencia = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("cantidad")))
            {
                myPersHalladaCantXDependenciaXFecha.cantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("cantidad"));
            }
            return myPersHalladaCantXDependenciaXFecha;
        }
    }

}
