using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
/// <summary>
/// The UsuariosDB class is responsible for interacting with the database to retrieve and store information
/// about Usuarios objects.
/// </summary>
public partial class UsuariosDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of Usuarios from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the Usuarios in the database.</param>
/// <returns>An Usuarios when the id was found in the database, or null otherwise.</returns>
public static Usuarios GetItem(string id)
{
Usuarios myUsuarios = new Usuarios();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("UsuariosSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
    myUsuarios = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myUsuarios;
}
}

/// <summary>
/// Gets an instance of Usuarios from the underlying datasource.
/// </summary>
/// <param name="NombreUsuario">The unique NombreUsuario of the Usuarios in the database.</param>
/// <returns>An Usuarios when the NombreUsuario was found in the database, or null otherwise.</returns>
public static Usuarios GetItemByNombreUsuario(string id)
{
    Usuarios myUsuarios = new Usuarios();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("UsuariosSelectSingleItemByNombreUsuario", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@NombreUsuario", id);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myUsuarios = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myUsuarios;
    }
}





/// <summary>
/// Returns a list with Usuarios objects.
/// </summary>
/// <returns>A generics List with the Usuarios objects.</returns>
public static UsuariosList GetList()
{
UsuariosList tempList = new UsuariosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("UsuariosSelectList", myConnection))
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
/// Returns a list with Usuarios objects.
/// </summary>
/// <returns>A generics List with the Usuarios objects.</returns>
public static UsuariosList GetReferentes()
{
    UsuariosList tempList = new UsuariosList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("UsuariosSelectReferentes", myConnection))
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
/// Returns a list with Usuarios objects.
/// </summary>
/// <returns>A generics List with the Usuarios objects.</returns>
public static UsuariosList GetListByidGrupoUsuario(string idGrupoUsuario)
{
UsuariosList tempList = new UsuariosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("UsuariosSelectListByidGrupoUsuario", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idGrupoUsuario", idGrupoUsuario);
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
/// Returns a list with Usuarios objects.
/// </summary>
/// <returns>A generics List with the Usuarios objects.</returns>
public static UsuariosList GetListByidPersonalPoderJudicial(string idPersonalPoderJudicial)
{
UsuariosList tempList = new UsuariosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("UsuariosSelectListByidPersonalPoderJudicial", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idPersonalPoderJudicial", idPersonalPoderJudicial);
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
/// Saves a Usuarios in the database.
/// </summary>
/// <param name="myUsuarios">The Usuarios instance to save.</param>
/// <returns>The new id if the Usuarios is new in the database or the existing id when an item was updated.</returns>
public static string Save(Usuarios myUsuarios)
{
 string result = "0";
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("UsuariosInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

DbParameter OutputId;
OutputId = myCommand.CreateParameter();
OutputId.ParameterName = "@id";
OutputId.Value = DBNull.Value;
OutputId.Direction = ParameterDirection.Output;
OutputId.Size = 14;

if (myUsuarios.id == null)
{
myCommand.Parameters.Add(OutputId);
}
else
{
myCommand.Parameters.AddWithValue("@id", myUsuarios.id);
}
if (string.IsNullOrEmpty(myUsuarios.idPersonalPoderJudicial))
{
myCommand.Parameters.AddWithValue("@idPersonalPoderJudicial", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPersonalPoderJudicial", myUsuarios.idPersonalPoderJudicial);
}
if (string.IsNullOrEmpty(myUsuarios.NombreUsuario))
{
myCommand.Parameters.AddWithValue("@nombreUsuario", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@nombreUsuario", myUsuarios.NombreUsuario);
}
if (string.IsNullOrEmpty(myUsuarios.ClaveUsuario))
{
myCommand.Parameters.AddWithValue("@claveUsuario", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@claveUsuario", myUsuarios.ClaveUsuario);
}
if (string.IsNullOrEmpty(myUsuarios.idGrupoUsuario))
{
myCommand.Parameters.AddWithValue("@idGrupoUsuario", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idGrupoUsuario", myUsuarios.idGrupoUsuario);
}
if (myUsuarios.activo == null){
myCommand.Parameters.AddWithValue("@activo", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@activo", myUsuarios.activo);
}
if (myUsuarios.Actividad == null){
myCommand.Parameters.AddWithValue("@actividad", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@actividad", myUsuarios.Actividad);
}
if (string.IsNullOrEmpty(myUsuarios.version))
{
myCommand.Parameters.AddWithValue("@version", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@version", myUsuarios.version);
}
if (myUsuarios.bitacoraMemoria == null){
myCommand.Parameters.AddWithValue("@bitacoraMemoria", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@bitacoraMemoria", myUsuarios.bitacoraMemoria);
}
if (myUsuarios.MargenArriba == null){
myCommand.Parameters.AddWithValue("@margenArriba", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@margenArriba", myUsuarios.MargenArriba);
}
if (myUsuarios.MargenIzquierda == null){
myCommand.Parameters.AddWithValue("@margenIzquierda", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@margenIzquierda", myUsuarios.MargenIzquierda);
}
if (myUsuarios.MargenAbajo == null){
myCommand.Parameters.AddWithValue("@margenAbajo", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@margenAbajo", myUsuarios.MargenAbajo);
}
if (myUsuarios.MargenDerecha == null){
myCommand.Parameters.AddWithValue("@margenDerecha", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@margenDerecha", myUsuarios.MargenDerecha);
}
if (myUsuarios.EsReferenteTrata == null)
{
    myCommand.Parameters.AddWithValue("@esReferenteTrata", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@esReferenteTrata", myUsuarios.EsReferenteTrata);
}

DbParameter returnValue;
returnValue = myCommand.CreateParameter();
returnValue.Direction = ParameterDirection.ReturnValue;
myCommand.Parameters.Add(returnValue);

myConnection.Open();
myCommand.ExecuteNonQuery();
result = Convert.ToString(myCommand.Parameters["@id"].Value);
myConnection.Close();
}
}
return result;
}

/// <summary>
/// Deletes a Usuarios from the database.
/// </summary>
/// <param name="id">The id of the Usuarios to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(string id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("UsuariosDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the Usuarios class and fills it with the data fom the IDataRecord.
/// </summary>
private static Usuarios FillDataRecord(IDataRecord myDataRecord )
{
Usuarios myUsuarios = new Usuarios();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myUsuarios.id = myDataRecord.GetString(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersonalPoderJudicial")))
{
myUsuarios.idPersonalPoderJudicial = myDataRecord.GetString(myDataRecord.GetOrdinal("idPersonalPoderJudicial"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NombreUsuario")))
{
myUsuarios.NombreUsuario = myDataRecord.GetString(myDataRecord.GetOrdinal("NombreUsuario"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ClaveUsuario")))
{
myUsuarios.ClaveUsuario = myDataRecord.GetString(myDataRecord.GetOrdinal("ClaveUsuario"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idGrupoUsuario")))
{
myUsuarios.idGrupoUsuario = myDataRecord.GetString(myDataRecord.GetOrdinal("idGrupoUsuario"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("activo")))
{
myUsuarios.activo = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("activo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Actividad")))
{
myUsuarios.Actividad = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Actividad"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("version")))
{
myUsuarios.version = myDataRecord.GetString(myDataRecord.GetOrdinal("version"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("bitacoraMemoria")))
{
myUsuarios.bitacoraMemoria = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("bitacoraMemoria"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MargenArriba")))
{
myUsuarios.MargenArriba = myDataRecord.GetInt16(myDataRecord.GetOrdinal("MargenArriba"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MargenIzquierda")))
{
myUsuarios.MargenIzquierda = myDataRecord.GetInt16(myDataRecord.GetOrdinal("MargenIzquierda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MargenAbajo")))
{
myUsuarios.MargenAbajo = myDataRecord.GetInt16(myDataRecord.GetOrdinal("MargenAbajo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MargenDerecha")))
{
myUsuarios.MargenDerecha = myDataRecord.GetInt16(myDataRecord.GetOrdinal("MargenDerecha"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EsReferenteTrata")))
{
    myUsuarios.EsReferenteTrata = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("EsReferenteTrata"));
}
return myUsuarios;
}
}

 } 
