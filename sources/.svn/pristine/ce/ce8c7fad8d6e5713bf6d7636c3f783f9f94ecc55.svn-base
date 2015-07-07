using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The ClasePersonaDB class is responsible for interacting with the database to retrieve and store information
/// about ClasePersona objects.
/// </summary>
public partial class ClasePersonaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of ClasePersona from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the ClasePersona in the database.</param>
/// <returns>An ClasePersona when the id was found in the database, or null otherwise.</returns>
public static ClasePersona GetItem(int id)
{
ClasePersona myClasePersona = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClasePersonaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myClasePersona = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myClasePersona;
}
}

/// <summary>
/// Returns a list with ClasePersona objects.
/// </summary>
/// <returns>A generics List with the ClasePersona objects.</returns>
public static ClasePersonaList GetList()
{
ClasePersonaList tempList = new ClasePersonaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClasePersonaSelectList", myConnection))
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
/// Saves a ClasePersona in the database.
/// </summary>
/// <param name="myClasePersona">The ClasePersona instance to save.</param>
/// <returns>The new id if the ClasePersona is new in the database or the existing id when an item was updated.</returns>
public static int Save(ClasePersona myClasePersona)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClasePersonaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myClasePersona.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myClasePersona.id);
}
if (string.IsNullOrEmpty(myClasePersona.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myClasePersona.descripcion);
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
/// Deletes a ClasePersona from the database.
/// </summary>
/// <param name="id">The id of the ClasePersona to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClasePersonaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the ClasePersona class and fills it with the data fom the IDataRecord.
/// </summary>
private static ClasePersona FillDataRecord(IDataRecord myDataRecord )
{
ClasePersona myClasePersona = new ClasePersona();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myClasePersona.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myClasePersona.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myClasePersona;
}
}

 } 
