using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseOrganismoIntervinienteDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseOrganismoInterviniente objects.
/// </summary>
public partial class PBClaseOrganismoIntervinienteDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseOrganismoInterviniente from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseOrganismoInterviniente in the database.</param>
/// <returns>An PBClaseOrganismoInterviniente when the Id was found in the database, or null otherwise.</returns>
public static PBClaseOrganismoInterviniente GetItem(int id)
{
PBClaseOrganismoInterviniente myPBClaseOrganismoInterviniente = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseOrganismoIntervinienteSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseOrganismoInterviniente = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseOrganismoInterviniente;
}
}

/// <summary>
/// Returns a list with PBClaseOrganismoInterviniente objects.
/// </summary>
/// <returns>A generics List with the PBClaseOrganismoInterviniente objects.</returns>
public static PBClaseOrganismoIntervinienteList GetList()
{
PBClaseOrganismoIntervinienteList tempList = new PBClaseOrganismoIntervinienteList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseOrganismoIntervinienteSelectList", myConnection))
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
/// Saves a PBClaseOrganismoInterviniente in the database.
/// </summary>
/// <param name="myPBClaseOrganismoInterviniente">The PBClaseOrganismoInterviniente instance to save.</param>
/// <returns>The new Id if the PBClaseOrganismoInterviniente is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseOrganismoInterviniente myPBClaseOrganismoInterviniente)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseOrganismoIntervinienteInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseOrganismoInterviniente.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseOrganismoInterviniente.Id);
}
if (string.IsNullOrEmpty(myPBClaseOrganismoInterviniente.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseOrganismoInterviniente.Descripcion);
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
/// Deletes a PBClaseOrganismoInterviniente from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseOrganismoInterviniente to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseOrganismoIntervinienteDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseOrganismoInterviniente class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseOrganismoInterviniente FillDataRecord(IDataRecord myDataRecord )
{
PBClaseOrganismoInterviniente myPBClaseOrganismoInterviniente = new PBClaseOrganismoInterviniente();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseOrganismoInterviniente.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseOrganismoInterviniente.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseOrganismoInterviniente;
}
}

 } 
