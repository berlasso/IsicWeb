using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BienesSustraidosDB class is responsible for interacting with the database to retrieve and store information
/// about BienesSustraidos objects.
/// </summary>
public partial class BienesSustraidosDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BienesSustraidos from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienesSustraidos in the database.</param>
/// <returns>An BienesSustraidos when the id was found in the database, or null otherwise.</returns>
public static BienesSustraidos GetItem(int id)
{
BienesSustraidos myBienesSustraidos = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBienesSustraidos = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBienesSustraidos;
}
}

/// <summary>
/// Returns a list with BienesSustraidos objects.
/// </summary>
/// <returns>A generics List with the BienesSustraidos objects.</returns>
public static BienesSustraidosList GetList()
{
BienesSustraidosList tempList = new BienesSustraidosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosSelectList", myConnection))
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
/// Returns a list with BienesSustraidos objects.
/// </summary>
/// <returns>A generics List with the BienesSustraidos objects.</returns>
public static BienesSustraidosList GetListByidDelito(int idDelito)
{
BienesSustraidosList tempList = new BienesSustraidosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosSelectListByidDelito", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idDelito", idDelito);
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
/// Returns a list with BienesSustraidos objects.
/// </summary>
/// <returns>A generics List with the BienesSustraidos objects.</returns>
public static BienesSustraidosList GetListByidClaseBienSustraido(int idClaseBienSustraido)
{
BienesSustraidosList tempList = new BienesSustraidosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosSelectListByidClaseBienSustraido", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseBienSustraido", idClaseBienSustraido);
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
/// Saves a BienesSustraidos in the database.
/// </summary>
/// <param name="myBienesSustraidos">The BienesSustraidos instance to save.</param>
/// <returns>The new id if the BienesSustraidos is new in the database or the existing id when an item was updated.</returns>
public static int Save(BienesSustraidos myBienesSustraidos)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienesSustraidosInsertUpdateSingleItem", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;

            if (myBienesSustraidos.id == -1)
            {
                myCommand.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@id", myBienesSustraidos.id);
            }

            myCommand.Parameters.AddWithValue("@idDelito", myBienesSustraidos.idDelito);

            if (string.IsNullOrEmpty(myBienesSustraidos.idCausa))
            {
                myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idCausa", myBienesSustraidos.idCausa);
            }

            myCommand.Parameters.AddWithValue("@idClaseBienSustraido", myBienesSustraidos.idClaseBienSustraido);

            myCommand.Parameters.AddWithValue("@baja", myBienesSustraidos.Baja);

            if (myBienesSustraidos.FechaUltimaModificacion == null)
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienesSustraidos.FechaUltimaModificacion);
            }
            if (string.IsNullOrEmpty(myBienesSustraidos.idUsuarioUltimaModificacion))
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienesSustraidos.idUsuarioUltimaModificacion);
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

public static int Save(BienesSustraidos myBienesSustraidos, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("BienesSustraidosInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
        try
    {
        myCommand.CommandText = "BienesSustraidosInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();

            if (myBienesSustraidos.id == -1)
            {
                myCommand.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@id", myBienesSustraidos.id);
            }

            myCommand.Parameters.AddWithValue("@idDelito", myBienesSustraidos.idDelito);
            
            if (string.IsNullOrEmpty(myBienesSustraidos.idCausa))
            {
                myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idCausa", myBienesSustraidos.idCausa);
            }

            myCommand.Parameters.AddWithValue("@idClaseBienSustraido", myBienesSustraidos.idClaseBienSustraido);

            myCommand.Parameters.AddWithValue("@baja", myBienesSustraidos.Baja);

            if (myBienesSustraidos.FechaUltimaModificacion == null)
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienesSustraidos.FechaUltimaModificacion);
            }
            if (string.IsNullOrEmpty(myBienesSustraidos.idUsuarioUltimaModificacion))
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienesSustraidos.idUsuarioUltimaModificacion);
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
    } // try
        catch (Exception e)
        {
            //tr.Rollback();
            throw e;
        }

    return result;
}


/// <summary>
/// Deletes a BienesSustraidos from the database.
/// </summary>
/// <param name="id">The id of the BienesSustraidos to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BienesSustraidos class and fills it with the data fom the IDataRecord.
/// </summary>
private static BienesSustraidos FillDataRecord(IDataRecord myDataRecord )
{
BienesSustraidos myBienesSustraidos = new BienesSustraidos();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBienesSustraidos.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDelito")))
{
myBienesSustraidos.idDelito = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDelito"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCausa")))
{
myBienesSustraidos.idCausa = myDataRecord.GetString(myDataRecord.GetOrdinal("idCausa"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseBienSustraido")))
{
myBienesSustraidos.idClaseBienSustraido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseBienSustraido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myBienesSustraidos.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myBienesSustraidos.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
{
myBienesSustraidos.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
}
return myBienesSustraidos;
}
}

 } 
