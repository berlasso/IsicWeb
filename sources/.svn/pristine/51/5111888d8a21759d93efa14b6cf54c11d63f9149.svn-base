using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseColorDePielDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseColorDePiel objects.
/// </summary>
public partial class PBClaseColorDePielDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseColorDePiel from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseColorDePiel in the database.</param>
/// <returns>An PBClaseColorDePiel when the Id was found in the database, or null otherwise.</returns>
public static PBClaseColorDePiel GetItem(int id)
{
PBClaseColorDePiel myPBClaseColorDePiel = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseColorDePielSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseColorDePiel = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseColorDePiel;
}
}

/// <summary>
/// Returns a list with PBClaseColorDePiel objects.
/// </summary>
/// <returns>A generics List with the PBClaseColorDePiel objects.</returns>
public static PBClaseColorDePielList GetList()
{
PBClaseColorDePielList tempList = new PBClaseColorDePielList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseColorDePielSelectList", myConnection))
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
/// Saves a PBClaseColorDePiel in the database.
/// </summary>
/// <param name="myPBClaseColorDePiel">The PBClaseColorDePiel instance to save.</param>
/// <returns>The new Id if the PBClaseColorDePiel is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseColorDePiel myPBClaseColorDePiel)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseColorDePielInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseColorDePiel.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseColorDePiel.Id);
}
if (string.IsNullOrEmpty(myPBClaseColorDePiel.Descripcion))
{
myCommand.Parameters.AddWithValue("@descirpcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descirpcion", myPBClaseColorDePiel.Descripcion);
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
/// Deletes a PBClaseColorDePiel from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseColorDePiel to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseColorDePielDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseColorDePiel class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseColorDePiel FillDataRecord(IDataRecord myDataRecord )
{
PBClaseColorDePiel myPBClaseColorDePiel = new PBClaseColorDePiel();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseColorDePiel.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descirpcion")))
{
myPBClaseColorDePiel.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descirpcion"));
}
return myPBClaseColorDePiel;
}
}

 } 
