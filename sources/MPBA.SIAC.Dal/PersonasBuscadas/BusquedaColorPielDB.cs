using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The BusquedaColorPielDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaColorPiel objects.
/// </summary>
public partial class BusquedaColorPielDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaColorPiel from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaColorPiel in the database.</param>
/// <returns>An BusquedaColorPiel when the id was found in the database, or null otherwise.</returns>
public static  BusquedaColorPiel GetItem(decimal id)
{
BusquedaColorPiel myBusquedaColorPiel = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorPielSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaColorPiel = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaColorPiel;
}
}

/// <summary>
/// Returns a list with BusquedaColorPiel objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorPiel objects.</returns>
public static BusquedaColorPielList GetList()
{
BusquedaColorPielList tempList = new BusquedaColorPielList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorPielSelectList", myConnection))
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
/// Returns a list with BusquedaColorPiel objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorPiel objects.</returns>
public static BusquedaColorPielList GetListByidBusqueda(decimal idBusqueda)
{
BusquedaColorPielList tempList = new BusquedaColorPielList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorPielSelectListByidBusqueda", myConnection))
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
/// Returns a list with BusquedaColorPiel objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorPiel objects.</returns>
public static BusquedaColorPielList GetListByidClaseColorPiel(int idClaseColorPiel)
{
BusquedaColorPielList tempList = new BusquedaColorPielList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorPielSelectListByidClaseColorPiel", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseColorPiel", idClaseColorPiel);
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
/// Saves a BusquedaColorPiel in the database.
/// </summary>
/// <param name="myBusquedaColorPiel">The BusquedaColorPiel instance to save.</param>
/// <returns>The new id if the BusquedaColorPiel is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaColorPiel myBusquedaColorPiel, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //using (SqlCommand myCommand = new SqlCommand("BusquedaColorPielInsertUpdateSingleItem", myConnection))
    //{
    //myCommand.CommandType = CommandType.StoredProcedure;
   try
   {
    myCommand.CommandText = "BusquedaColorPielInsertUpdateSingleItem";
    myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.Parameters.Clear();
    
        if (myBusquedaColorPiel.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBusquedaColorPiel.id);
        }
        if (myBusquedaColorPiel.idBusqueda == null)
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaColorPiel.idBusqueda);
        }
        if (myBusquedaColorPiel.idClaseColorPiel == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseColorPiel", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseColorPiel", myBusquedaColorPiel.idClaseColorPiel);
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
/// Deletes a BusquedaColorPiel from the database.
/// </summary>
/// <param name="id">The id of the BusquedaColorPiel to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(decimal id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorPielDeleteSingleItem", myConnection))
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
/// Deletes las BusquedaColorPiel de una Busqueda from the database.
/// </summary>
/// <param name="id">The id of the BusquedaColorPiel to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BusquedaColorPielDeleteItemByIdBusqueda", myConnection))
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
/// Initializes a new instance of the BusquedaColorPiel class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaColorPiel FillDataRecord(IDataRecord myDataRecord )
{
BusquedaColorPiel myBusquedaColorPiel = new BusquedaColorPiel();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaColorPiel.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
{
myBusquedaColorPiel.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseColorPiel")))
{
myBusquedaColorPiel.idClaseColorPiel = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseColorPiel"));
}
return myBusquedaColorPiel;
}
}

 } 
