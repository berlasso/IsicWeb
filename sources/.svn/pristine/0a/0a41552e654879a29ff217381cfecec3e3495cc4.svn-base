using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BienSustraidoChequeDB class is responsible for interacting with the database to retrieve and store information
/// about BienSustraidoCheque objects.
/// </summary>
public partial class BienSustraidoChequeDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BienSustraidoCheque from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienSustraidoCheque in the database.</param>
/// <returns>An BienSustraidoCheque when the id was found in the database, or null otherwise.</returns>
public static BienSustraidoCheque GetItem(int id)
{
BienSustraidoCheque myBienSustraidoCheque = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoChequeSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBienSustraidoCheque = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBienSustraidoCheque;
}
}

/// <summary>
/// Gets an instance of BienSustraidoCheque from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienSustraido in the database.</param>
/// <returns>An BienSustraidoCheque when the id was found in the database, or null otherwise.</returns>
public static BienSustraidoCheque GetItemByBienSustraido(int idBienSustraido)
{
    BienSustraidoCheque myBienSustraidoCheque = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienSustraidoChequeSelectSingleItemByBienSustraido", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idBienSustraido", idBienSustraido);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myBienSustraidoCheque = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myBienSustraidoCheque;
    }
}

/// <summary>
/// Returns a list with BienSustraidoCheque objects.
/// </summary>
/// <returns>A generics List with the BienSustraidoCheque objects.</returns>
public static BienSustraidoChequeList GetList()
{
BienSustraidoChequeList tempList = new BienSustraidoChequeList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoChequeSelectList", myConnection))
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
public static BienSustraidoChequeList GetListByidNNBienSustraido(int idNNBienSustraido)
{
    BienSustraidoChequeList tempList = new BienSustraidoChequeList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienSustraidoChequeSelectListByidNNBienSustraido", myConnection))
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
/// Saves a BienSustraidoCheque in the database.
/// </summary>
/// <param name="myBienSustraidoCheque">The BienSustraidoCheque instance to save.</param>
/// <returns>The new id if the BienSustraidoCheque is new in the database or the existing id when an item was updated.</returns>
public static int Save(BienSustraidoCheque myBienSustraidoCheque)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoChequeInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBienSustraidoCheque.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBienSustraidoCheque.id);
}
if (myBienSustraidoCheque.idNNBienSustraido == null){
myCommand.Parameters.AddWithValue("@idNNBienSustraido", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienSustraidoCheque.idNNBienSustraido);
}
if (string.IsNullOrEmpty(myBienSustraidoCheque.Banco))
{
myCommand.Parameters.AddWithValue("@banco", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@banco", myBienSustraidoCheque.Banco);
}
if (myBienSustraidoCheque.monto == null){
myCommand.Parameters.AddWithValue("@monto", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@monto", myBienSustraidoCheque.monto);
}
if (string.IsNullOrEmpty(myBienSustraidoCheque.NroSerie))
{
myCommand.Parameters.AddWithValue("@nroSerie", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@nroSerie", myBienSustraidoCheque.NroSerie);
}
if (myBienSustraidoCheque.idTipoMoneda == null){
myCommand.Parameters.AddWithValue("@idTipoMoneda", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTipoMoneda", myBienSustraidoCheque.idTipoMoneda);
}
if (string.IsNullOrEmpty(myBienSustraidoCheque.descripcionMoneda))
{
myCommand.Parameters.AddWithValue("@descripcionMoneda", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcionMoneda", myBienSustraidoCheque.descripcionMoneda);
}
if (myBienSustraidoCheque.Baja == null){
myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@baja", myBienSustraidoCheque.Baja);
}
if (string.IsNullOrEmpty(myBienSustraidoCheque.idUsuarioUltimaModificacion))
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienSustraidoCheque.idUsuarioUltimaModificacion);
}
if (myBienSustraidoCheque.FechaUltimaModificacion == null){
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienSustraidoCheque.FechaUltimaModificacion);
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

public static int Save(BienSustraidoCheque myBienSustraidoCheque, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("BienSustraidoChequeInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
    try
       
    {
        myCommand.CommandText = "BienSustraidoChequeInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();
        if (myBienSustraidoCheque.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBienSustraidoCheque.id);
        }
        if (myBienSustraidoCheque.idNNBienSustraido == null)
        {
            myCommand.Parameters.AddWithValue("@idNNBienSustraido", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienSustraidoCheque.idNNBienSustraido);
        }
        if (string.IsNullOrEmpty(myBienSustraidoCheque.Banco))
        {
            myCommand.Parameters.AddWithValue("@banco", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@banco", myBienSustraidoCheque.Banco);
        }
        if (myBienSustraidoCheque.monto == null)
        {
            myCommand.Parameters.AddWithValue("@monto", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@monto", myBienSustraidoCheque.monto);
        }
        if (string.IsNullOrEmpty(myBienSustraidoCheque.NroSerie))
        {
            myCommand.Parameters.AddWithValue("@nroSerie", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@nroSerie", myBienSustraidoCheque.NroSerie);
        }
        if (myBienSustraidoCheque.idTipoMoneda == null)
        {
            myCommand.Parameters.AddWithValue("@idTipoMoneda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idTipoMoneda", myBienSustraidoCheque.idTipoMoneda);
        }
        if (string.IsNullOrEmpty(myBienSustraidoCheque.descripcionMoneda))
        {
            myCommand.Parameters.AddWithValue("@descripcionMoneda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@descripcionMoneda", myBienSustraidoCheque.descripcionMoneda);
        }
        if (myBienSustraidoCheque.Baja == null)
        {
            myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@baja", myBienSustraidoCheque.Baja);
        }
        if (string.IsNullOrEmpty(myBienSustraidoCheque.idUsuarioUltimaModificacion))
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienSustraidoCheque.idUsuarioUltimaModificacion);
        }
        if (myBienSustraidoCheque.FechaUltimaModificacion == null)
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienSustraidoCheque.FechaUltimaModificacion);
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
/// Deletes a BienSustraidoCheque from the database.
/// </summary>
/// <param name="id">The id of the BienSustraidoCheque to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoChequeDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BienSustraidoCheque class and fills it with the data fom the IDataRecord.
/// </summary>
private static BienSustraidoCheque FillDataRecord(IDataRecord myDataRecord )
{
BienSustraidoCheque myBienSustraidoCheque = new BienSustraidoCheque();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBienSustraidoCheque.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idNNBienSustraido")))
{
myBienSustraidoCheque.idNNBienSustraido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idNNBienSustraido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Banco")))
{
myBienSustraidoCheque.Banco = myDataRecord.GetString(myDataRecord.GetOrdinal("Banco"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("monto")))
{
myBienSustraidoCheque.monto = myDataRecord.GetFloat(myDataRecord.GetOrdinal("monto"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NroSerie")))
{
myBienSustraidoCheque.NroSerie = myDataRecord.GetString(myDataRecord.GetOrdinal("NroSerie"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoMoneda")))
{
myBienSustraidoCheque.idTipoMoneda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoMoneda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcionMoneda")))
{
myBienSustraidoCheque.descripcionMoneda = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcionMoneda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myBienSustraidoCheque.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
{
myBienSustraidoCheque.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myBienSustraidoCheque.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
return myBienSustraidoCheque;
}
}

 } 
