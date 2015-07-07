using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseGrupoSanguineoDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseGrupoSanguineo objects.
/// </summary>
public partial class PBClaseGrupoSanguineoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseGrupoSanguineo from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseGrupoSanguineo in the database.</param>
/// <returns>An PBClaseGrupoSanguineo when the Id was found in the database, or null otherwise.</returns>
public static PBClaseGrupoSanguineo GetItem(int id)
{
PBClaseGrupoSanguineo myPBClaseGrupoSanguineo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseGrupoSanguineoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseGrupoSanguineo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseGrupoSanguineo;
}
}

/// <summary>
/// Returns a list with PBClaseGrupoSanguineo objects.
/// </summary>
/// <returns>A generics List with the PBClaseGrupoSanguineo objects.</returns>
public static PBClaseGrupoSanguineoList GetList()
{
PBClaseGrupoSanguineoList tempList = new PBClaseGrupoSanguineoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseGrupoSanguineoSelectList", myConnection))
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
/// Saves a PBClaseGrupoSanguineo in the database.
/// </summary>
/// <param name="myPBClaseGrupoSanguineo">The PBClaseGrupoSanguineo instance to save.</param>
/// <returns>The new Id if the PBClaseGrupoSanguineo is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseGrupoSanguineo myPBClaseGrupoSanguineo)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseGrupoSanguineoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseGrupoSanguineo.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseGrupoSanguineo.Id);
}
if (string.IsNullOrEmpty(myPBClaseGrupoSanguineo.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseGrupoSanguineo.Descripcion);
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
/// Deletes a PBClaseGrupoSanguineo from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseGrupoSanguineo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseGrupoSanguineoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseGrupoSanguineo class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseGrupoSanguineo FillDataRecord(IDataRecord myDataRecord )
{
PBClaseGrupoSanguineo myPBClaseGrupoSanguineo = new PBClaseGrupoSanguineo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseGrupoSanguineo.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseGrupoSanguineo.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseGrupoSanguineo;
}
}

 } 
