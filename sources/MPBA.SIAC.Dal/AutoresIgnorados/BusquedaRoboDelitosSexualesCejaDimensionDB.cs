using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesCejaDimensionDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesCejaDimension objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesCejaDimensionDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesCejaDimension from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesCejaDimension in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesCejaDimension when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesCejaDimension GetItem(int id)
{
BusquedaRoboDelitosSexualesCejaDimension myBusquedaRoboDelitosSexualesCejaDimension = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesCejaDimensionSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesCejaDimension = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesCejaDimension;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesCejaDimension objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesCejaDimension objects.</returns>
public static BusquedaRoboDelitosSexualesCejaDimensionList GetList()
{
BusquedaRoboDelitosSexualesCejaDimensionList tempList = new BusquedaRoboDelitosSexualesCejaDimensionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesCejaDimensionSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesCejaDimension objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesCejaDimension objects.</returns>
public static BusquedaRoboDelitosSexualesCejaDimensionList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesCejaDimensionList tempList = new BusquedaRoboDelitosSexualesCejaDimensionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesCejaDimensionSelectListByidBusquedaRoboDS", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", idBusquedaRoboDS);
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
return tempList;
}
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesCejaDimension in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesCejaDimension">The BusquedaRoboDelitosSexualesCejaDimension instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesCejaDimension is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesCejaDimension myBusquedaRoboDelitosSexualesCejaDimension)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesCejaDimensionInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesCejaDimension.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesCejaDimension.id);
}
if (myBusquedaRoboDelitosSexualesCejaDimension.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesCejaDimension.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesCejaDimension.idDimensionCeja == null){
myCommand.Parameters.AddWithValue("@idDimensionCeja", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idDimensionCeja", myBusquedaRoboDelitosSexualesCejaDimension.idDimensionCeja);
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
/// Deletes a BusquedaRoboDelitosSexualesCejaDimension from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesCejaDimension to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesCejaDimensionDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesCejaDimension class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesCejaDimension FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesCejaDimension myBusquedaRoboDelitosSexualesCejaDimension = new BusquedaRoboDelitosSexualesCejaDimension();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesCejaDimension.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesCejaDimension.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDimensionCeja")))
{
myBusquedaRoboDelitosSexualesCejaDimension.idDimensionCeja = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDimensionCeja"));
}
return myBusquedaRoboDelitosSexualesCejaDimension;
}
}

 } 
