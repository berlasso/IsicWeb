using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseFormaLabioSuperiorDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseFormaLabioSuperior objects.
/// </summary>
public partial class SICClaseFormaLabioSuperiorDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseFormaLabioSuperior from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseFormaLabioSuperior in the database.</param>
/// <returns>An SICClaseFormaLabioSuperior when the Id was found in the database, or null otherwise.</returns>
public static SICClaseFormaLabioSuperior GetItem(int id)
{
SICClaseFormaLabioSuperior mySICClaseFormaLabioSuperior = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaLabioSuperiorSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseFormaLabioSuperior = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseFormaLabioSuperior;
}
}

/// <summary>
/// Returns a list with SICClaseFormaLabioSuperior objects.
/// </summary>
/// <returns>A generics List with the SICClaseFormaLabioSuperior objects.</returns>
public static SICClaseFormaLabioSuperiorList GetList()
{
SICClaseFormaLabioSuperiorList tempList = new SICClaseFormaLabioSuperiorList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaLabioSuperiorSelectList", myConnection))
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
/// Saves a SICClaseFormaLabioSuperior in the database.
/// </summary>
/// <param name="mySICClaseFormaLabioSuperior">The SICClaseFormaLabioSuperior instance to save.</param>
/// <returns>The new Id if the SICClaseFormaLabioSuperior is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseFormaLabioSuperior mySICClaseFormaLabioSuperior)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaLabioSuperiorInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseFormaLabioSuperior.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseFormaLabioSuperior.Id);
}
if (string.IsNullOrEmpty(mySICClaseFormaLabioSuperior.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseFormaLabioSuperior.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseFormaLabioSuperior.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseFormaLabioSuperior.Letra);
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
/// Deletes a SICClaseFormaLabioSuperior from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaLabioSuperior to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaLabioSuperiorDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseFormaLabioSuperior class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseFormaLabioSuperior FillDataRecord(IDataRecord myDataRecord )
{
SICClaseFormaLabioSuperior mySICClaseFormaLabioSuperior = new SICClaseFormaLabioSuperior();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseFormaLabioSuperior.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseFormaLabioSuperior.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseFormaLabioSuperior.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseFormaLabioSuperior;
}
}

 } 
