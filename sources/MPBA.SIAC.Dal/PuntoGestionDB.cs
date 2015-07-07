using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
/// <summary>
/// The PuntoGestionDB class is responsible for interacting with the database to retrieve and store information
/// about PuntoGestion objects.
/// </summary>
public partial class PuntoGestionDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PuntoGestion from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the PuntoGestion in the database.</param>
/// <returns>An PuntoGestion when the id was found in the database, or null otherwise.</returns>
public static PuntoGestion GetItem(string id)
{
PuntoGestion myPuntoGestion = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PuntoGestionSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPuntoGestion = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPuntoGestion;
}
}

/// <summary>
/// Gets an instance of PuntoGestion from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the PuntoGestion in the database.</param>
/// <returns>An PuntoGestion when the id was found in the database, or null otherwise.</returns>
public static PuntoGestion GetItemByUsuario(string idUsuario)
{
    PuntoGestion myPuntoGestion = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PuntoGestionSelectSingleItemByUsuario", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idUsuario", idUsuario);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myPuntoGestion = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myPuntoGestion;
    }
}

/// <summary>
/// Returns a list with PuntoGestion objects.
/// </summary>
/// <returns>A generics List with the PuntoGestion objects.</returns>
public static PuntoGestionList GetList()
{
PuntoGestionList tempList = new PuntoGestionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PuntoGestionSelectList", myConnection))
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
/// Returns a list with PuntoGestion objects.
/// </summary>
/// <returns>A generics List with the PuntoGestion objects.</returns>
public static PuntoGestionList GetListByidDepartamento(int idDepartamento)
{
    PuntoGestionList tempList = new PuntoGestionList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PuntoGestionSelectListByidDepartamento", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idDepartamento", idDepartamento);
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
/// Returns a list with PuntoGestion objects.
/// </summary>
/// <returns>A generics List with the PuntoGestion objects.</returns>
public static PuntoGestionList GetListDependenciasPJByidDepartamento(int idDepartamento)
{
    PuntoGestionList tempList = new PuntoGestionList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PuntoGestionSelectPGPoderJudicialListByidDepartamento", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idDepartamento", idDepartamento);
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
/// Returns a list with PuntoGestion objects.
/// </summary>
/// <returns>A generics List with the PuntoGestion objects.</returns>
public static PuntoGestionList GetListByidClasePuntoGestion(string idClasePuntoGestion)
{
PuntoGestionList tempList = new PuntoGestionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PuntoGestionSelectListByidClasePuntoGestion", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClasePuntoGestion", idClasePuntoGestion);
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
/// Returns a list with PuntoGestion objects.
/// </summary>
/// <returns>A generics List with the PuntoGestion objects.</returns>
public static PuntoGestionList GetListByidLocalidad(int idLocalidad)
{
PuntoGestionList tempList = new PuntoGestionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PuntoGestionSelectListByidLocalidad", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idLocalidad", idLocalidad);
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
/// Returns a list with PuntoGestion objects.
/// </summary>
/// <returns>A generics List with the PuntoGestion objects.</returns>
public static PuntoGestionList GetListByidPais(int idPais)
{
PuntoGestionList tempList = new PuntoGestionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PuntoGestionSelectListByidPais", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idPais", idPais);
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
/// Returns a list with PuntoGestion objects.
/// </summary>
/// <returns>A generics List with the PuntoGestion objects.</returns>
public static PuntoGestionList GetListByidPartido(int idPartido)
{
PuntoGestionList tempList = new PuntoGestionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PuntoGestionSelectListByidPartido", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idPartido", idPartido);
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
/// Returns a list with PuntoGestion objects.
/// </summary>
/// <returns>A generics List with the PuntoGestion objects.</returns>
public static PuntoGestionList GetListByidProvincia(int idProvincia)
{
PuntoGestionList tempList = new PuntoGestionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PuntoGestionSelectListByidProvincia", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idProvincia", idProvincia);
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
/// Saves a PuntoGestion in the database.
/// </summary>
/// <param name="myPuntoGestion">The PuntoGestion instance to save.</param>
/// <returns>The new id if the PuntoGestion is new in the database or the existing id when an item was updated.</returns>
public static string Save(PuntoGestion myPuntoGestion)
{
string result = "0";
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PuntoGestionInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (string.IsNullOrEmpty(myPuntoGestion.id))
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPuntoGestion.id);
}
if (string.IsNullOrEmpty(myPuntoGestion.idClasePuntoGestion))
{
myCommand.Parameters.AddWithValue("@idClasePuntoGestion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClasePuntoGestion", myPuntoGestion.idClasePuntoGestion);
}
if (string.IsNullOrEmpty(myPuntoGestion.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPuntoGestion.Descripcion);
}
if (myPuntoGestion.Numero == null){
myCommand.Parameters.AddWithValue("@numero", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@numero", myPuntoGestion.Numero);
}
if (myPuntoGestion.Externo == null){
myCommand.Parameters.AddWithValue("@externo", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@externo", myPuntoGestion.Externo);
}
if (myPuntoGestion.idPais == null){
myCommand.Parameters.AddWithValue("@idPais", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPais", myPuntoGestion.idPais);
}
if (myPuntoGestion.idProvincia == null){
myCommand.Parameters.AddWithValue("@idProvincia", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idProvincia", myPuntoGestion.idProvincia);
}
if (myPuntoGestion.idDepartamento == null){
myCommand.Parameters.AddWithValue("@idDepartamento", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idDepartamento", myPuntoGestion.idDepartamento);
}
if (myPuntoGestion.idLocalidad == null){
myCommand.Parameters.AddWithValue("@idLocalidad", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idLocalidad", myPuntoGestion.idLocalidad);
}
if (myPuntoGestion.idPartido == null){
myCommand.Parameters.AddWithValue("@idPartido", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPartido", myPuntoGestion.idPartido);
}
if (string.IsNullOrEmpty(myPuntoGestion.Direccion))
{
myCommand.Parameters.AddWithValue("@direccion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@direccion", myPuntoGestion.Direccion);
}
if (string.IsNullOrEmpty(myPuntoGestion.Telefonos))
{
myCommand.Parameters.AddWithValue("@telefonos", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@telefonos", myPuntoGestion.Telefonos);
}
if (string.IsNullOrEmpty(myPuntoGestion.DescripcionCorta))
{
myCommand.Parameters.AddWithValue("@descripcionCorta", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcionCorta", myPuntoGestion.DescripcionCorta);
}
if (myPuntoGestion.OrdenMuestra == null){
myCommand.Parameters.AddWithValue("@ordenMuestra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@ordenMuestra", myPuntoGestion.OrdenMuestra);
}
if (string.IsNullOrEmpty(myPuntoGestion.titular))
{
myCommand.Parameters.AddWithValue("@titular", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@titular", myPuntoGestion.titular);
}
if (myPuntoGestion.idDescentralizada == null){
myCommand.Parameters.AddWithValue("@idDescentralizada", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idDescentralizada", myPuntoGestion.idDescentralizada);
}
if (myPuntoGestion.activo == null){
myCommand.Parameters.AddWithValue("@activo", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@activo", myPuntoGestion.activo);
}
if (string.IsNullOrEmpty(myPuntoGestion.Email))
{
myCommand.Parameters.AddWithValue("@email", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@email", myPuntoGestion.Email);
}
if (string.IsNullOrEmpty(myPuntoGestion.idPadrePG))
{
myCommand.Parameters.AddWithValue("@idPadrePG", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPadrePG", myPuntoGestion.idPadrePG);
}
if (string.IsNullOrEmpty(myPuntoGestion.IdTitular))
{
myCommand.Parameters.AddWithValue("@idTitular", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTitular", myPuntoGestion.IdTitular);
}
if (string.IsNullOrEmpty(myPuntoGestion.codi_Corte))
{
myCommand.Parameters.AddWithValue("@codi_Corte", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@codi_Corte", myPuntoGestion.codi_Corte);
}
if (myPuntoGestion.area_Corte == null){
myCommand.Parameters.AddWithValue("@area_Corte", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@area_Corte", myPuntoGestion.area_Corte);
}

DbParameter returnValue;
returnValue = myCommand.CreateParameter();
returnValue.Direction = ParameterDirection.ReturnValue;
myCommand.Parameters.Add(returnValue);

myConnection.Open();
myCommand.ExecuteNonQuery();
result = Convert.ToString(returnValue.Value);
myConnection.Close();
}
}
return result;
}

/// <summary>
/// Deletes a PuntoGestion from the database.
/// </summary>
/// <param name="id">The id of the PuntoGestion to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(string id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PuntoGestionDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PuntoGestion class and fills it with the data fom the IDataRecord.
/// </summary>
private static PuntoGestion FillDataRecord(IDataRecord myDataRecord )
{
PuntoGestion myPuntoGestion = new PuntoGestion();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myPuntoGestion.id = myDataRecord.GetString(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClasePuntoGestion")))
{
myPuntoGestion.idClasePuntoGestion = myDataRecord.GetString(myDataRecord.GetOrdinal("idClasePuntoGestion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPuntoGestion.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Numero")))
{
myPuntoGestion.Numero = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Numero"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Externo")))
{
myPuntoGestion.Externo = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Externo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPais")))
{
myPuntoGestion.idPais = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPais"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idProvincia")))
{
myPuntoGestion.idProvincia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idProvincia"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDepartamento")))
{
myPuntoGestion.idDepartamento = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDepartamento"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLocalidad")))
{
myPuntoGestion.idLocalidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLocalidad"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPartido")))
{
myPuntoGestion.idPartido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPartido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Direccion")))
{
myPuntoGestion.Direccion = myDataRecord.GetString(myDataRecord.GetOrdinal("Direccion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Telefonos")))
{
myPuntoGestion.Telefonos = myDataRecord.GetString(myDataRecord.GetOrdinal("Telefonos"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DescripcionCorta")))
{
myPuntoGestion.DescripcionCorta = myDataRecord.GetString(myDataRecord.GetOrdinal("DescripcionCorta"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OrdenMuestra")))
{
myPuntoGestion.OrdenMuestra = myDataRecord.GetInt32(myDataRecord.GetOrdinal("OrdenMuestra"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("titular")))
{
myPuntoGestion.titular = myDataRecord.GetString(myDataRecord.GetOrdinal("titular"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDescentralizada")))
{
myPuntoGestion.idDescentralizada = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDescentralizada"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("activo")))
{
myPuntoGestion.activo = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("activo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Email")))
{
myPuntoGestion.Email = myDataRecord.GetString(myDataRecord.GetOrdinal("Email"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPadrePG")))
{
myPuntoGestion.idPadrePG = myDataRecord.GetString(myDataRecord.GetOrdinal("idPadrePG"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdTitular")))
{
myPuntoGestion.IdTitular = myDataRecord.GetString(myDataRecord.GetOrdinal("IdTitular"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("codi_Corte")))
{
myPuntoGestion.codi_Corte = myDataRecord.GetString(myDataRecord.GetOrdinal("codi_Corte"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("area_Corte")))
{
myPuntoGestion.area_Corte = myDataRecord.GetInt16(myDataRecord.GetOrdinal("area_Corte"));
}
return myPuntoGestion;
}
}

 } 
