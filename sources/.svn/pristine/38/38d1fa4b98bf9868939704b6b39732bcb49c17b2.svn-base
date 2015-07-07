using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseAspectoCabelloDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseAspectoCabello objects.
/// </summary>
public partial class PBClaseAspectoCabelloDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseAspectoCabello from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseAspectoCabello in the database.</param>
/// <returns>An PBClaseAspectoCabello when the Id was found in the database, or null otherwise.</returns>
public static PBClaseAspectoCabello GetItem(int id)
{
PBClaseAspectoCabello myPBClaseAspectoCabello = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseAspectoCabelloSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseAspectoCabello = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseAspectoCabello;
}
}

/// <summary>
/// Returns a list with PBClaseAspectoCabello objects.
/// </summary>
/// <returns>A generics List with the PBClaseAspectoCabello objects.</returns>
public static PBClaseAspectoCabelloList GetList()
{
PBClaseAspectoCabelloList tempList = new PBClaseAspectoCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseAspectoCabelloSelectList", myConnection))
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
/// Saves a PBClaseAspectoCabello in the database.
/// </summary>
/// <param name="myPBClaseAspectoCabello">The PBClaseAspectoCabello instance to save.</param>
/// <returns>The new Id if the PBClaseAspectoCabello is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseAspectoCabello myPBClaseAspectoCabello)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseAspectoCabelloInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseAspectoCabello.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseAspectoCabello.Id);
}
if (string.IsNullOrEmpty(myPBClaseAspectoCabello.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseAspectoCabello.Descripcion);
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
/// Deletes a PBClaseAspectoCabello from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseAspectoCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseAspectoCabelloDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseAspectoCabello class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseAspectoCabello FillDataRecord(IDataRecord myDataRecord )
{
PBClaseAspectoCabello myPBClaseAspectoCabello = new PBClaseAspectoCabello();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseAspectoCabello.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseAspectoCabello.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseAspectoCabello;
}
}

 } 
