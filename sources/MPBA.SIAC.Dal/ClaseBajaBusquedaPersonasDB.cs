using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;


using MPBA.SIAC.BusinessEntities;

namespace MPBA.SIAC.Dal
{
    // <summary>
    /// The ClaseBajaBusquedaPersonasDB class is responsible for interacting with the database to retrieve and store information
    /// about ClaseBajaBusquedaPersonas objects.
    /// </summary>
    public partial class ClaseBajaBusquedaPersonasDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of ClaseBajaBusquedaPersonas from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the ClaseBajaBusquedaPersonas in the database.</param>
        /// <returns>An ClaseBajaBusquedaPersonas when the id was found in the database, or null otherwise.</returns>
        public static ClaseBajaBusquedaPersonas GetItem(int id)
        {
            ClaseBajaBusquedaPersonas myClaseBajaBusquedaPersonas = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("ClaseBajaBusquedaPersonasSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myClaseBajaBusquedaPersonas = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myClaseBajaBusquedaPersonas;
            }
        }

        /// <summary>
        /// Returns a list with ClaseBajaBusquedaPersonas objects.
        /// </summary>
        /// <returns>A generics List with the ClaseBajaBusquedaPersonas objects.</returns>
        public static ClaseBajaBusquedaPersonasList GetList()
        {
            ClaseBajaBusquedaPersonasList tempList = new ClaseBajaBusquedaPersonasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("ClaseBajaBusquedaPersonasSelectList", myConnection))
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

        /// <summary>
        /// Saves a ClaseBajaBusquedaPersonas in the database.
        /// </summary>
        /// <param name="myClaseBajaBusquedaPersonas">The ClaseBajaBusquedaPersonas instance to save.</param>
        /// <returns>The new id if the ClaseBajaBusquedaPersonas is new in the database or the existing id when an item was updated.</returns>
        public static int Save(ClaseBajaBusquedaPersonas myClaseBajaBusquedaPersonas)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("ClaseBajaBusquedaPersonasInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myClaseBajaBusquedaPersonas.id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myClaseBajaBusquedaPersonas.id);
                    }
                    if (myClaseBajaBusquedaPersonas.Descripcion == null)
                    {
                        myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@descripcion", myClaseBajaBusquedaPersonas.Descripcion);
                    }

                    DbParameter returnValue;
                    returnValue = myCommand.CreateParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    myCommand.Parameters.Add(returnValue);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    result = Convert.ToInt32(returnValue.Value);
                    myConnection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a ClaseBajaBusquedaPersonas from the database.
        /// </summary>
        /// <param name="id">The id of the ClaseBajaBusquedaPersonas to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("ClaseBajaBusquedaPersonasDeleteSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@id", id);
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
            }
            return result > 0;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the ClaseBajaBusquedaPersonas class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static ClaseBajaBusquedaPersonas FillDataRecord(IDataRecord myDataRecord)
{
ClaseBajaBusquedaPersonas myClaseBajaBusquedaPersonas = new ClaseBajaBusquedaPersonas();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myClaseBajaBusquedaPersonas.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
    myClaseBajaBusquedaPersonas.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myClaseBajaBusquedaPersonas;
}
    }

}
