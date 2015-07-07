using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseSeniaParticularDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseSeniaParticular objects.
/// </summary>
public partial class PBClaseSeniaParticularDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseSeniaParticular from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseSeniaParticular in the database.</param>
/// <returns>An PBClaseSeniaParticular when the Id was found in the database, or null otherwise.</returns>
public static PBClaseSeniaParticular GetItem(int id)
{
PBClaseSeniaParticular myPBClaseSeniaParticular = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseSeniaParticularSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseSeniaParticular = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseSeniaParticular;
}
}

/// <summary>
/// Returns a list with PBClaseSeniaParticular objects.
/// </summary>
/// <returns>A generics List with the PBClaseSeniaParticular objects.</returns>
public static PBClaseSeniaParticularList GetList()
{
PBClaseSeniaParticularList tempList = new PBClaseSeniaParticularList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseSeniaParticularSelectList", myConnection))
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
/// Saves a PBClaseSeniaParticular in the database.
/// </summary>
/// <param name="myPBClaseSeniaParticular">The PBClaseSeniaParticular instance to save.</param>
/// <returns>The new Id if the PBClaseSeniaParticular is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseSeniaParticular myPBClaseSeniaParticular)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseSeniaParticularInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseSeniaParticular.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseSeniaParticular.Id);
}
if (string.IsNullOrEmpty(myPBClaseSeniaParticular.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseSeniaParticular.Descripcion);
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
/// Deletes a PBClaseSeniaParticular from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseSeniaParticular to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseSeniaParticularDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseSeniaParticular class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseSeniaParticular FillDataRecord(IDataRecord myDataRecord )
{
PBClaseSeniaParticular myPBClaseSeniaParticular = new PBClaseSeniaParticular();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseSeniaParticular.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseSeniaParticular.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseSeniaParticular;
}
}

 } 
