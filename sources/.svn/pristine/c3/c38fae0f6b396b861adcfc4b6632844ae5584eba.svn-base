using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal{
/// <summary>
/// The PBClaseMotivoHallazgoDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseMotivoHallazgo objects.
/// </summary>
public partial class PBClaseMotivoHallazgoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseMotivoHallazgo from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseMotivoHallazgo in the database.</param>
/// <returns>An PBClaseMotivoHallazgo when the Id was found in the database, or null otherwise.</returns>
public static PBClaseMotivoHallazgo GetItem(int id)
{
PBClaseMotivoHallazgo myPBClaseMotivoHallazgo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseMotivoHallazgoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseMotivoHallazgo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseMotivoHallazgo;
}
}

/// <summary>
/// Returns a list with PBClaseMotivoHallazgo objects.
/// </summary>
/// <returns>A generics List with the PBClaseMotivoHallazgo objects.</returns>
public static PBClaseMotivoHallazgoList GetList()
{
PBClaseMotivoHallazgoList tempList = new PBClaseMotivoHallazgoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseMotivoHallazgoSelectList", myConnection))
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
/// Saves a PBClaseMotivoHallazgo in the database.
/// </summary>
/// <param name="myPBClaseMotivoHallazgo">The PBClaseMotivoHallazgo instance to save.</param>
/// <returns>The new Id if the PBClaseMotivoHallazgo is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseMotivoHallazgo myPBClaseMotivoHallazgo)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseMotivoHallazgoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseMotivoHallazgo.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseMotivoHallazgo.Id);
}
if (string.IsNullOrEmpty(myPBClaseMotivoHallazgo.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseMotivoHallazgo.Descripcion);
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
/// Deletes a PBClaseMotivoHallazgo from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseMotivoHallazgo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseMotivoHallazgoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseMotivoHallazgo class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseMotivoHallazgo FillDataRecord(IDataRecord myDataRecord )
{
PBClaseMotivoHallazgo myPBClaseMotivoHallazgo = new PBClaseMotivoHallazgo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseMotivoHallazgo.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseMotivoHallazgo.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseMotivoHallazgo;
}
}

 } 
