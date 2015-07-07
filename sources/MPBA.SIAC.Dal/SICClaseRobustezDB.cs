using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseRobustezDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseRobustez objects.
/// </summary>
public partial class SICClaseRobustezDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseRobustez from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseRobustez in the database.</param>
/// <returns>An SICClaseRobustez when the Id was found in the database, or null otherwise.</returns>
public static SICClaseRobustez GetItem(int id)
{
SICClaseRobustez mySICClaseRobustez = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseRobustezSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseRobustez = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseRobustez;
}
}

/// <summary>
/// Returns a list with SICClaseRobustez objects.
/// </summary>
/// <returns>A generics List with the SICClaseRobustez objects.</returns>
public static SICClaseRobustezList GetList()
{
SICClaseRobustezList tempList = new SICClaseRobustezList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseRobustezSelectList", myConnection))
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
/// Saves a SICClaseRobustez in the database.
/// </summary>
/// <param name="mySICClaseRobustez">The SICClaseRobustez instance to save.</param>
/// <returns>The new Id if the SICClaseRobustez is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseRobustez mySICClaseRobustez)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseRobustezInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseRobustez.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseRobustez.Id);
}
if (string.IsNullOrEmpty(mySICClaseRobustez.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseRobustez.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseRobustez.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseRobustez.Letra);
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
/// Deletes a SICClaseRobustez from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseRobustez to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseRobustezDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseRobustez class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseRobustez FillDataRecord(IDataRecord myDataRecord )
{
SICClaseRobustez mySICClaseRobustez = new SICClaseRobustez();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseRobustez.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseRobustez.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseRobustez.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseRobustez;
}
}

 } 
