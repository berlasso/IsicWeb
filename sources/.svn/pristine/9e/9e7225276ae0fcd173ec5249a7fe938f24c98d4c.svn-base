using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseColorCabelloDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseColorCabello objects.
/// </summary>
public partial class SICClaseColorCabelloDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseColorCabello from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseColorCabello in the database.</param>
/// <returns>An SICClaseColorCabello when the Id was found in the database, or null otherwise.</returns>
public static SICClaseColorCabello GetItem(int id)
{
SICClaseColorCabello mySICClaseColorCabello = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorCabelloSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseColorCabello = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseColorCabello;
}
}

/// <summary>
/// Returns a list with SICClaseColorCabello objects.
/// </summary>
/// <returns>A generics List with the SICClaseColorCabello objects.</returns>
public static SICClaseColorCabelloList GetList()
{
SICClaseColorCabelloList tempList = new SICClaseColorCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorCabelloSelectList", myConnection))
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
/// Saves a SICClaseColorCabello in the database.
/// </summary>
/// <param name="mySICClaseColorCabello">The SICClaseColorCabello instance to save.</param>
/// <returns>The new Id if the SICClaseColorCabello is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseColorCabello mySICClaseColorCabello)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorCabelloInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseColorCabello.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseColorCabello.Id);
}
if (string.IsNullOrEmpty(mySICClaseColorCabello.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseColorCabello.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseColorCabello.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseColorCabello.Letra);
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
/// Deletes a SICClaseColorCabello from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseColorCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorCabelloDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseColorCabello class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseColorCabello FillDataRecord(IDataRecord myDataRecord )
{
SICClaseColorCabello mySICClaseColorCabello = new SICClaseColorCabello();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseColorCabello.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseColorCabello.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseColorCabello.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseColorCabello;
}
}

 } 
