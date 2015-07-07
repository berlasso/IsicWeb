using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
    /// <summary>
    /// The PBClaseColorOjosDB class is responsible for interacting with the database to retrieve and store information
    /// about PBClaseColorOjos objects.
    /// </summary>
    public partial class PBClaseColorOjosDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of PBClaseColorOjos from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique Id of the PBClaseColorOjos in the database.</param>
        /// <returns>An PBClaseColorOjos when the Id was found in the database, or null otherwise.</returns>
        public static PBClaseColorOjos GetItem(int id)
        {
            PBClaseColorOjos myPBClaseColorOjos = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PBClaseColorOjosSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPBClaseColorOjos = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPBClaseColorOjos;
            }
        }

        /// <summary>
        /// Returns a list with PBClaseColorOjos objects.
        /// </summary>
        /// <returns>A generics List with the PBClaseColorOjos objects.</returns>
        public static PBClaseColorOjosList GetList()
        {
            PBClaseColorOjosList tempList = new PBClaseColorOjosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PBClaseColorOjosSelectList", myConnection))
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
        /// Saves a PBClaseColorOjos in the database.
        /// </summary>
        /// <param name="myPBClaseColorOjos">The PBClaseColorOjos instance to save.</param>
        /// <returns>The new Id if the PBClaseColorOjos is new in the database or the existing Id when an item was updated.</returns>
        public static int Save(PBClaseColorOjos myPBClaseColorOjos)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PBClaseColorOjosInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myPBClaseColorOjos.Id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myPBClaseColorOjos.Id);
                    }
                    if (string.IsNullOrEmpty(myPBClaseColorOjos.Descripcion))
                    {
                        myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@descripcion", myPBClaseColorOjos.Descripcion);
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
        /// Deletes a PBClaseColorOjos from the database.
        /// </summary>
        /// <param name="id">The Id of the PBClaseColorOjos to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PBClaseColorOjosDeleteSingleItem", myConnection))
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
        /// Initializes a new instance of the PBClaseColorOjos class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static PBClaseColorOjos FillDataRecord(IDataRecord myDataRecord)
        {
            PBClaseColorOjos myPBClaseColorOjos = new PBClaseColorOjos();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
            {
                myPBClaseColorOjos.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
            {
                myPBClaseColorOjos.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
            }
            return myPBClaseColorOjos;
        }
    }

} 
