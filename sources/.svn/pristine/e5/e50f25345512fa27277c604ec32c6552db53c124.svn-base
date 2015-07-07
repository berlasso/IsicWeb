using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseBooleanDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseBoolean objects.
/// </summary>
public partial class PBClaseBooleanDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseBoolean from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseBoolean in the database.</param>
/// <returns>An PBClaseBoolean when the Id was found in the database, or null otherwise.</returns>
public static PBClaseBoolean GetItem(int id)
{
PBClaseBoolean myPBClaseBoolean = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseBooleanSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseBoolean = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseBoolean;
}
}

/// <summary>
/// Returns a list with PBClaseBoolean objects.
/// </summary>
/// <returns>A generics List with the PBClaseBoolean objects.</returns>
public static PBClaseBooleanList GetList()
{
PBClaseBooleanList tempList = new PBClaseBooleanList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseBooleanSelectList", myConnection))
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
/// Saves a PBClaseBoolean in the database.
/// </summary>
/// <param name="myPBClaseBoolean">The PBClaseBoolean instance to save.</param>
/// <returns>The new Id if the PBClaseBoolean is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseBoolean myPBClaseBoolean)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseBooleanInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseBoolean.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseBoolean.Id);
}
if (string.IsNullOrEmpty(myPBClaseBoolean.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseBoolean.Descripcion);
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
/// Deletes a PBClaseBoolean from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseBoolean to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseBooleanDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseBoolean class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseBoolean FillDataRecord(IDataRecord myDataRecord )
{
PBClaseBoolean myPBClaseBoolean = new PBClaseBoolean();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseBoolean.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseBoolean.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseBoolean;
}
}

 } 
