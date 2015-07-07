using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The MailsAsociadosPersonasBuscadasDB class is responsible for interacting with the database to retrieve and store information
/// about MailsAsociadosPersonasBuscadas objects.
/// </summary>
public partial class MailsAsociadosPersonasBuscadasDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of MailsAsociadosPersonasBuscadas from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the MailsAsociadosPersonasBuscadas in the database.</param>
/// <returns>An MailsAsociadosPersonasBuscadas when the id was found in the database, or null otherwise.</returns>
public static  MailsAsociadosPersonasBuscadas GetItem(int id)
{
MailsAsociadosPersonasBuscadas myMailsAsociadosPersonasBuscadas = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("MailsAsociadosPersonasBuscadasSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myMailsAsociadosPersonasBuscadas = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myMailsAsociadosPersonasBuscadas;
}
}


/// <summary>
/// Returns a list with MailsAsociadosPersonasBuscadas objects.
/// </summary>
/// <returns>A generics List with the MailsAsociadosPersonasBuscadas objects.</returns>
public static MailsAsociadosPersonasBuscadasList GetList()
{
MailsAsociadosPersonasBuscadasList tempList = new MailsAsociadosPersonasBuscadasList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("MailsAsociadosPersonasBuscadasSelectList", myConnection))
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
/// Returns a list with MailsAsociadosPersonasBuscadas objects.
/// </summary>
/// <returns>A generics List with the MailsAsociadosPersonasBuscadas objects.</returns>
public static MailsAsociadosPersonasBuscadasList GetListByPersonaBuscada(int idPersonaBuscada, int idTipoPersona)
{
    MailsAsociadosPersonasBuscadasList tempList = new MailsAsociadosPersonasBuscadasList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("MailsAsociadosPersonasBuscadasSelectListByPersonaBuscada", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idPersonaBuscada", idPersonaBuscada);
            myCommand.Parameters.AddWithValue("@idTipoPersona", idTipoPersona);


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
/// Saves a MailsAsociadosPersonasBuscadas in the database.
/// </summary>
/// <param name="myMailsAsociadosPersonasBuscadas">The MailsAsociadosPersonasBuscadas instance to save.</param>
/// <returns>The new id if the MailsAsociadosPersonasBuscadas is new in the database or the existing id when an item was updated.</returns>
public static int Save(MailsAsociadosPersonasBuscadas myMailsAsociadosPersonasBuscadas)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("MailsAsociadosPersonasBuscadasInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myMailsAsociadosPersonasBuscadas.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myMailsAsociadosPersonasBuscadas.id);
}
if (myMailsAsociadosPersonasBuscadas.idPersonaBuscada == null){
myCommand.Parameters.AddWithValue("@idPersonaBuscada", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPersonaBuscada", myMailsAsociadosPersonasBuscadas.idPersonaBuscada);
}
if (myMailsAsociadosPersonasBuscadas.idTipoPersona == null){
myCommand.Parameters.AddWithValue("@idTipoPersona", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTipoPersona", myMailsAsociadosPersonasBuscadas.idTipoPersona);
}
if (string.IsNullOrEmpty(myMailsAsociadosPersonasBuscadas.Mail))
{
myCommand.Parameters.AddWithValue("@mail", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@mail", myMailsAsociadosPersonasBuscadas.Mail);
}
if (myMailsAsociadosPersonasBuscadas.seleccionado == null){
myCommand.Parameters.AddWithValue("@seleccionado", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@seleccionado", myMailsAsociadosPersonasBuscadas.seleccionado);
}
if (string.IsNullOrEmpty(myMailsAsociadosPersonasBuscadas.Apellido))
{
myCommand.Parameters.AddWithValue("@apellido", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@apellido", myMailsAsociadosPersonasBuscadas.Apellido);
}
if (string.IsNullOrEmpty(myMailsAsociadosPersonasBuscadas.Nombre))
{
myCommand.Parameters.AddWithValue("@nombre", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@nombre", myMailsAsociadosPersonasBuscadas.Nombre);
}
if (myMailsAsociadosPersonasBuscadas.FechaAlta == null){
myCommand.Parameters.AddWithValue("@fechaAlta", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaAlta", myMailsAsociadosPersonasBuscadas.FechaAlta);
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
/// Deletes a MailsAsociadosPersonasBuscadas from the database.
/// </summary>
/// <param name="id">The id of the MailsAsociadosPersonasBuscadas to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("MailsAsociadosPersonasBuscadasDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the MailsAsociadosPersonasBuscadas class and fills it with the data fom the IDataRecord.
/// </summary>
private static MailsAsociadosPersonasBuscadas FillDataRecord(IDataRecord myDataRecord )
{
MailsAsociadosPersonasBuscadas myMailsAsociadosPersonasBuscadas = new MailsAsociadosPersonasBuscadas();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersonaBuscada")))
{
myMailsAsociadosPersonasBuscadas.idPersonaBuscada = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPersonaBuscada"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoPersona")))
{
myMailsAsociadosPersonasBuscadas.idTipoPersona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoPersona"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Mail")))
{
myMailsAsociadosPersonasBuscadas.Mail = myDataRecord.GetString(myDataRecord.GetOrdinal("Mail"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("seleccionado")))
{
myMailsAsociadosPersonasBuscadas.seleccionado = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("seleccionado"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Apellido")))
{
myMailsAsociadosPersonasBuscadas.Apellido = myDataRecord.GetString(myDataRecord.GetOrdinal("Apellido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Nombre")))
{
myMailsAsociadosPersonasBuscadas.Nombre = myDataRecord.GetString(myDataRecord.GetOrdinal("Nombre"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaAlta")))
{
myMailsAsociadosPersonasBuscadas.FechaAlta = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaAlta"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myMailsAsociadosPersonasBuscadas.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
return myMailsAsociadosPersonasBuscadas;
}
}

 } 
