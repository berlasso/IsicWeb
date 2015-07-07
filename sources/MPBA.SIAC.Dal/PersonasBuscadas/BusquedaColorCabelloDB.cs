using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The BusquedaColorCabelloDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaColorCabello objects.
/// </summary>
public partial class BusquedaColorCabelloDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaColorCabello from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaColorCabello in the database.</param>
/// <returns>An BusquedaColorCabello when the id was found in the database, or null otherwise.</returns>
public static BusquedaColorCabello GetItem(decimal id)
{
BusquedaColorCabello myBusquedaColorCabello = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorCabelloSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaColorCabello = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaColorCabello;
}
}

/// <summary>
/// Returns a list with BusquedaColorCabello objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorCabello objects.</returns>
public static BusquedaColorCabelloList GetList()
{
BusquedaColorCabelloList tempList = new BusquedaColorCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorCabelloSelectList", myConnection))
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
/// Returns a list with BusquedaColorCabello objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorCabello objects.</returns>
public static BusquedaColorCabelloList GetListByidBusqueda(decimal idBusqueda)
{
BusquedaColorCabelloList tempList = new BusquedaColorCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorCabelloSelectListByidBusqueda", myConnection))
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
/// Returns a list with BusquedaColorCabello objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorCabello objects.</returns>
public static BusquedaColorCabelloList GetListByidClaseColorCabello(int idClaseColorCabello)
{
BusquedaColorCabelloList tempList = new BusquedaColorCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorCabelloSelectListByidClaseColorCabello", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseColorCabello", idClaseColorCabello);
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
/// Saves a BusquedaColorCabello in the database.
/// </summary>
/// <param name="myBusquedaColorCabello">The BusquedaColorCabello instance to save.</param>
/// <returns>The new id if the BusquedaColorCabello is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaColorCabello myBusquedaColorCabello, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //using (SqlCommand myCommand = new SqlCommand("BusquedaColorCabelloInsertUpdateSingleItem", myConnection))
    //{
    //myCommand.CommandType = CommandType.StoredProcedure;

    try
    {
        myCommand.CommandText = "BusquedaColorCabelloInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();

        if (myBusquedaColorCabello.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBusquedaColorCabello.id);
        }
        if (myBusquedaColorCabello.idBusqueda == null)
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaColorCabello.idBusqueda);
        }
        if (myBusquedaColorCabello.idClaseColorCabello == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseColorCabello", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseColorCabello", myBusquedaColorCabello.idClaseColorCabello);
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
/// Deletes a BusquedaColorCabello from the database.
/// </summary>
/// <param name="id">The id of the BusquedaColorCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(decimal id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorCabelloDeleteSingleItem", myConnection))
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
/// Deletes todas las BusquedaColorCabello de una Busqueda from the database.
/// </summary>
/// <param name="id">The idBusqueda of the BusquedaColorCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BusquedaColorCabelloDeleteItemByIdBusqueda", myConnection))
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
/// Initializes a new instance of the BusquedaColorCabello class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaColorCabello FillDataRecord(IDataRecord myDataRecord )
{
BusquedaColorCabello myBusquedaColorCabello = new BusquedaColorCabello();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaColorCabello.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
{
myBusquedaColorCabello.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseColorCabello")))
{
myBusquedaColorCabello.idClaseColorCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseColorCabello"));
}
return myBusquedaColorCabello;
}
}

 } 
