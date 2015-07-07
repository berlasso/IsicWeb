using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The BusquedaCalvicieDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaCalvicie objects.
/// </summary>
public partial class BusquedaCalvicieDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaCalvicie from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaCalvicie in the database.</param>
/// <returns>An BusquedaCalvicie when the id was found in the database, or null otherwise.</returns>
public static BusquedaCalvicie GetItem(decimal id)
{
BusquedaCalvicie myBusquedaCalvicie = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaCalvicieSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaCalvicie = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaCalvicie;
}
}

/// <summary>
/// Returns a list with BusquedaCalvicie objects.
/// </summary>
/// <returns>A generics List with the BusquedaCalvicie objects.</returns>
public static BusquedaCalvicieList GetList()
{
BusquedaCalvicieList tempList = new BusquedaCalvicieList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaCalvicieSelectList", myConnection))
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
/// Returns a list with BusquedaCalvicie objects.
/// </summary>
/// <returns>A generics List with the BusquedaCalvicie objects.</returns>
public static BusquedaCalvicieList GetListByidBusqueda(decimal idBusqueda)
{
BusquedaCalvicieList tempList = new BusquedaCalvicieList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaCalvicieSelectListByidBusqueda", myConnection))
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
/// Returns a list with BusquedaCalvicie objects.
/// </summary>
/// <returns>A generics List with the BusquedaCalvicie objects.</returns>
public static BusquedaCalvicieList GetListByidClaseCalvicie(int idClaseCalvicie)
{
BusquedaCalvicieList tempList = new BusquedaCalvicieList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaCalvicieSelectListByidClaseCalvicie", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseCalvicie", idClaseCalvicie);
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
/// Saves a BusquedaCalvicie in the database.
/// </summary>
/// <param name="myBusquedaCalvicie">The BusquedaCalvicie instance to save.</param>
/// <returns>The new id if the BusquedaCalvicie is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaCalvicie myBusquedaCalvicie)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaCalvicieInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaCalvicie.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaCalvicie.id);
}
if (myBusquedaCalvicie.idBusqueda == null){
myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaCalvicie.idBusqueda);
}
if (myBusquedaCalvicie.idClaseCalvicie == null){
myCommand.Parameters.AddWithValue("@idClaseCalvicie", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseCalvicie", myBusquedaCalvicie.idClaseCalvicie);
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
/// Saves a BusquedaCalvicie in the database.
/// </summary>
/// <param name="myBusquedaCalvicie">The BusquedaCalvicie instance to save.</param>
/// <returns>The new id if the BusquedaCalvicie is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaCalvicie myBusquedaCalvicie, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("BusquedaCalvicieInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
    try
    {
        myCommand.CommandText = "BusquedaCalvicieInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();

        if (myBusquedaCalvicie.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBusquedaCalvicie.id);
        }
        if (myBusquedaCalvicie.idBusqueda == null)
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaCalvicie.idBusqueda);
        }
        if (myBusquedaCalvicie.idClaseCalvicie == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseCalvicie", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseCalvicie", myBusquedaCalvicie.idClaseCalvicie);
        }

        DbParameter returnValue;
        returnValue = myCommand.CreateParameter();
        returnValue.Direction = ParameterDirection.ReturnValue;
        myCommand.Parameters.Add(returnValue);

        //myConnection.Open();
        myCommand.ExecuteNonQuery();
        result = Convert.ToInt32(returnValue.Value);
        //        myConnection.Close();
        //    }
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
/// Deletes a BusquedaCalvicie from the database.
/// </summary>
/// <param name="id">The id of the BusquedaCalvicie to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(decimal id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaCalvicieDeleteSingleItem", myConnection))
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
/// Deletes todas BusquedaCalvicie  de una búsqueda determinada from the database.
/// </summary>
/// <param name="id">The idBusqueda of the BusquedaCalvicie to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BusquedaCalvicieDeleteItemByIdBusqueda", myConnection))
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
/// Initializes a new instance of the BusquedaCalvicie class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaCalvicie FillDataRecord(IDataRecord myDataRecord )
{
BusquedaCalvicie myBusquedaCalvicie = new BusquedaCalvicie();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaCalvicie.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
{
myBusquedaCalvicie.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseCalvicie")))
{
myBusquedaCalvicie.idClaseCalvicie = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseCalvicie"));
}
return myBusquedaCalvicie;
}
}

 } 
