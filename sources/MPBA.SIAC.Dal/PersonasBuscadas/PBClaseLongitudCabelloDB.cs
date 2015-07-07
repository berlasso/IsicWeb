using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal{
/// <summary>
/// The PBClaseLongitudCabelloDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseLongitudCabello objects.
/// </summary>
public partial class PBClaseLongitudCabelloDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseLongitudCabello from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseLongitudCabello in the database.</param>
/// <returns>An PBClaseLongitudCabello when the Id was found in the database, or null otherwise.</returns>
public static PBClaseLongitudCabello GetItem(int id)
{
PBClaseLongitudCabello myPBClaseLongitudCabello = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseLongitudCabelloSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseLongitudCabello = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseLongitudCabello;
}
}

/// <summary>
/// Returns a list with PBClaseLongitudCabello objects.
/// </summary>
/// <returns>A generics List with the PBClaseLongitudCabello objects.</returns>
public static PBClaseLongitudCabelloList GetList()
{
PBClaseLongitudCabelloList tempList = new PBClaseLongitudCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseLongitudCabelloSelectList", myConnection))
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
/// Saves a PBClaseLongitudCabello in the database.
/// </summary>
/// <param name="myPBClaseLongitudCabello">The PBClaseLongitudCabello instance to save.</param>
/// <returns>The new Id if the PBClaseLongitudCabello is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseLongitudCabello myPBClaseLongitudCabello)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseLongitudCabelloInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseLongitudCabello.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseLongitudCabello.Id);
}
if (string.IsNullOrEmpty(myPBClaseLongitudCabello.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseLongitudCabello.Descripcion);
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
/// Deletes a PBClaseLongitudCabello from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseLongitudCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseLongitudCabelloDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseLongitudCabello class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseLongitudCabello FillDataRecord(IDataRecord myDataRecord )
{
PBClaseLongitudCabello myPBClaseLongitudCabello = new PBClaseLongitudCabello();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseLongitudCabello.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseLongitudCabello.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseLongitudCabello;
}
}

 } 
