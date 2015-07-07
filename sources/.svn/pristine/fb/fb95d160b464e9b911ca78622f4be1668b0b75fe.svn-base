using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BienSustraidoTelefonoDB class is responsible for interacting with the database to retrieve and store information
/// about BienSustraidoTelefono objects.
/// </summary>
public partial class BienSustraidoTelefonoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BienSustraidoTelefono from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienSustraidoTelefono in the database.</param>
/// <returns>An BienSustraidoTelefono when the id was found in the database, or null otherwise.</returns>
public static BienSustraidoTelefono GetItem(int id)
{
BienSustraidoTelefono myBienSustraidoTelefono = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoTelefonoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBienSustraidoTelefono = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBienSustraidoTelefono;
}
}

/// <summary>
/// Gets an instance of BienSustraidoTelefono from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienSustraidoTelefono in the database.</param>
/// <returns>An BienSustraidoTelefono when the id was found in the database, or null otherwise.</returns>
public static BienSustraidoTelefono GetItemByBienSustraido(int idBienSustraido)
{
    BienSustraidoTelefono myBienSustraidoTelefono = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienSustraidoTelefonoSelectSingleItemByBienSustraido", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idBienSustraido", idBienSustraido);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myBienSustraidoTelefono = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myBienSustraidoTelefono;
    }
}

