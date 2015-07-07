using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BienSustraidoDineroDB class is responsible for interacting with the database to retrieve and store information
/// about BienSustraidoDinero objects.
/// </summary>
public partial class BienSustraidoDineroDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BienSustraidoDinero from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienSustraidoDinero in the database.</param>
/// <returns>An BienSustraidoDinero when the id was found in the database, or null otherwise.</returns>
public static BienSustraidoDinero GetItem(int id)
{
BienSustraidoDinero myBienSustraidoDinero = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoDineroSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBienSustraidoDinero = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBienSustraidoDinero;
}
}

/// <summary>
/// Gets an instance of BienSustraidoDinero from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienSustraido in the database.</param>
/// <returns>An BienSustraidoDinero when the id was found in the database, or null otherwise.</returns>
public static BienSustraidoDinero GetItemByBienSustraido(int idBienSustraido)
{
    BienSustraidoDinero myBienSustraidoDinero = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienSustraidoDineroSelectSingleItemByBienSustraido", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idBienSustraido", idBienSustraido);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myBienSustraidoDinero = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myBienSustraidoDinero;
    }
}

/// <summary>
/// Returns a list with BienSustraidoDinero objects.
/// </summary>
/// <returns>A generics List with the BienSustraidoDinero objects.</returns>
public static BienSustraidoDineroList GetList()
{
BienSustraidoDineroList tempList = new BienSustraidoDineroList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoDineroSelectList", myConnection))
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
/// Returns a list with BienSustraidoDinero objects.
/// </summary>
/// <returns>A generics List with the BienSustraidoDinero objects.</returns>
public static BienSustraidoDineroList GetListByidNNBienSustraido(int idNNBienSustraido)
{
    BienSustraidoDineroList tempList = new BienSustraidoDineroList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienSustraidoDineroSelectListByidNNBienSustraido", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idNNBienSustraido", idNNBienSustraido);
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
/// Saves a BienSustraidoDinero in the database.
/// </summary>
/// <param name="myBienSustraidoDinero">The BienSustraidoDinero instance to save.</param>
/// <returns>The new id if the BienSustraidoDinero is new in the database or the existing id when an item was updated.</returns>
public static int Save(BienSustraidoDinero myBienSustraidoDinero)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoDineroInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBienSustraidoDinero.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBienSustraidoDinero.id);
}
if (myBienSustraidoDinero.idNNBienSustraido == null){
myCommand.Parameters.AddWithValue("@idNNBienSustraido", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienSustraidoDinero.idNNBienSustraido);
}
if (myBienSustraidoDinero.monto == null){
myCommand.Parameters.AddWithValue("@monto", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@monto", myBienSustraidoDinero.monto);
}
if (myBienSustraidoDinero.idTipoMoneda == null){
myCommand.Parameters.AddWithValue("@idTipoMoneda", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTipoMoneda", myBienSustraidoDinero.idTipoMoneda);
}
if (string.IsNullOrEmpty(myBienSustraidoDinero.descripcionMoneda))
{
myCommand.Parameters.AddWithValue("@descripcionMoneda", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcionMoneda", myBienSustraidoDinero.descripcionMoneda);
}
if (myBienSustraidoDinero.Baja == null){
myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@baja", myBienSustraidoDinero.Baja);
}
if (string.IsNullOrEmpty(myBienSustraidoDinero.idUsuarioUltimaModificacion))
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienSustraidoDinero.idUsuarioUltimaModificacion);
}
if (myBienSustraidoDinero.FechaUltimaModificacion == null){
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienSustraidoDinero.FechaUltimaModificacion);
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

public static int Save(BienSustraidoDinero myBienSustraidoDinero , SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("BienSustraidoDineroInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
    try
    {
        myCommand.CommandText = "BienSustraidoDineroInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();

        if (myBienSustraidoDinero.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBienSustraidoDinero.id);
        }
        if (myBienSustraidoDinero.idNNBienSustraido == null)
        {
            myCommand.Parameters.AddWithValue("@idNNBienSustraido", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienSustraidoDinero.idNNBienSustraido);
        }
        if (myBienSustraidoDinero.monto == null)
        {
            myCommand.Parameters.AddWithValue("@monto", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@monto", myBienSustraidoDinero.monto);
        }
        if (myBienSustraidoDinero.idTipoMoneda == null)
        {
            myCommand.Parameters.AddWithValue("@idTipoMoneda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idTipoMoneda", myBienSustraidoDinero.idTipoMoneda);
        }
        if (string.IsNullOrEmpty(myBienSustraidoDinero.descripcionMoneda))
        {
            myCommand.Parameters.AddWithValue("@descripcionMoneda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@descripcionMoneda", myBienSustraidoDinero.descripcionMoneda);
        }
        if (myBienSustraidoDinero.Baja == null)
        {
            myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@baja", myBienSustraidoDinero.Baja);
        }
        if (string.IsNullOrEmpty(myBienSustraidoDinero.idUsuarioUltimaModificacion))
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienSustraidoDinero.idUsuarioUltimaModificacion);
        }
        if (myBienSustraidoDinero.FechaUltimaModificacion == null)
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienSustraidoDinero.FechaUltimaModificacion);
        }

        DbParameter returnValue;
        returnValue = myCommand.CreateParameter();
        returnValue.Direction = ParameterDirection.ReturnValue;
        myCommand.Parameters.Add(returnValue);

        //myConnection.Open();
        myCommand.ExecuteNonQuery();
        result = Convert.ToInt32(returnValue.Value);
        //myConnection.Close();

    }
    catch (Exception e)
    {
        //tr.Rollback();
        throw e;
    }
    return result;
}

/// <summary>
/// Deletes a BienSustraidoDinero from the database.
/// </summary>
/// <param name="id">The id of the BienSustraidoDinero to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoDineroDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BienSustraidoDinero class and fills it with the data fom the IDataRecord.
/// </summary>
private static BienSustraidoDinero FillDataRecord(IDataRecord myDataRecord )
{
BienSustraidoDinero myBienSustraidoDinero = new BienSustraidoDinero();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBienSustraidoDinero.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idNNBienSustraido")))
{
myBienSustraidoDinero.idNNBienSustraido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idNNBienSustraido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("monto")))
{
myBienSustraidoDinero.monto = myDataRecord.GetFloat(myDataRecord.GetOrdinal("monto"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoMoneda")))
{
myBienSustraidoDinero.idTipoMoneda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoMoneda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcionMoneda")))
{
myBienSustraidoDinero.descripcionMoneda = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcionMoneda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myBienSustraidoDinero.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
{
myBienSustraidoDinero.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myBienSustraidoDinero.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
return myBienSustraidoDinero;
}
}

 } 
