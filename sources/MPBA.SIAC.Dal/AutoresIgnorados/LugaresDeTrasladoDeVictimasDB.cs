using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The LugaresDeTrasladoDeVictimasDB class is responsible for interacting with the database to retrieve and store information
/// about LugaresDeTrasladoDeVictimas objects.
/// </summary>
public partial class LugaresDeTrasladoDeVictimasDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of LugaresDeTrasladoDeVictimas from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the LugaresDeTrasladoDeVictimas in the database.</param>
/// <returns>An LugaresDeTrasladoDeVictimas when the id was found in the database, or null otherwise.</returns>
public static LugaresDeTrasladoDeVictimas GetItem(int id)
{
LugaresDeTrasladoDeVictimas myLugaresDeTrasladoDeVictimas = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("LugaresDeTrasladoDeVictimasSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myLugaresDeTrasladoDeVictimas = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myLugaresDeTrasladoDeVictimas;
}
}

/// <summary>
/// Returns a list with LugaresDeTrasladoDeVictimas objects.
/// </summary>
/// <returns>A generics List with the LugaresDeTrasladoDeVictimas objects.</returns>
public static LugaresDeTrasladoDeVictimasList GetList()
{
LugaresDeTrasladoDeVictimasList tempList = new LugaresDeTrasladoDeVictimasList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("LugaresDeTrasladoDeVictimasSelectList", myConnection))
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
/// Returns a list with LugaresDeTrasladoDeVictimas objects.
/// </summary>
/// <returns>A generics List with the LugaresDeTrasladoDeVictimas objects.</returns>
public static LugaresDeTrasladoDeVictimasList GetListByidDelito(int idDelito)
{
LugaresDeTrasladoDeVictimasList tempList = new LugaresDeTrasladoDeVictimasList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("LugaresDeTrasladoDeVictimasSelectListByidDelito", myConnection))
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
/// Saves a LugaresDeTrasladoDeVictimas in the database.
/// </summary>
/// <param name="myLugaresDeTrasladoDeVictimas">The LugaresDeTrasladoDeVictimas instance to save.</param>
/// <returns>The new id if the LugaresDeTrasladoDeVictimas is new in the database or the existing id when an item was updated.</returns>
public static int Save(LugaresDeTrasladoDeVictimas myLugaresDeTrasladoDeVictimas)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("LugaresDeTrasladoDeVictimasInsertUpdateSingleItem", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;

            if (myLugaresDeTrasladoDeVictimas.id == -1)
            {
                myCommand.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@id", myLugaresDeTrasladoDeVictimas.id);
            }
            if (string.IsNullOrEmpty(myLugaresDeTrasladoDeVictimas.idCausa))
            {
                myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idCausa", myLugaresDeTrasladoDeVictimas.idCausa);
            }

            myCommand.Parameters.AddWithValue("@idDelito", myLugaresDeTrasladoDeVictimas.idDelito);


            myCommand.Parameters.AddWithValue("@idLocalidad", myLugaresDeTrasladoDeVictimas.idLocalidad);

            myCommand.Parameters.AddWithValue("@baja", myLugaresDeTrasladoDeVictimas.Baja);
            
            if (myLugaresDeTrasladoDeVictimas.FechaUltimaModificacion == null)
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myLugaresDeTrasladoDeVictimas.FechaUltimaModificacion);
            }
            if (string.IsNullOrEmpty(myLugaresDeTrasladoDeVictimas.UsuarioUltimaModificacion))
            {
                myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", myLugaresDeTrasladoDeVictimas.UsuarioUltimaModificacion);
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

public static int Save(LugaresDeTrasladoDeVictimas myLugaresDeTrasladoDeVictimas, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("LugaresDeTrasladoDeVictimasInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
    try
    {
        myCommand.CommandText = "LugaresDeTrasladoDeVictimasInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();


        if (myLugaresDeTrasladoDeVictimas.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myLugaresDeTrasladoDeVictimas.id);
        }
        if (string.IsNullOrEmpty(myLugaresDeTrasladoDeVictimas.idCausa))
        {
            myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idCausa", myLugaresDeTrasladoDeVictimas.idCausa);
        }

        myCommand.Parameters.AddWithValue("@idDelito", myLugaresDeTrasladoDeVictimas.idDelito);


        myCommand.Parameters.AddWithValue("@idLocalidad", myLugaresDeTrasladoDeVictimas.idLocalidad);

        myCommand.Parameters.AddWithValue("@baja", myLugaresDeTrasladoDeVictimas.Baja);
        
        if (myLugaresDeTrasladoDeVictimas.FechaUltimaModificacion == null)
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myLugaresDeTrasladoDeVictimas.FechaUltimaModificacion);
        }
        if (string.IsNullOrEmpty(myLugaresDeTrasladoDeVictimas.UsuarioUltimaModificacion))
        {
            myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", myLugaresDeTrasladoDeVictimas.UsuarioUltimaModificacion);
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
/// Deletes a LugaresDeTrasladoDeVictimas from the database.
/// </summary>
/// <param name="id">The id of the LugaresDeTrasladoDeVictimas to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("LugaresDeTrasladoDeVictimasDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the LugaresDeTrasladoDeVictimas class and fills it with the data fom the IDataRecord.
/// </summary>
private static LugaresDeTrasladoDeVictimas FillDataRecord(IDataRecord myDataRecord )
{
LugaresDeTrasladoDeVictimas myLugaresDeTrasladoDeVictimas = new LugaresDeTrasladoDeVictimas();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myLugaresDeTrasladoDeVictimas.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCausa")))
{
myLugaresDeTrasladoDeVictimas.idCausa = myDataRecord.GetString(myDataRecord.GetOrdinal("idCausa"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDelito")))
{
myLugaresDeTrasladoDeVictimas.idDelito = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDelito"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLocalidad")))
{
myLugaresDeTrasladoDeVictimas.idLocalidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLocalidad"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myLugaresDeTrasladoDeVictimas.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myLugaresDeTrasladoDeVictimas.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsuarioUltimaModificacion")))
{
myLugaresDeTrasladoDeVictimas.UsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("UsuarioUltimaModificacion"));
}
return myLugaresDeTrasladoDeVictimas;
}
}

 } 
