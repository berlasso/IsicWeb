using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseTatuajeDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseTatuaje objects.
/// </summary>
public partial class PBClaseTatuajeDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseTatuaje from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the PBClaseTatuaje in the database.</param>
/// <returns>An PBClaseTatuaje when the id was found in the database, or null otherwise.</returns>
public static PBClaseTatuaje GetItem(int id)
{
PBClaseTatuaje myPBClaseTatuaje = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTatuajeSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseTatuaje = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseTatuaje;
}
}

/// <summary>
/// Returns a list with PBClaseTatuaje objects.
/// </summary>
/// <returns>A generics List with the PBClaseTatuaje objects.</returns>
public static PBClaseTatuajeList GetList()
{
PBClaseTatuajeList tempList = new PBClaseTatuajeList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTatuajeSelectList", myConnection))
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
/// Saves a PBClaseTatuaje in the database.
/// </summary>
/// <param name="myPBClaseTatuaje">The PBClaseTatuaje instance to save.</param>
/// <returns>The new id if the PBClaseTatuaje is new in the database or the existing id when an item was updated.</returns>
public static int Save(PBClaseTatuaje myPBClaseTatuaje)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTatuajeInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseTatuaje.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseTatuaje.id);
}
if (string.IsNullOrEmpty(myPBClaseTatuaje.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseTatuaje.descripcion);
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
/// Deletes a PBClaseTatuaje from the database.
/// </summary>
/// <param name="id">The id of the PBClaseTatuaje to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTatuajeDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseTatuaje class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseTatuaje FillDataRecord(IDataRecord myDataRecord )
{
PBClaseTatuaje myPBClaseTatuaje = new PBClaseTatuaje();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myPBClaseTatuaje.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myPBClaseTatuaje.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myPBClaseTatuaje;
}
}

 } 
