using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The BusquedaColorTenidoDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaColorTenido objects.
/// </summary>
public partial class BusquedaColorTenidoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaColorTenido from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaColorTenido in the database.</param>
/// <returns>An BusquedaColorTenido when the id was found in the database, or null otherwise.</returns>
public static BusquedaColorTenido GetItem(decimal id)
{
BusquedaColorTenido myBusquedaColorTenido = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorTenidoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaColorTenido = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaColorTenido;
}
}

/// <summary>
/// Returns a list with BusquedaColorTenido objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorTenido objects.</returns>
public static BusquedaColorTenidoList GetList()
{
BusquedaColorTenidoList tempList = new BusquedaColorTenidoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorTenidoSelectList", myConnection))
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
/// Returns a list with BusquedaColorTenido objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorTenido objects.</returns>
public static BusquedaColorTenidoList GetListByidBusqueda(decimal idBusqueda)
{
BusquedaColorTenidoList tempList = new BusquedaColorTenidoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorTenidoSelectListByidBusqueda", myConnection))
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
/// Returns a list with BusquedaColorTenido objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorTenido objects.</returns>
public static BusquedaColorTenidoList GetListByidClaseColorTenido(int idClaseColorTenido)
{
BusquedaColorTenidoList tempList = new BusquedaColorTenidoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorTenidoSelectListByidClaseColorTenido", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseColorTenido", idClaseColorTenido);
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
/// Saves a BusquedaColorTenido in the database.
/// </summary>
/// <param name="myBusquedaColorTenido">The BusquedaColorTenido instance to save.</param>
/// <returns>The new id if the BusquedaColorTenido is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaColorTenido myBusquedaColorTenido, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //using (SqlCommand myCommand = new SqlCommand("BusquedaColorTenidoInsertUpdateSingleItem", myConnection))
    //{
    //myCommand.CommandType = CommandType.StoredProcedure;
   try
   {
    myCommand.CommandText = "BusquedaColorTenidoInsertUpdateSingleItem";
    myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.Parameters.Clear();
    
        if (myBusquedaColorTenido.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBusquedaColorTenido.id);
        }
        if (myBusquedaColorTenido.idBusqueda == null)
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaColorTenido.idBusqueda);
        }
        if (myBusquedaColorTenido.idClaseColorTenido == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseColorTenido", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseColorTenido", myBusquedaColorTenido.idClaseColorTenido);
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
/// Deletes a BusquedaColorTenido from the database.
/// </summary>
/// <param name="id">The id of the BusquedaColorTenido to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(decimal id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorTenidoDeleteSingleItem", myConnection))
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
/// Deletes las BusquedaColorTenido de una Busqueda from the database.
/// </summary>
/// <param name="id">The idBusqueda of the BusquedaColorTenido to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BusquedaColorTenidoDeleteItemByIdBusqueda", myConnection))
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
/// Initializes a new instance of the BusquedaColorTenido class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaColorTenido FillDataRecord(IDataRecord myDataRecord )
{
BusquedaColorTenido myBusquedaColorTenido = new BusquedaColorTenido();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaColorTenido.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
{
myBusquedaColorTenido.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseColorTenido")))
{
myBusquedaColorTenido.idClaseColorTenido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseColorTenido"));
}
return myBusquedaColorTenido;
}
}

 } 
