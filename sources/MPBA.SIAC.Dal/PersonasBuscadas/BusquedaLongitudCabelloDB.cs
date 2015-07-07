using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The BusquedaLongitudCabelloDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaLongitudCabello objects.
/// </summary>
public partial class BusquedaLongitudCabelloDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaLongitudCabello from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaLongitudCabello in the database.</param>
/// <returns>An BusquedaLongitudCabello when the id was found in the database, or null otherwise.</returns>
public static BusquedaLongitudCabello GetItem(decimal id)
{
BusquedaLongitudCabello myBusquedaLongitudCabello = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaLongitudCabelloSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaLongitudCabello = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaLongitudCabello;
}
}

/// <summary>
/// Returns a list with BusquedaLongitudCabello objects.
/// </summary>
/// <returns>A generics List with the BusquedaLongitudCabello objects.</returns>
public static BusquedaLongitudCabelloList GetList()
{
BusquedaLongitudCabelloList tempList = new BusquedaLongitudCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaLongitudCabelloSelectList", myConnection))
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
/// Returns a list with BusquedaLongitudCabello objects.
/// </summary>
/// <returns>A generics List with the BusquedaLongitudCabello objects.</returns>
public static BusquedaLongitudCabelloList GetListByidBusqueda(decimal idBusqueda)
{
BusquedaLongitudCabelloList tempList = new BusquedaLongitudCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaLongitudCabelloSelectListByidBusqueda", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idBusqueda", idBusqueda);
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
/// Returns a list with BusquedaLongitudCabello objects.
/// </summary>
/// <returns>A generics List with the BusquedaLongitudCabello objects.</returns>
public static BusquedaLongitudCabelloList GetListByidClaseLongitudCabello(int idClaseLongitudCabello)
{
BusquedaLongitudCabelloList tempList = new BusquedaLongitudCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaLongitudCabelloSelectListByidClaseLongitudCabello", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseLongitudCabello", idClaseLongitudCabello);
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
/// Saves a BusquedaLongitudCabello in the database.
/// </summary>
/// <param name="myBusquedaLongitudCabello">The BusquedaLongitudCabello instance to save.</param>
/// <returns>The new id if the BusquedaLongitudCabello is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaLongitudCabello myBusquedaLongitudCabello, SqlCommand myCommand)
{
int result = 0;
//using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
//{
//using (SqlCommand myCommand = new SqlCommand("BusquedaLongitudCabelloInsertUpdateSingleItem", myConnection))
//{
//myCommand.CommandType = CommandType.StoredProcedure;

try
{
    myCommand.CommandText = "BusquedaLongitudCabelloInsertUpdateSingleItem";
    myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.Parameters.Clear();
    if (myBusquedaLongitudCabello.id == -1)
    {
        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
    }
    else
    {
        myCommand.Parameters.AddWithValue("@id", myBusquedaLongitudCabello.id);
    }
    if (myBusquedaLongitudCabello.idBusqueda == null)
    {
        myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
    }
    else
    {
        myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaLongitudCabello.idBusqueda);
    }
    if (myBusquedaLongitudCabello.idClaseLongitudCabello == null)
    {
        myCommand.Parameters.AddWithValue("@idClaseLongitudCabello", DBNull.Value);
    }
    else
    {
        myCommand.Parameters.AddWithValue("@idClaseLongitudCabello", myBusquedaLongitudCabello.idClaseLongitudCabello);
    }

    DbParameter returnValue;
    returnValue = myCommand.CreateParameter();
    returnValue.Direction = ParameterDirection.ReturnValue;
    myCommand.Parameters.Add(returnValue);

    //myConnection.Open();
    myCommand.ExecuteNonQuery();
    result = Convert.ToInt32(returnValue.Value);
    //myConnection.Close();
    //}
    //}
}
catch (Exception e)
{
    //tr.Rollback();
    throw e;
}
return result;
}

/// <summary>
/// Deletes a BusquedaLongitudCabello from the database.
/// </summary>
/// <param name="id">The id of the BusquedaLongitudCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(decimal id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaLongitudCabelloDeleteSingleItem", myConnection))
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

/// <summary>
/// Deletes las BusquedaLongitudCabello de una Busqueda from the database.
/// </summary>
/// <param name="id">The idBusqueda of the BusquedaLongitudCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BusquedaLongitudCabelloDeleteItemByIdBusqueda", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.AddWithValue("@idBusqueda", idBusqueda);
            myConnection.Open();
            result = myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }
    return result > 0;
}

#endregion

/// <summary>
/// Initializes a new instance of the BusquedaLongitudCabello class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaLongitudCabello FillDataRecord(IDataRecord myDataRecord )
{
BusquedaLongitudCabello myBusquedaLongitudCabello = new BusquedaLongitudCabello();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaLongitudCabello.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
{
myBusquedaLongitudCabello.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseLongitudCabello")))
{
myBusquedaLongitudCabello.idClaseLongitudCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseLongitudCabello"));
}
return myBusquedaLongitudCabello;
}
}

 } 