/// <summary>
/// Returns a list with BienSustraidoTelefono objects.
/// </summary>
/// <returns>A generics List with the BienSustraidoTelefono objects.</returns>
public static BienSustraidoTelefonoList GetList()
{
BienSustraidoTelefonoList tempList = new BienSustraidoTelefonoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoTelefonoSelectList", myConnection))
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
/// Returns a list with BienSustraidoTelefono objects.
/// </summary>
/// <returns>A generics List with the BienSustraidoTelefono objects.</returns>
public static BienSustraidoTelefonoList GetListByidNNBienSustraido(int idNNBienSustraido)
{
    BienSustraidoTelefonoList tempList = new BienSustraidoTelefonoList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienSustraidoTelefonoSelectListByidNNBienSustraido", myConnection))
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
/// Saves a BienSustraidoTelefono in the database.
/// </summary>
/// <param name="myBienSustraidoTelefono">The BienSustraidoTelefono instance to save.</param>
/// <returns>The new id if the BienSustraidoTelefono is new in the database or the existing id when an item was updated.</returns>
public static int Save(BienSustraidoTelefono myBienSustraidoTelefono)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
    using (SqlCommand myCommand = new SqlCommand("BienSustraidoTelefonoSelectListByidNNBienSustraido", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBienSustraidoTelefono.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBienSustraidoTelefono.id);
}
if (myBienSustraidoTelefono.idNNBienSustraido == null){
myCommand.Parameters.AddWithValue("@idNNBienSustraido", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienSustraidoTelefono.idNNBienSustraido);
}
if (string.IsNullOrEmpty(myBienSustraidoTelefono.Marca))
{
myCommand.Parameters.AddWithValue("@marca", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@marca", myBienSustraidoTelefono.Marca);
}
if (string.IsNullOrEmpty(myBienSustraidoTelefono.Nro))
{
myCommand.Parameters.AddWithValue("@nro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@nro", myBienSustraidoTelefono.Nro);
}
if (string.IsNullOrEmpty(myBienSustraidoTelefono.NroSerie))
{
myCommand.Parameters.AddWithValue("@nroSerie", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@nroSerie", myBienSustraidoTelefono.NroSerie);
}
if (string.IsNullOrEmpty(myBienSustraidoTelefono.IMEI))
{
myCommand.Parameters.AddWithValue("@iMEI", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@iMEI", myBienSustraidoTelefono.IMEI);
}
if (myBienSustraidoTelefono.Baja == null){
myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@baja", myBienSustraidoTelefono.Baja);
}
if (string.IsNullOrEmpty(myBienSustraidoTelefono.idUsuarioUltimaModificacion))
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienSustraidoTelefono.idUsuarioUltimaModificacion);
}
if (myBienSustraidoTelefono.FechaUltimaModificacion == null){
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienSustraidoTelefono.FechaUltimaModificacion);
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

public static int Save(BienSustraidoTelefono myBienSustraidoTelefono, SqlCommand myCommand)
{
    int result = 0;
    try{
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("BienSustraidoTelefonoInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "BienSustraidoTelefonoInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();

            if (myBienSustraidoTelefono.id == -1)
            {
                myCommand.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@id", myBienSustraidoTelefono.id);
            }
            if (myBienSustraidoTelefono.idNNBienSustraido == null)
            {
                myCommand.Parameters.AddWithValue("@idNNBienSustraido", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienSustraidoTelefono.idNNBienSustraido);
            }
            if (string.IsNullOrEmpty(myBienSustraidoTelefono.Marca))
            {
                myCommand.Parameters.AddWithValue("@marca", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@marca", myBienSustraidoTelefono.Marca);
            }
            if (string.IsNullOrEmpty(myBienSustraidoTelefono.Nro))
            {
                myCommand.Parameters.AddWithValue("@nro", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@nro", myBienSustraidoTelefono.Nro);
            }
            if (string.IsNullOrEmpty(myBienSustraidoTelefono.NroSerie))
            {
                myCommand.Parameters.AddWithValue("@nroSerie", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@nroSerie", myBienSustraidoTelefono.NroSerie);
            }
            if (string.IsNullOrEmpty(myBienSustraidoTelefono.IMEI))
            {
                myCommand.Parameters.AddWithValue("@iMEI", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@iMEI", myBienSustraidoTelefono.IMEI);
            }
            if (myBienSustraidoTelefono.Baja == null)
            {
                myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@baja", myBienSustraidoTelefono.Baja);
            }
            if (string.IsNullOrEmpty(myBienSustraidoTelefono.idUsuarioUltimaModificacion))
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienSustraidoTelefono.idUsuarioUltimaModificacion);
            }
            if (myBienSustraidoTelefono.FechaUltimaModificacion == null)
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienSustraidoTelefono.FechaUltimaModificacion);
            }

            DbParameter returnValue;
            returnValue = myCommand.CreateParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            myCommand.Parameters.Add(returnValue);

            //myConnection.Open();
            myCommand.ExecuteNonQuery();
            result = Convert.ToInt32(returnValue.Value);
            //myConnection.Close();
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
/// Deletes a BienSustraidoTelefono from the database.
/// </summary>
/// <param name="id">The id of the BienSustraidoTelefono to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoTelefonoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BienSustraidoTelefono class and fills it with the data fom the IDataRecord.
/// </summary>
private static BienSustraidoTelefono FillDataRecord(IDataRecord myDataRecord )
{
BienSustraidoTelefono myBienSustraidoTelefono = new BienSustraidoTelefono();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBienSustraidoTelefono.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idNNBienSustraido")))
{
myBienSustraidoTelefono.idNNBienSustraido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idNNBienSustraido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Marca")))
{
myBienSustraidoTelefono.Marca = myDataRecord.GetString(myDataRecord.GetOrdinal("Marca"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Nro")))
{
myBienSustraidoTelefono.Nro = myDataRecord.GetString(myDataRecord.GetOrdinal("Nro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NroSerie")))
{
myBienSustraidoTelefono.NroSerie = myDataRecord.GetString(myDataRecord.GetOrdinal("NroSerie"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IMEI")))
{
myBienSustraidoTelefono.IMEI = myDataRecord.GetString(myDataRecord.GetOrdinal("IMEI"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myBienSustraidoTelefono.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
{
myBienSustraidoTelefono.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myBienSustraidoTelefono.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
return myBienSustraidoTelefono;
}
}

 } 
