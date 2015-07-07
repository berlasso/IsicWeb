using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The ClaseTipoPersonaDB class is responsible for interacting with the database to retrieve and store information
/// about ClaseTipoPersona objects.
/// </summary>
public partial class ClaseTipoPersonaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of ClaseTipoPersona from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the ClaseTipoPersona in the database.</param>
/// <returns>An ClaseTipoPersona when the id was found in the database, or null otherwise.</returns>
public static ClaseTipoPersona GetItem(int id)
{
ClaseTipoPersona myClaseTipoPersona = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTipoPersonaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myClaseTipoPersona = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myClaseTipoPersona;
}
}

/// <summary>
/// Returns a list with ClaseTipoPersona objects.
/// </summary>
/// <returns>A generics List with the ClaseTipoPersona objects.</returns>
public static ClaseTipoPersonaList GetList()
{
ClaseTipoPersonaList tempList = new ClaseTipoPersonaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTipoPersonaSelectList", myConnection))
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
/// Saves a ClaseTipoPersona in the database.
/// </summary>
/// <param name="myClaseTipoPersona">The ClaseTipoPersona instance to save.</param>
/// <returns>The new id if the ClaseTipoPersona is new in the database or the existing id when an item was updated.</returns>
public static int Save(ClaseTipoPersona myClaseTipoPersona)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTipoPersonaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myClaseTipoPersona.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myClaseTipoPersona.id);
}
if (string.IsNullOrEmpty(myClaseTipoPersona.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myClaseTipoPersona.Descripcion);
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
/// Deletes a ClaseTipoPersona from the database.
/// </summary>
/// <param name="id">The id of the ClaseTipoPersona to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTipoPersonaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the ClaseTipoPersona class and fills it with the data fom the IDataRecord.
/// </summary>
private static ClaseTipoPersona FillDataRecord(IDataRecord myDataRecord )
{
ClaseTipoPersona myClaseTipoPersona = new ClaseTipoPersona();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myClaseTipoPersona.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myClaseTipoPersona.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myClaseTipoPersona;
}
}

 } 
