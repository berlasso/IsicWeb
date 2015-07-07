using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBFotosDB class is responsible for interacting with the database to retrieve and store information
/// about PBFotos objects.
/// </summary>
public partial class PBFotosDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBFotos from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the PBFotos in the database.</param>
/// <returns>An PBFotos when the id was found in the database, or null otherwise.</returns>
public static PBFotos GetItem(int id)
{
PBFotos myPBFotos = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBFotosSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBFotos = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBFotos;
}
}

/// <summary>
/// Returns a list with PBFotos objects.
/// </summary>
/// <returns>A generics List with the PBFotos objects.</returns>
public static PBFotosList GetList()
{
PBFotosList tempList = new PBFotosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBFotosSelectList", myConnection))
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
/// Returns a list with PBFotos objects.
/// </summary>
/// <returns>A generics List with the PBFotos objects.</returns>
public static PBFotosList GetListByidTipoFoto(int idTipoFoto)
{
PBFotosList tempList = new PBFotosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBFotosSelectListByidTipoFoto", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idTipoFoto", idTipoFoto);
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
/// Returns a list with PBFotos objects.
/// </summary>
/// <returns>A generics List with the PBFotos objects.</returns>
public static PBFotosList GetListByidTablaDestino(int idTablaDestino)
{
PBFotosList tempList = new PBFotosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBFotosSelectListByidTablaDestino", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idTablaDestino", idTablaDestino);
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
/// Saves a PBFotos in the database.
/// </summary>
/// <param name="myPBFotos">The PBFotos instance to save.</param>
/// <returns>The new id if the PBFotos is new in the database or the existing id when an item was updated.</returns>
public static int Save(PBFotos myPBFotos)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBFotosInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBFotos.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBFotos.id);
}
if (myPBFotos.idPersona == null){
myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPersona", myPBFotos.idPersona);
}
if (myPBFotos.idTablaDestino == null){
myCommand.Parameters.AddWithValue("@idTablaDestino", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTablaDestino", myPBFotos.idTablaDestino);
}
if (myPBFotos.Foto == null){
myCommand.Parameters.AddWithValue("@foto", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@foto", myPBFotos.Foto);
}
if (myPBFotos.idTipoFoto == null){
myCommand.Parameters.AddWithValue("@idTipoFoto", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTipoFoto", myPBFotos.idTipoFoto);
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
/// Saves a PBFotos in the database.
/// </summary>
/// <param name="myPBFotos">The PBFotos instance to save.</param>
/// <returns>The new id if the PBFotos is new in the database or the existing id when an item was updated.</returns>
public static int Save(PBFotos myPBFotos, SqlCommand myCommand)
{
    int result = 0;
    try
    {
    
            myCommand.CommandText="PBFotosInsertUpdateSingleItem";
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Clear();
            if (myPBFotos.id == -1)
            {
                myCommand.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@id", myPBFotos.id);
            }
            if (myPBFotos.idPersona == null)
            {
                myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idPersona", myPBFotos.idPersona);
            }
            if (myPBFotos.idTablaDestino == null)
            {
                myCommand.Parameters.AddWithValue("@idTablaDestino", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idTablaDestino", myPBFotos.idTablaDestino);
            }
            if (myPBFotos.Foto == null)
            {
                myCommand.Parameters.AddWithValue("@foto", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@foto", myPBFotos.Foto);
            }
            if (myPBFotos.idTipoFoto == null)
            {
                myCommand.Parameters.AddWithValue("@idTipoFoto", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idTipoFoto", myPBFotos.idTipoFoto);
            }

            DbParameter returnValue;
            returnValue = myCommand.CreateParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            myCommand.Parameters.Add(returnValue);
        myCommand.ExecuteNonQuery();
            //myConnection.Open();
            
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
/// Deletes a PBFotos from the database.
/// </summary>
/// <param name="id">The id of the PBFotos to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBFotosDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBFotos class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBFotos FillDataRecord(IDataRecord myDataRecord )
{
PBFotos myPBFotos = new PBFotos();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myPBFotos.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersona")))
{
myPBFotos.idPersona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPersona"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTablaDestino")))
{
myPBFotos.idTablaDestino = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTablaDestino"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Foto")))
{
    myPBFotos.Foto = (byte[])myDataRecord[myDataRecord.GetOrdinal("Foto")];
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoFoto")))
{
myPBFotos.idTipoFoto = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoFoto"));
}
return myPBFotos;
}

/// <summary>
/// Returns a list with PBFotos objects.
/// </summary>
/// <returns>A generics List with the PBFotos objects of a PersonaDesaparecida(1) o PersonaHallada(2).</returns>
public static PBFotosList GetListByidPersonaYTablaDestino(int idPersona, int idTablaDestino)
{
    PBFotosList tempList = new PBFotosList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PBFotosSelectListByidPersonayTipoPersona", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idPersona", idPersona);
            myCommand.Parameters.AddWithValue("@idTablaDestino", idTablaDestino);
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
/// Returns a list with PBFotos objects.
/// </summary>
/// <returns>A generics List with the PBFotos objects of a PersonaDesaparecida(1) o PersonaHallada(2).</returns>
public static PBFotosList GetListByIppYTablaDestino(string ipp, int idTablaDestino)
{
    PBFotosList tempList = new PBFotosList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PBFotosSelectListByIppyTipoPersona", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@ipp", ipp);
            myCommand.Parameters.AddWithValue("@idTablaDestino", idTablaDestino);
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


}

 } 
