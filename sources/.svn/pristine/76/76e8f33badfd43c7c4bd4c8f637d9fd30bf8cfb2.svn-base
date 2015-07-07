using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
/// <summary>
/// The ProvinciaDB class is responsible for interacting with the database to retrieve and store information
/// about Provincia objects.
/// </summary>
public partial class ProvinciaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of Provincia from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the Provincia in the database.</param>
/// <returns>An Provincia when the id was found in the database, or null otherwise.</returns>
public static Provincia GetItem(int id)
{
Provincia myProvincia = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ProvinciaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myProvincia = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myProvincia;
}
}

/// <summary>
/// Returns a list with Provincia objects.
/// </summary>
/// <returns>A generics List with the Provincia objects.</returns>
public static ProvinciaList GetList()
{
ProvinciaList tempList = new ProvinciaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ProvinciaSelectList", myConnection))
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
/// Saves a Provincia in the database.
/// </summary>
/// <param name="myProvincia">The Provincia instance to save.</param>
/// <returns>The new id if the Provincia is new in the database or the existing id when an item was updated.</returns>
public static int Save(Provincia myProvincia)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ProvinciaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myProvincia.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myProvincia.id);
}
if (string.IsNullOrEmpty(myProvincia.provincia))
{
myCommand.Parameters.AddWithValue("@provincia", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@provincia", myProvincia.provincia);
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
/// Deletes a Provincia from the database.
/// </summary>
/// <param name="id">The id of the Provincia to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ProvinciaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the Provincia class and fills it with the data fom the IDataRecord.
/// </summary>
private static Provincia FillDataRecord(IDataRecord myDataRecord )
{
Provincia myProvincia = new Provincia();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myProvincia.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Provincia")))
{
myProvincia.provincia = myDataRecord.GetString(myDataRecord.GetOrdinal("Provincia"));
}
return myProvincia;
}
}

 } 
