using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal{
/// <summary>
/// The PBClaseSexoDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseSexo objects.
/// </summary>
public partial class PBClaseSexoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseSexo from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseSexo in the database.</param>
/// <returns>An PBClaseSexo when the Id was found in the database, or null otherwise.</returns>
public static PBClaseSexo GetItem(int id)
{
PBClaseSexo myPBClaseSexo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseSexoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseSexo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseSexo;
}
}

/// <summary>
/// Returns a list with PBClaseSexo objects.
/// </summary>
/// <returns>A generics List with the PBClaseSexo objects.</returns>
public static PBClaseSexoList GetList()
{
PBClaseSexoList tempList = new PBClaseSexoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseSexoSelectList", myConnection))
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
/// Saves a PBClaseSexo in the database.
/// </summary>
/// <param name="myPBClaseSexo">The PBClaseSexo instance to save.</param>
/// <returns>The new Id if the PBClaseSexo is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseSexo myPBClaseSexo)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseSexoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseSexo.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseSexo.Id);
}
if (string.IsNullOrEmpty(myPBClaseSexo.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseSexo.Descripcion);
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
/// Deletes a PBClaseSexo from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseSexo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseSexoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseSexo class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseSexo FillDataRecord(IDataRecord myDataRecord )
{
PBClaseSexo myPBClaseSexo = new PBClaseSexo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseSexo.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseSexo.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseSexo;
}
}

 } 
