using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseTipoCabelloDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseTipoCabello objects.
/// </summary>
public partial class SICClaseTipoCabelloDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseTipoCabello from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseTipoCabello in the database.</param>
/// <returns>An SICClaseTipoCabello when the Id was found in the database, or null otherwise.</returns>
public static SICClaseTipoCabello GetItem(int id)
{
SICClaseTipoCabello mySICClaseTipoCabello = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseTipoCabelloSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseTipoCabello = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseTipoCabello;
}
}

/// <summary>
/// Returns a list with SICClaseTipoCabello objects.
/// </summary>
/// <returns>A generics List with the SICClaseTipoCabello objects.</returns>
public static SICClaseTipoCabelloList GetList()
{
SICClaseTipoCabelloList tempList = new SICClaseTipoCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseTipoCabelloSelectList", myConnection))
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
/// Saves a SICClaseTipoCabello in the database.
/// </summary>
/// <param name="mySICClaseTipoCabello">The SICClaseTipoCabello instance to save.</param>
/// <returns>The new Id if the SICClaseTipoCabello is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseTipoCabello mySICClaseTipoCabello)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseTipoCabelloInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseTipoCabello.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseTipoCabello.Id);
}
if (string.IsNullOrEmpty(mySICClaseTipoCabello.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseTipoCabello.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseTipoCabello.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseTipoCabello.Letra);
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
/// Deletes a SICClaseTipoCabello from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseTipoCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseTipoCabelloDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseTipoCabello class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseTipoCabello FillDataRecord(IDataRecord myDataRecord )
{
SICClaseTipoCabello mySICClaseTipoCabello = new SICClaseTipoCabello();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseTipoCabello.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseTipoCabello.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseTipoCabello.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseTipoCabello;
}
}

 } 
