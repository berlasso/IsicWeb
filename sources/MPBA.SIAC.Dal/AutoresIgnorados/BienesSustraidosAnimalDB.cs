using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BienesSustraidosAnimalDB class is responsible for interacting with the database to retrieve and store information
/// about BienesSustraidosAnimal objects.
/// </summary>
public partial class BienesSustraidosAnimalDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BienesSustraidosAnimal from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienesSustraidosAnimal in the database.</param>
/// <returns>An BienesSustraidosAnimal when the id was found in the database, or null otherwise.</returns>
public static BienesSustraidosAnimal GetItem(int id)
{
BienesSustraidosAnimal myBienesSustraidosAnimal = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosAnimalSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBienesSustraidosAnimal = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBienesSustraidosAnimal;
}
}

/// <summary>
/// Gets an instance of BienesSustraidosAnimal from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BienesSustraidosAnimal in the database.</param>
/// <returns>An BienesSustraidosAnimal when the id was found in the database, or null otherwise.</returns>
public static BienesSustraidosAnimal GetItemByIdBienSustraido(int idBienSustraido)
{
    BienesSustraidosAnimal myBienesSustraidosAnimal = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BienesSustraidosAnimalSelectSingleItemByBienSustraido", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idBienSustraido", idBienSustraido);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myBienesSustraidosAnimal = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myBienesSustraidosAnimal;
    }
}


/// <summary>
/// Returns a list with BienesSustraidosAnimal objects.
/// </summary>
/// <returns>A generics List with the BienesSustraidosAnimal objects.</returns>
public static BienesSustraidosAnimalList GetList()
{
BienesSustraidosAnimalList tempList = new BienesSustraidosAnimalList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosAnimalSelectList", myConnection))
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
/// Returns a list with BienesSustraidosAnimal objects.
/// </summary>
/// <returns>A generics List with the BienesSustraidosAnimal objects.</returns>
public static BienesSustraidosAnimalList GetListByidNNBienSustraido(int idNNBienSustraido)
{
BienesSustraidosAnimalList tempList = new BienesSustraidosAnimalList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosAnimalSelectListByidNNBienSustraido", myConnection))
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
/// Returns a list with BienesSustraidosAnimal objects.
/// </summary>
/// <returns>A generics List with the BienesSustraidosAnimal objects.</returns>
public static BienesSustraidosAnimalList GetListByidClaseGanado(int idClaseGanado)
{
BienesSustraidosAnimalList tempList = new BienesSustraidosAnimalList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosAnimalSelectListByidClaseGanado", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseGanado", idClaseGanado);
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
/// Saves a BienesSustraidosAnimal in the database.
/// </summary>
/// <param name="myBienesSustraidosAnimal">The BienesSustraidosAnimal instance to save.</param>
/// <returns>The new id if the BienesSustraidosAnimal is new in the database or the existing id when an item was updated.</returns>
public static int Save(BienesSustraidosAnimal myBienesSustraidosAnimal)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosAnimalInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBienesSustraidosAnimal.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBienesSustraidosAnimal.id);
}
myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienesSustraidosAnimal.idNNBienSustraido);

myCommand.Parameters.AddWithValue("@idClaseGanado", myBienesSustraidosAnimal.idClaseGanado);

if (string.IsNullOrEmpty(myBienesSustraidosAnimal.Marca))
{
myCommand.Parameters.AddWithValue("@marca", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@marca", myBienesSustraidosAnimal.Marca);
}

myCommand.Parameters.AddWithValue("@cantidad", myBienesSustraidosAnimal.Cantidad);

myCommand.Parameters.AddWithValue("@baja", myBienesSustraidosAnimal.Baja);

if (string.IsNullOrEmpty(myBienesSustraidosAnimal.idUsuarioUltimaModificacion))
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienesSustraidosAnimal.idUsuarioUltimaModificacion);
}
if (myBienesSustraidosAnimal.FechaUltimaModificacion == null){
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienesSustraidosAnimal.FechaUltimaModificacion);
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

public static int Save(BienesSustraidosAnimal myBienesSustraidosAnimal, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("BienesSustraidosAnimalInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
    try
    {
        myCommand.CommandText = "BienesSustraidosAnimalInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();

        if (myBienesSustraidosAnimal.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBienesSustraidosAnimal.id);
        }
        myCommand.Parameters.AddWithValue("@idNNBienSustraido", myBienesSustraidosAnimal.idNNBienSustraido);

        myCommand.Parameters.AddWithValue("@idClaseGanado", myBienesSustraidosAnimal.idClaseGanado);

        if (string.IsNullOrEmpty(myBienesSustraidosAnimal.Marca))
        {
            myCommand.Parameters.AddWithValue("@marca", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@marca", myBienesSustraidosAnimal.Marca);
        }

        myCommand.Parameters.AddWithValue("@cantidad", myBienesSustraidosAnimal.Cantidad);

        myCommand.Parameters.AddWithValue("@baja", myBienesSustraidosAnimal.Baja);

        if (string.IsNullOrEmpty(myBienesSustraidosAnimal.idUsuarioUltimaModificacion))
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myBienesSustraidosAnimal.idUsuarioUltimaModificacion);
        }
        if (myBienesSustraidosAnimal.FechaUltimaModificacion == null)
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBienesSustraidosAnimal.FechaUltimaModificacion);
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
/// Deletes a BienesSustraidosAnimal from the database.
/// </summary>
/// <param name="id">The id of the BienesSustraidosAnimal to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BienesSustraidosAnimalDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BienesSustraidosAnimal class and fills it with the data fom the IDataRecord.
/// </summary>
private static BienesSustraidosAnimal FillDataRecord(IDataRecord myDataRecord )
{
BienesSustraidosAnimal myBienesSustraidosAnimal = new BienesSustraidosAnimal();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBienesSustraidosAnimal.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idNNBienSustraido")))
{
myBienesSustraidosAnimal.idNNBienSustraido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idNNBienSustraido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseGanado")))
{
myBienesSustraidosAnimal.idClaseGanado = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseGanado"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Marca")))
{
myBienesSustraidosAnimal.Marca = myDataRecord.GetString(myDataRecord.GetOrdinal("Marca"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Cantidad")))
{
myBienesSustraidosAnimal.Cantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Cantidad"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myBienesSustraidosAnimal.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
{
myBienesSustraidosAnimal.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myBienesSustraidosAnimal.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
return myBienesSustraidosAnimal;
}
}

 } 
