using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseColorCabelloDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseColorCabello objects.
/// </summary>
public partial class PBClaseColorCabelloDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseColorCabello from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseColorCabello in the database.</param>
/// <returns>An PBClaseColorCabello when the Id was found in the database, or null otherwise.</returns>
public static PBClaseColorCabello GetItem(int id)
{
PBClaseColorCabello myPBClaseColorCabello = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseColorCabelloSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseColorCabello = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseColorCabello;
}
}

/// <summary>
/// Returns a list with PBClaseColorCabello objects.
/// </summary>
/// <returns>A generics List with the PBClaseColorCabello objects.</returns>
public static PBClaseColorCabelloList GetList()
{
PBClaseColorCabelloList tempList = new PBClaseColorCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseColorCabelloSelectList", myConnection))
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
/// Saves a PBClaseColorCabello in the database.
/// </summary>
/// <param name="myPBClaseColorCabello">The PBClaseColorCabello instance to save.</param>
/// <returns>The new Id if the PBClaseColorCabello is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseColorCabello myPBClaseColorCabello)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseColorCabelloInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseColorCabello.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseColorCabello.Id);
}
if (string.IsNullOrEmpty(myPBClaseColorCabello.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseColorCabello.Descripcion);
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
/// Deletes a PBClaseColorCabello from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseColorCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseColorCabelloDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseColorCabello class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseColorCabello FillDataRecord(IDataRecord myDataRecord )
{
PBClaseColorCabello myPBClaseColorCabello = new PBClaseColorCabello();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseColorCabello.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseColorCabello.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseColorCabello;
}
}

 } 
