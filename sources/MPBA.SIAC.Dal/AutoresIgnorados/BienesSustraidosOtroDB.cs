using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BienesSustraidosOtroDB class is responsible for interacting with the database to retrieve and store information
/// about BienesSustraidosOtro objects.
/// </summary>
 public partial class BienesSustraidosOtroDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BienesSustraidosOtro from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienesSustraidosOtro in the database.</param>
/// <returns>An BienesSustraidosOtro when the id was found in the database, or null otherwise.</returns>
public static BienesSustraidosOtro GetItem(int id)
{
BienesSustraidosOtro myBienesSustraidosOtro = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosOtroSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBienesSustraidosOtro = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBienesSustraidosOtro;
}
}

/// <summary>
/// Gets an instance of BienesSustraidosOtro from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienesSustraidosOtro in the database.</param>
/// <returns>An BienesSustraidosOtro when the id was found in the database, or null otherwise.</returns>
public static BienesSustraidosOtro GetItemByBienSustraido(int idBienSustraido)
{
    BienesSustraidosOtro myBienesSustraidosOtro = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienesSustraidosOtroSelectSingleItemByBienSustraido", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idBienSustraido", idBienSustraido);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myBienesSustraidosOtro = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myBienesSustraidosOtro;
    }
}
/// <summary>
/// Returns a list with BienesSustraidosOtro objects.
/// </summary>
/// <returns>A generics List with the BienesSustraidosOtro objects.</returns>
public static BienesSustraidosOtroList GetList()
{
BienesSustraidosOtroList tempList = new BienesSustraidosOtroList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosOtroSelectList", myConnection))
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
/// Returns a list with BienesSustraidosOtro objects.
/// </summary>
/// <returns>A generics List with the BienesSustraidosOtro objects.</returns>
public static BienesSustraidosOtroList GetListByidNNBienSustraido(int idNNBienSustraido)
{
BienesSustraidosOtroList tempList = new BienesSustraidosOtroList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosOtroSelectListByidNNBienSustraido", myConnection))
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
/// Saves a BienesSustraidosOtro in the database.
/// </summary>
/// <param name="myBienesSustraidosOtro">The BienesSustraidosOtro instance to save.</param>
/// <returns>The new id if the BienesSustraidosOtro is new in the database or the existing id when an item was updated.</returns>
public static int Save(BienesSustraidosOtro myBienesSustraidosOtro)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienesSustraidosOtroInsertUpdateSingleItem", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;

            if (myBienesSustraidosOtro.id == -1)
            {
                myCommand.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@id", myBienesSustraidosOtro.id);
            }

            myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienesSustraidosOtro.idNNBienSustraido);

            if (string.IsNullOrEmpty(myBienesSustraidosOtro.Marca))
            {
                myCommand.Parameters.AddWithValue("@marca", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@marca", myBienesSustraidosOtro.Marca);
            }

            myCommand.Parameters.AddWithValue("@cantidad", myBienesSustraidosOtro.Cantidad);

            if (string.IsNullOrEmpty(myBienesSustraidosOtro.NroSerie))
            {
                myCommand.Parameters.AddWithValue("@nroSerie", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@nroSerie", myBienesSustraidosOtro.NroSerie);
            }

            myCommand.Parameters.AddWithValue("@baja", myBienesSustraidosOtro.Baja);

            if (string.IsNullOrEmpty(myBienesSustraidosOtro.idUsuarioUltimaModificacion))
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienesSustraidosOtro.idUsuarioUltimaModificacion);
            }
            if (myBienesSustraidosOtro.FechaUltimaModificacion == null)
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienesSustraidosOtro.FechaUltimaModificacion);
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

public static int Save(BienesSustraidosOtro myBienesSustraidosOtro, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("BienesSustraidosOtroInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
    try
    {
        myCommand.CommandText = "BienesSustraidosOtroInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();


        if (myBienesSustraidosOtro.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBienesSustraidosOtro.id);
        }

        myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienesSustraidosOtro.idNNBienSustraido);

        if (string.IsNullOrEmpty(myBienesSustraidosOtro.Marca))
        {
            myCommand.Parameters.AddWithValue("@marca", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@marca", myBienesSustraidosOtro.Marca);
        }

        myCommand.Parameters.AddWithValue("@cantidad", myBienesSustraidosOtro.Cantidad);

        if (string.IsNullOrEmpty(myBienesSustraidosOtro.NroSerie))
        {
            myCommand.Parameters.AddWithValue("@nroSerie", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@nroSerie", myBienesSustraidosOtro.NroSerie);
        }
       
        myCommand.Parameters.AddWithValue("@baja", myBienesSustraidosOtro.Baja);

        if (string.IsNullOrEmpty(myBienesSustraidosOtro.idUsuarioUltimaModificacion))
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienesSustraidosOtro.idUsuarioUltimaModificacion);
        }
        if (myBienesSustraidosOtro.FechaUltimaModificacion == null)
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienesSustraidosOtro.FechaUltimaModificacion);
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
        //}}
    } // try
    catch (Exception e)
    {
        //tr.Rollback();
        throw e;
    }

    return result;
}


/// <summary>
/// Deletes a BienesSustraidosOtro from the database.
/// </summary>
/// <param name="id">The id of the BienesSustraidosOtro to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosOtroDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BienesSustraidosOtro class and fills it with the data fom the IDataRecord.
/// </summary>
private static BienesSustraidosOtro FillDataRecord(IDataRecord myDataRecord )
{
BienesSustraidosOtro myBienesSustraidosOtro = new BienesSustraidosOtro();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBienesSustraidosOtro.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idNNBienSustraido")))
{
myBienesSustraidosOtro.idNNBienSustraido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idNNBienSustraido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Marca")))
{
myBienesSustraidosOtro.Marca = myDataRecord.GetString(myDataRecord.GetOrdinal("Marca"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Cantidad")))
{
myBienesSustraidosOtro.Cantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Cantidad"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NroSerie")))
{
myBienesSustraidosOtro.NroSerie = myDataRecord.GetString(myDataRecord.GetOrdinal("NroSerie"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myBienesSustraidosOtro.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
{
myBienesSustraidosOtro.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myBienesSustraidosOtro.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
return myBienesSustraidosOtro;
}
}

 } 
