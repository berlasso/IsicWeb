using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseFormaLabioInferiorDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseFormaLabioInferior objects.
/// </summary>
public partial class SICClaseFormaLabioInferiorDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseFormaLabioInferior from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseFormaLabioInferior in the database.</param>
/// <returns>An SICClaseFormaLabioInferior when the Id was found in the database, or null otherwise.</returns>
public static SICClaseFormaLabioInferior GetItem(int id)
{
SICClaseFormaLabioInferior mySICClaseFormaLabioInferior = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaLabioInferiorSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseFormaLabioInferior = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseFormaLabioInferior;
}
}

/// <summary>
/// Returns a list with SICClaseFormaLabioInferior objects.
/// </summary>
/// <returns>A generics List with the SICClaseFormaLabioInferior objects.</returns>
public static SICClaseFormaLabioInferiorList GetList()
{
SICClaseFormaLabioInferiorList tempList = new SICClaseFormaLabioInferiorList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaLabioInferiorSelectList", myConnection))
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
/// Saves a SICClaseFormaLabioInferior in the database.
/// </summary>
/// <param name="mySICClaseFormaLabioInferior">The SICClaseFormaLabioInferior instance to save.</param>
/// <returns>The new Id if the SICClaseFormaLabioInferior is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseFormaLabioInferior mySICClaseFormaLabioInferior)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaLabioInferiorInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseFormaLabioInferior.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseFormaLabioInferior.Id);
}
if (string.IsNullOrEmpty(mySICClaseFormaLabioInferior.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseFormaLabioInferior.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseFormaLabioInferior.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseFormaLabioInferior.Letra);
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
/// Deletes a SICClaseFormaLabioInferior from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaLabioInferior to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaLabioInferiorDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseFormaLabioInferior class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseFormaLabioInferior FillDataRecord(IDataRecord myDataRecord )
{
SICClaseFormaLabioInferior mySICClaseFormaLabioInferior = new SICClaseFormaLabioInferior();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseFormaLabioInferior.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseFormaLabioInferior.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseFormaLabioInferior.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseFormaLabioInferior;
}
}

 } 
