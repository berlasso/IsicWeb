using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The ClaseTipoDNIDB class is responsible for interacting with the database to retrieve and store information
/// about ClaseTipoDNI objects.
/// </summary>
public partial class ClaseTipoDNIDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of ClaseTipoDNI from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the ClaseTipoDNI in the database.</param>
/// <returns>An ClaseTipoDNI when the id was found in the database, or null otherwise.</returns>
public static ClaseTipoDNI GetItem(int id)
{
ClaseTipoDNI myClaseTipoDNI = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTipoDNISelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myClaseTipoDNI = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myClaseTipoDNI;
}
}

/// <summary>
/// Returns a list with ClaseTipoDNI objects.
/// </summary>
/// <returns>A generics List with the ClaseTipoDNI objects.</returns>
public static ClaseTipoDNIList GetList()
{
ClaseTipoDNIList tempList = new ClaseTipoDNIList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTipoDNISelectList", myConnection))
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
/// Saves a ClaseTipoDNI in the database.
/// </summary>
/// <param name="myClaseTipoDNI">The ClaseTipoDNI instance to save.</param>
/// <returns>The new id if the ClaseTipoDNI is new in the database or the existing id when an item was updated.</returns>
public static int Save(ClaseTipoDNI myClaseTipoDNI)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTipoDNIInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myClaseTipoDNI.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myClaseTipoDNI.id);
}
if (string.IsNullOrEmpty(myClaseTipoDNI.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myClaseTipoDNI.Descripcion);
}
if (myClaseTipoDNI.Version == null){
myCommand.Parameters.AddWithValue("@version", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@version", myClaseTipoDNI.Version);
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
/// Deletes a ClaseTipoDNI from the database.
/// </summary>
/// <param name="id">The id of the ClaseTipoDNI to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTipoDNIDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the ClaseTipoDNI class and fills it with the data fom the IDataRecord.
/// </summary>
private static ClaseTipoDNI FillDataRecord(IDataRecord myDataRecord )
{
ClaseTipoDNI myClaseTipoDNI = new ClaseTipoDNI();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myClaseTipoDNI.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myClaseTipoDNI.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
//if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Version")))
//{
//myClaseTipoDNI.Version = myDataRecord.(myDataRecord.GetOrdinal("Version"));
//}
return myClaseTipoDNI;
}
}

 } 
