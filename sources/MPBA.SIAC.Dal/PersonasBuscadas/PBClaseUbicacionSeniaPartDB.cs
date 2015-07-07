using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseUbicacionSeniaPartDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseUbicacionSeniaPart objects.
/// </summary>
public partial class PBClaseUbicacionSeniaPartDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseUbicacionSeniaPart from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseUbicacionSeniaPart in the database.</param>
/// <returns>An PBClaseUbicacionSeniaPart when the Id was found in the database, or null otherwise.</returns>
public static PBClaseUbicacionSeniaPart GetItem(int id)
{
PBClaseUbicacionSeniaPart myPBClaseUbicacionSeniaPart = null;
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
myPBClaseUbicacionSeniaPart = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseUbicacionSeniaPart;
}
}

/// <summary>
/// Returns a list with PBClaseUbicacionSeniaPart objects.
/// </summary>
/// <returns>A generics List with the PBClaseUbicacionSeniaPart objects.</returns>
public static PBClaseUbicacionSeniaPartList GetList()
{
PBClaseUbicacionSeniaPartList tempList = new PBClaseUbicacionSeniaPartList();
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
/// Saves a PBClaseUbicacionSeniaPart in the database.
/// </summary>
/// <param name="myPBClaseUbicacionSeniaPart">The PBClaseUbicacionSeniaPart instance to save.</param>
/// <returns>The new Id if the PBClaseUbicacionSeniaPart is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseUbicacionSeniaPart myPBClaseUbicacionSeniaPart)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseUbicacionSeniaPartInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseUbicacionSeniaPart.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseUbicacionSeniaPart.Id);
}
if (string.IsNullOrEmpty(myPBClaseUbicacionSeniaPart.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseUbicacionSeniaPart.Descripcion);
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
/// Deletes a PBClaseUbicacionSeniaPart from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseUbicacionSeniaPart to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseUbicacionSeniaPartDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseUbicacionSeniaPart class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseUbicacionSeniaPart FillDataRecord(IDataRecord myDataRecord )
{
PBClaseUbicacionSeniaPart myPBClaseUbicacionSeniaPart = new PBClaseUbicacionSeniaPart();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseUbicacionSeniaPart.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseUbicacionSeniaPart.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseUbicacionSeniaPart;
}
}

 } 
