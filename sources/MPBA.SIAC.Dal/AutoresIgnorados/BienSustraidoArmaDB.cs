using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BienSustraidoArmaDB class is responsible for interacting with the database to retrieve and store information
/// about BienSustraidoArma objects.
/// </summary>
public partial class BienSustraidoArmaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BienSustraidoArma from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienSustraidoArma in the database.</param>
/// <returns>An BienSustraidoArma when the id was found in the database, or null otherwise.</returns>
public static BienSustraidoArma GetItem(int id)
{
BienSustraidoArma myBienSustraidoArma = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoArmaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBienSustraidoArma = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBienSustraidoArma;
}
}

/// <summary>
/// Gets an instance of BienSustraidoArma from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienesSustraidos in the database.</param>
/// <returns>An BienSustraidoArma when the id was found in the database, or null otherwise.</returns>
public static BienSustraidoArma GetItemByBienSustraido(int idBienSustraido)
{
    BienSustraidoArma myBienSustraidoArma = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienesSustraidosArmaSelectSingleItemByBienSustraido", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idBienSustraido", idBienSustraido);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myBienSustraidoArma = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myBienSustraidoArma;
    }
}

/// <summary>
/// Returns a list with BienSustraidoArma objects.
/// </summary>
/// <returns>A generics List with the BienSustraidoArma objects.</returns>
public static BienSustraidoArmaList GetList()
{
BienSustraidoArmaList tempList = new BienSustraidoArmaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoArmaSelectList", myConnection))
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
/// Returns a list with BienSustraidoArma objects.
/// </summary>
/// <returns>A generics List with the BienSustraidoArma objects.</returns>
public static BienSustraidoArmaList GetListByidNNBienSustraido(int idNNBienSustraido)
{
    BienSustraidoArmaList tempList = new BienSustraidoArmaList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienSustraidoArmaSelectListByidNNBienSustraido", myConnection))
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
/// Saves a BienSustraidoArma in the database.
/// </summary>
/// <param name="myBienSustraidoArma">The BienSustraidoArma instance to save.</param>
/// <returns>The new id if the BienSustraidoArma is new in the database or the existing id when an item was updated.</returns>
public static int Save(BienSustraidoArma myBienSustraidoArma)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoArmaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBienSustraidoArma.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBienSustraidoArma.id);
}
if (myBienSustraidoArma.idNNBienSustraido == null){
myCommand.Parameters.AddWithValue("@idNNBienSustraido", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienSustraidoArma.idNNBienSustraido);
}
if (string.IsNullOrEmpty(myBienSustraidoArma.Marca))
{
myCommand.Parameters.AddWithValue("@marca", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@marca", myBienSustraidoArma.Marca);
}
if (myBienSustraidoArma.clase_tipo == null){
myCommand.Parameters.AddWithValue("@clase_tipo", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@clase_tipo", myBienSustraidoArma.clase_tipo);
}
if (string.IsNullOrEmpty(myBienSustraidoArma.NroSerie))
{
myCommand.Parameters.AddWithValue("@nroSerie", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@nroSerie", myBienSustraidoArma.NroSerie);
}
if (myBienSustraidoArma.diametro_calibre == null){
myCommand.Parameters.AddWithValue("@diametro_calibre", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@diametro_calibre", myBienSustraidoArma.diametro_calibre);
}
if (myBienSustraidoArma.Baja == null){
myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@baja", myBienSustraidoArma.Baja);
}
if (string.IsNullOrEmpty(myBienSustraidoArma.idUsuarioUltimaModificacion))
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienSustraidoArma.idUsuarioUltimaModificacion);
}
if (myBienSustraidoArma.FechaUltimaModificacion == null){
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienSustraidoArma.FechaUltimaModificacion);
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
/// Saves a BienSustraidoArma in the database.
/// </summary>
/// <param name="myBienSustraidoArma">The BienSustraidoArma instance to save.</param>
/// <returns>The new id if the BienSustraidoArma is new in the database or the existing id when an item was updated.</returns>
public static int Save(BienSustraidoArma myBienSustraidoArma, SqlCommand myCommand)
{
    int result = 0;
    try{
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("BienSustraidoArmaInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "BienSustraidoArmaInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();
            if (myBienSustraidoArma.id == -1)
            {
                myCommand.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@id", myBienSustraidoArma.id);
            }
            if (myBienSustraidoArma.idNNBienSustraido == null)
            {
                myCommand.Parameters.AddWithValue("@idNNBienSustraido", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienSustraidoArma.idNNBienSustraido);
            }
            if (string.IsNullOrEmpty(myBienSustraidoArma.Marca))
            {
                myCommand.Parameters.AddWithValue("@marca", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@marca", myBienSustraidoArma.Marca);
            }
            if (myBienSustraidoArma.clase_tipo == null)
            {
                myCommand.Parameters.AddWithValue("@clase_tipo", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@clase_tipo", myBienSustraidoArma.clase_tipo);
            }
            if (string.IsNullOrEmpty(myBienSustraidoArma.NroSerie))
            {
                myCommand.Parameters.AddWithValue("@nroSerie", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@nroSerie", myBienSustraidoArma.NroSerie);
            }
            if (myBienSustraidoArma.diametro_calibre == null)
            {
                myCommand.Parameters.AddWithValue("@diametro_calibre", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@diametro_calibre", myBienSustraidoArma.diametro_calibre);
            }
            if (myBienSustraidoArma.Baja == null)
            {
                myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@baja", myBienSustraidoArma.Baja);
            }
            if (string.IsNullOrEmpty(myBienSustraidoArma.idUsuarioUltimaModificacion))
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienSustraidoArma.idUsuarioUltimaModificacion);
            }
            if (myBienSustraidoArma.FechaUltimaModificacion == null)
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienSustraidoArma.FechaUltimaModificacion);
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
    } // try
    catch (Exception e)
    {
        //tr.Rollback();
        throw e;
    }

   
    return result;
}

/// <summary>
/// Deletes a BienSustraidoArma from the database.
/// </summary>
/// <param name="id">The id of the BienSustraidoArma to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienSustraidoArmaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BienSustraidoArma class and fills it with the data fom the IDataRecord.
/// </summary>
private static BienSustraidoArma FillDataRecord(IDataRecord myDataRecord )
{
BienSustraidoArma myBienSustraidoArma = new BienSustraidoArma();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBienSustraidoArma.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idNNBienSustraido")))
{
myBienSustraidoArma.idNNBienSustraido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idNNBienSustraido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Marca")))
{
myBienSustraidoArma.Marca = myDataRecord.GetString(myDataRecord.GetOrdinal("Marca"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("clase_tipo")))
{
myBienSustraidoArma.clase_tipo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("clase_tipo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NroSerie")))
{
myBienSustraidoArma.NroSerie = myDataRecord.GetString(myDataRecord.GetOrdinal("NroSerie"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("diametro_calibre")))
{
myBienSustraidoArma.diametro_calibre = myDataRecord.GetInt32(myDataRecord.GetOrdinal("diametro_calibre"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myBienSustraidoArma.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
{
myBienSustraidoArma.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myBienSustraidoArma.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
return myBienSustraidoArma;
}
}

 } 
