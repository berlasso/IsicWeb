using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseTablaDestinoDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseTablaDestino objects.
/// </summary>
public partial class PBClaseTablaDestinoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseTablaDestino from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseTablaDestino in the database.</param>
/// <returns>An PBClaseTablaDestino when the Id was found in the database, or null otherwise.</returns>
public static PBClaseTablaDestino GetItem(int id)
{
PBClaseTablaDestino myPBClaseTablaDestino = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTablaDestinoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseTablaDestino = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseTablaDestino;
}
}

/// <summary>
/// Returns a list with PBClaseTablaDestino objects.
/// </summary>
/// <returns>A generics List with the PBClaseTablaDestino objects.</returns>
public static PBClaseTablaDestinoList GetList()
{
PBClaseTablaDestinoList tempList = new PBClaseTablaDestinoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTablaDestinoSelectList", myConnection))
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
/// Saves a PBClaseTablaDestino in the database.
/// </summary>
/// <param name="myPBClaseTablaDestino">The PBClaseTablaDestino instance to save.</param>
/// <returns>The new Id if the PBClaseTablaDestino is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseTablaDestino myPBClaseTablaDestino)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTablaDestinoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseTablaDestino.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseTablaDestino.Id);
}
if (string.IsNullOrEmpty(myPBClaseTablaDestino.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseTablaDestino.Descripcion);
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
/// Deletes a PBClaseTablaDestino from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseTablaDestino to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTablaDestinoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseTablaDestino class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseTablaDestino FillDataRecord(IDataRecord myDataRecord )
{
PBClaseTablaDestino myPBClaseTablaDestino = new PBClaseTablaDestino();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseTablaDestino.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseTablaDestino.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseTablaDestino;
}
}

 } 
