using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The BusquedaSeniasParticularesDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaSeniasParticulares objects.
/// </summary>
public partial class BusquedaSeniasParticularesDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaSeniasParticulares from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaSeniasParticulares in the database.</param>
/// <returns>An BusquedaSeniasParticulares when the id was found in the database, or null otherwise.</returns>
public static BusquedaSeniasParticulares GetItem(decimal id)
{
BusquedaSeniasParticulares myBusquedaSeniasParticulares = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaSeniasParticularesSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaSeniasParticulares = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaSeniasParticulares;
}
}

/// <summary>
/// Returns a list with BusquedaSeniasParticulares objects.
/// </summary>
/// <returns>A generics List with the BusquedaSeniasParticulares objects.</returns>
public static BusquedaSeniasParticularesList GetList()
{
BusquedaSeniasParticularesList tempList = new BusquedaSeniasParticularesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaSeniasParticularesSelectList", myConnection))
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
/// Returns a list with BusquedaSeniasParticulares objects.
/// </summary>
/// <returns>A generics List with the BusquedaSeniasParticulares objects.</returns>
public static BusquedaSeniasParticularesList GetListByidBusqueda(decimal idBusqueda)
{
BusquedaSeniasParticularesList tempList = new BusquedaSeniasParticularesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaSeniasParticularesSelectListByidBusqueda", myConnection))
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
/// Returns a list with BusquedaSeniasParticulares objects.
/// </summary>
/// <returns>A generics List with the BusquedaSeniasParticulares objects.</returns>
public static BusquedaSeniasParticularesList GetListByidClaseSeniaParticular(int idClaseSeniaParticular)
{
BusquedaSeniasParticularesList tempList = new BusquedaSeniasParticularesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaSeniasParticularesSelectListByidClaseSeniaParticular", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseSeniaParticular", idClaseSeniaParticular);
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
/// Returns a list with BusquedaSeniasParticulares objects.
/// </summary>
/// <returns>A generics List with the BusquedaSeniasParticulares objects.</returns>
public static BusquedaSeniasParticularesList GetListByidUbicacionSeniaParticular(int idUbicacionSeniaParticular)
{
BusquedaSeniasParticularesList tempList = new BusquedaSeniasParticularesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaSeniasParticularesSelectListByidUbicacionSeniaParticular", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", idUbicacionSeniaParticular);
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
/// Saves a BusquedaSeniasParticulares in the database.
/// </summary>
/// <param name="myBusquedaSeniasParticulares">The BusquedaSeniasParticulares instance to save.</param>
/// <returns>The new id if the BusquedaSeniasParticulares is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaSeniasParticulares myBusquedaSeniasParticulares, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //using (SqlCommand myCommand = new SqlCommand("BusquedaSeniasParticularesInsertUpdateSingleItem", myConnection))
    //{
    //myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.CommandText = "BusquedaSeniasParticularesInsertUpdateSingleItem";
    myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.Parameters.Clear();
    try
    {
        if (myBusquedaSeniasParticulares.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBusquedaSeniasParticulares.id);
        }
        if (myBusquedaSeniasParticulares.idBusqueda == null)
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaSeniasParticulares.idBusqueda);
        }
        if (myBusquedaSeniasParticulares.idClaseSeniaParticular == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseSeniaParticular", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseSeniaParticular", myBusquedaSeniasParticulares.idClaseSeniaParticular);
        }
        if (myBusquedaSeniasParticulares.idUbicacionSeniaParticular == null)
        {
            myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", myBusquedaSeniasParticulares.idUbicacionSeniaParticular);
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
    } // try
    catch (Exception e)
    {
        //tr.Rollback();
        throw e;
    }
    return result;
}

/// <summary>
/// Deletes a BusquedaSeniasParticulares from the database.
/// </summary>
/// <param name="id">The id of the BusquedaSeniasParticulares to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(decimal id)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BusquedaSeniasParticularesDeleteSingleItem", myConnection))
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
/// Deletes las BusquedaSeniasParticulares de una Busqueda from the database.
/// </summary>
/// <param name="id">The idBusqueda of the BusquedaSeniasParticulares to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaSeniasParticularesDeleteItemByIdBusqueda", myConnection))
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
/// Initializes a new instance of the BusquedaSeniasParticulares class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaSeniasParticulares FillDataRecord(IDataRecord myDataRecord )
{
BusquedaSeniasParticulares myBusquedaSeniasParticulares = new BusquedaSeniasParticulares();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaSeniasParticulares.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
{
myBusquedaSeniasParticulares.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseSeniaParticular")))
{
myBusquedaSeniasParticulares.idClaseSeniaParticular = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseSeniaParticular"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUbicacionSeniaParticular")))
{
myBusquedaSeniasParticulares.idUbicacionSeniaParticular = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idUbicacionSeniaParticular"));
}
return myBusquedaSeniasParticulares;
}
}

 } 
