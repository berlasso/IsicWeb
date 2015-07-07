using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The ClaseUbicacionSeniaPartDB class is responsible for interacting with the database to retrieve and store information
/// about ClaseUbicacionSeniaPart objects.
/// </summary>
public partial class ClaseUbicacionSeniaPartDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of ClaseUbicacionSeniaPart from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the ClaseUbicacionSeniaPart in the database.</param>
/// <returns>An ClaseUbicacionSeniaPart when the id was found in the database, or null otherwise.</returns>
public static ClaseUbicacionSeniaPart GetItem(int id)
{
ClaseUbicacionSeniaPart myClaseUbicacionSeniaPart = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseUbicacionSeniaPartSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myClaseUbicacionSeniaPart = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myClaseUbicacionSeniaPart;
}
}

/// <summary>
/// Returns a list with ClaseUbicacionSeniaPart objects.
/// </summary>
/// <returns>A generics List with the ClaseUbicacionSeniaPart objects.</returns>
public static ClaseUbicacionSeniaPartList GetList()
{
ClaseUbicacionSeniaPartList tempList = new ClaseUbicacionSeniaPartList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseUbicacionSeniaPartSelectList", myConnection))
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
/// Saves a ClaseUbicacionSeniaPart in the database.
/// </summary>
/// <param name="myClaseUbicacionSeniaPart">The ClaseUbicacionSeniaPart instance to save.</param>
/// <returns>The new id if the ClaseUbicacionSeniaPart is new in the database or the existing id when an item was updated.</returns>
public static int Save(ClaseUbicacionSeniaPart myClaseUbicacionSeniaPart)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseUbicacionSeniaPartInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myClaseUbicacionSeniaPart.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myClaseUbicacionSeniaPart.id);
}
if (string.IsNullOrEmpty(myClaseUbicacionSeniaPart.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myClaseUbicacionSeniaPart.Descripcion);
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
/// Deletes a ClaseUbicacionSeniaPart from the database.
/// </summary>
/// <param name="id">The id of the ClaseUbicacionSeniaPart to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseUbicacionSeniaPartDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the ClaseUbicacionSeniaPart class and fills it with the data fom the IDataRecord.
/// </summary>
private static ClaseUbicacionSeniaPart FillDataRecord(IDataRecord myDataRecord )
{
ClaseUbicacionSeniaPart myClaseUbicacionSeniaPart = new ClaseUbicacionSeniaPart();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myClaseUbicacionSeniaPart.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myClaseUbicacionSeniaPart.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myClaseUbicacionSeniaPart;
}
}

 } 
