using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The BusquedaColorOjosDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaColorOjos objects.
/// </summary>
public partial class BusquedaColorOjosDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaColorOjos from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaColorOjos in the database.</param>
/// <returns>An BusquedaColorOjos when the id was found in the database, or null otherwise.</returns>
public static BusquedaColorOjos GetItem(decimal id)
{
BusquedaColorOjos myBusquedaColorOjos = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorOjosSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaColorOjos = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaColorOjos;
}
}

/// <summary>
/// Returns a list with BusquedaColorOjos objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorOjos objects.</returns>
public static BusquedaColorOjosList GetList()
{
BusquedaColorOjosList tempList = new BusquedaColorOjosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorOjosSelectList", myConnection))
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
/// Returns a list with BusquedaColorOjos objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorOjos objects.</returns>
public static BusquedaColorOjosList GetListByidBusqueda(decimal idBusqueda)
{
BusquedaColorOjosList tempList = new BusquedaColorOjosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorOjosSelectListByidBusqueda", myConnection))
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
/// Returns a list with BusquedaColorOjos objects.
/// </summary>
/// <returns>A generics List with the BusquedaColorOjos objects.</returns>
public static BusquedaColorOjosList GetListByidClaseColorOjos(int idClaseColorOjos)
{
BusquedaColorOjosList tempList = new BusquedaColorOjosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorOjosSelectListByidClaseColorOjos", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseColorOjos", idClaseColorOjos);
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
/// Saves a BusquedaColorOjos in the database.
/// </summary>
/// <param name="myBusquedaColorOjos">The BusquedaColorOjos instance to save.</param>
/// <returns>The new id if the BusquedaColorOjos is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaColorOjos myBusquedaColorOjos, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //using (SqlCommand myCommand = new SqlCommand("BusquedaColorOjosInsertUpdateSingleItem", myConnection))
    //{
    //myCommand.CommandType = CommandType.StoredProcedure;
   try
   {
    myCommand.CommandText = "BusquedaColorOjosInsertUpdateSingleItem";
    myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.Parameters.Clear();
    
        if (myBusquedaColorOjos.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBusquedaColorOjos.id);
        }
        if (myBusquedaColorOjos.idBusqueda == null)
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaColorOjos.idBusqueda);
        }
        if (myBusquedaColorOjos.idClaseColorOjos == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseColorOjos", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseColorOjos", myBusquedaColorOjos.idClaseColorOjos);
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
/// Deletes a BusquedaColorOjos from the database.
/// </summary>
/// <param name="id">The id of the BusquedaColorOjos to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(decimal id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaColorOjosDeleteSingleItem", myConnection))
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
/// Deletes las BusquedaColorOjos de una Busqueda from the database.
/// </summary>
/// <param name="id">The idBusqueda of the BusquedaColorOjos to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BusquedaColorOjosDeleteItemByIdBusqueda", myConnection))
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
/// Initializes a new instance of the BusquedaColorOjos class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaColorOjos FillDataRecord(IDataRecord myDataRecord )
{
BusquedaColorOjos myBusquedaColorOjos = new BusquedaColorOjos();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaColorOjos.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
{
myBusquedaColorOjos.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseColorOjos")))
{
myBusquedaColorOjos.idClaseColorOjos = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseColorOjos"));
}
return myBusquedaColorOjos;
}
}

 } 
