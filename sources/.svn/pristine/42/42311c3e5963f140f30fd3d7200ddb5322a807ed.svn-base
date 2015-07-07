using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseFotoDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseFoto objects.
/// </summary>
public partial class PBClaseFotoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseFoto from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the PBClaseFoto in the database.</param>
/// <returns>An PBClaseFoto when the id was found in the database, or null otherwise.</returns>
public static PBClaseFoto GetItem(int id)
{
PBClaseFoto myPBClaseFoto = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseFotoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseFoto = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseFoto;
}
}

/// <summary>
/// Returns a list with PBClaseFoto objects.
/// </summary>
/// <returns>A generics List with the PBClaseFoto objects.</returns>
public static PBClaseFotoList GetList()
{
PBClaseFotoList tempList = new PBClaseFotoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseFotoSelectList", myConnection))
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
/// Saves a PBClaseFoto in the database.
/// </summary>
/// <param name="myPBClaseFoto">The PBClaseFoto instance to save.</param>
/// <returns>The new id if the PBClaseFoto is new in the database or the existing id when an item was updated.</returns>
public static int Save(PBClaseFoto myPBClaseFoto)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseFotoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseFoto.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseFoto.id);
}
if (string.IsNullOrEmpty(myPBClaseFoto.tipoFoto))
{
myCommand.Parameters.AddWithValue("@tipoFoto", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@tipoFoto", myPBClaseFoto.tipoFoto);
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
/// Deletes a PBClaseFoto from the database.
/// </summary>
/// <param name="id">The id of the PBClaseFoto to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseFotoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseFoto class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseFoto FillDataRecord(IDataRecord myDataRecord )
{
PBClaseFoto myPBClaseFoto = new PBClaseFoto();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myPBClaseFoto.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("tipoFoto")))
{
myPBClaseFoto.tipoFoto = myDataRecord.GetString(myDataRecord.GetOrdinal("tipoFoto"));
}
return myPBClaseFoto;
}
}

 } 
