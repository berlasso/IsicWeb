using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseFormaMentonDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseFormaMenton objects.
/// </summary>
public partial class SICClaseFormaMentonDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseFormaMenton from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseFormaMenton in the database.</param>
/// <returns>An SICClaseFormaMenton when the Id was found in the database, or null otherwise.</returns>
public static SICClaseFormaMenton GetItem(int id)
{
SICClaseFormaMenton mySICClaseFormaMenton = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaMentonSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseFormaMenton = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseFormaMenton;
}
}

/// <summary>
/// Returns a list with SICClaseFormaMenton objects.
/// </summary>
/// <returns>A generics List with the SICClaseFormaMenton objects.</returns>
public static SICClaseFormaMentonList GetList()
{
SICClaseFormaMentonList tempList = new SICClaseFormaMentonList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaMentonSelectList", myConnection))
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
/// Saves a SICClaseFormaMenton in the database.
/// </summary>
/// <param name="mySICClaseFormaMenton">The SICClaseFormaMenton instance to save.</param>
/// <returns>The new Id if the SICClaseFormaMenton is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseFormaMenton mySICClaseFormaMenton)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaMentonInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseFormaMenton.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseFormaMenton.Id);
}
if (string.IsNullOrEmpty(mySICClaseFormaMenton.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseFormaMenton.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseFormaMenton.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseFormaMenton.Letra);
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
/// Deletes a SICClaseFormaMenton from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaMenton to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaMentonDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseFormaMenton class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseFormaMenton FillDataRecord(IDataRecord myDataRecord )
{
SICClaseFormaMenton mySICClaseFormaMenton = new SICClaseFormaMenton();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseFormaMenton.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseFormaMenton.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseFormaMenton.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseFormaMenton;
}
}

 } 
