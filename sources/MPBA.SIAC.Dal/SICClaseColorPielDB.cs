using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseColorPielDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseColorPiel objects.
/// </summary>
public partial class SICClaseColorPielDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseColorPiel from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseColorPiel in the database.</param>
/// <returns>An SICClaseColorPiel when the Id was found in the database, or null otherwise.</returns>
public static SICClaseColorPiel GetItem(int id)
{
SICClaseColorPiel mySICClaseColorPiel = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorPielSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseColorPiel = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseColorPiel;
}
}

/// <summary>
/// Returns a list with SICClaseColorPiel objects.
/// </summary>
/// <returns>A generics List with the SICClaseColorPiel objects.</returns>
public static SICClaseColorPielList GetList()
{
SICClaseColorPielList tempList = new SICClaseColorPielList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorPielSelectList", myConnection))
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
/// Saves a SICClaseColorPiel in the database.
/// </summary>
/// <param name="mySICClaseColorPiel">The SICClaseColorPiel instance to save.</param>
/// <returns>The new Id if the SICClaseColorPiel is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseColorPiel mySICClaseColorPiel)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorPielInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseColorPiel.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseColorPiel.Id);
}
if (string.IsNullOrEmpty(mySICClaseColorPiel.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseColorPiel.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseColorPiel.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseColorPiel.Letra);
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
/// Deletes a SICClaseColorPiel from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseColorPiel to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorPielDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseColorPiel class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseColorPiel FillDataRecord(IDataRecord myDataRecord )
{
SICClaseColorPiel mySICClaseColorPiel = new SICClaseColorPiel();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseColorPiel.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseColorPiel.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseColorPiel.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseColorPiel;
}
}

 } 
