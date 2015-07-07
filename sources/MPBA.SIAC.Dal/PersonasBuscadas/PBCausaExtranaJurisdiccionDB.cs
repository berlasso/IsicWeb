using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBCausaExtranaJurisdiccionDB class is responsible for interacting with the database to retrieve and store information
/// about PBCausaExtranaJurisdiccion objects.
/// </summary>
public partial class PBCausaExtranaJurisdiccionDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBCausaExtranaJurisdiccion from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the PBCausaExtranaJurisdiccion in the database.</param>
/// <returns>An PBCausaExtranaJurisdiccion when the id was found in the database, or null otherwise.</returns>
public static PBCausaExtranaJurisdiccion GetItem(int id)
{
PBCausaExtranaJurisdiccion myPBCausaExtranaJurisdiccion = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBCausaExtranaJurisdiccionSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBCausaExtranaJurisdiccion = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBCausaExtranaJurisdiccion;
}
}

/// <summary>
/// Gets an instance of PBCausaExtranaJurisdiccion from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the PBCausaExtranaJurisdiccion in the database.</param>
/// <returns>An PBCausaExtranaJurisdiccion when the id was found in the database, or null otherwise.</returns>
public static PBCausaExtranaJurisdiccion GetItem(string nroCausa, int idTipoBusqueda)
{
    PBCausaExtranaJurisdiccion myPBCausaExtranaJurisdiccion = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PBCausaExtranaJurisdiccionSelectSingleItemByIdPersonaBuscada", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@Ipp", nroCausa.Trim());
            myCommand.Parameters.AddWithValue("@idTipoBusqueda", idTipoBusqueda);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myPBCausaExtranaJurisdiccion = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myPBCausaExtranaJurisdiccion;
    }
}

/// <summary>
/// Returns a list with PBCausaExtranaJurisdiccion objects.
/// </summary>
/// <returns>A generics List with the PBCausaExtranaJurisdiccion objects.</returns>
public static PBCausaExtranaJurisdiccionList GetList()
{
PBCausaExtranaJurisdiccionList tempList = new PBCausaExtranaJurisdiccionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBCausaExtranaJurisdiccionSelectList", myConnection))
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
/// Saves a PBCausaExtranaJurisdiccion in the database.
/// </summary>
/// <param name="myPBCausaExtranaJurisdiccion">The PBCausaExtranaJurisdiccion instance to save.</param>
/// <returns>The new id if the PBCausaExtranaJurisdiccion is new in the database or the existing id when an item was updated.</returns>
public static int Save(PBCausaExtranaJurisdiccion myPBCausaExtranaJurisdiccion)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBCausaExtranaJurisdiccionInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBCausaExtranaJurisdiccion.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBCausaExtranaJurisdiccion.id);
}
if (string.IsNullOrEmpty(myPBCausaExtranaJurisdiccion.OrganoRequirente))
{
myCommand.Parameters.AddWithValue("@organoRequirente", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@organoRequirente", myPBCausaExtranaJurisdiccion.OrganoRequirente);
}
if (string.IsNullOrEmpty(myPBCausaExtranaJurisdiccion.Jurisdiccion))
{
myCommand.Parameters.AddWithValue("@jurisdiccion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@jurisdiccion", myPBCausaExtranaJurisdiccion.Jurisdiccion);
}
if (string.IsNullOrEmpty(myPBCausaExtranaJurisdiccion.Provincia))
{
myCommand.Parameters.AddWithValue("@provincia", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@provincia", myPBCausaExtranaJurisdiccion.Provincia);
}
if (string.IsNullOrEmpty(myPBCausaExtranaJurisdiccion.telefono))
{
myCommand.Parameters.AddWithValue("@telefono", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@telefono", myPBCausaExtranaJurisdiccion.telefono);
}
if (string.IsNullOrEmpty(myPBCausaExtranaJurisdiccion.mail))
{
myCommand.Parameters.AddWithValue("@mail", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@mail", myPBCausaExtranaJurisdiccion.mail);
}
if (string.IsNullOrEmpty(myPBCausaExtranaJurisdiccion.caratula))
{
myCommand.Parameters.AddWithValue("@caratula", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@caratula", myPBCausaExtranaJurisdiccion.caratula);
}
if (myPBCausaExtranaJurisdiccion.idTipoBusqueda == null){
myCommand.Parameters.AddWithValue("@idTipoBusqueda", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTipoBusqueda", myPBCausaExtranaJurisdiccion.idTipoBusqueda);
}
if (myPBCausaExtranaJurisdiccion.NroCausa == null)
{
    myCommand.Parameters.AddWithValue("@NroCausa", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@NroCausa", myPBCausaExtranaJurisdiccion.NroCausa);
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
/// Deletes a PBCausaExtranaJurisdiccion from the database.
/// </summary>
/// <param name="id">The id of the PBCausaExtranaJurisdiccion to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBCausaExtranaJurisdiccionDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBCausaExtranaJurisdiccion class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBCausaExtranaJurisdiccion FillDataRecord(IDataRecord myDataRecord )
{
PBCausaExtranaJurisdiccion myPBCausaExtranaJurisdiccion = new PBCausaExtranaJurisdiccion();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myPBCausaExtranaJurisdiccion.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OrganoRequirente")))
{
myPBCausaExtranaJurisdiccion.OrganoRequirente = myDataRecord.GetString(myDataRecord.GetOrdinal("OrganoRequirente"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Jurisdiccion")))
{
myPBCausaExtranaJurisdiccion.Jurisdiccion = myDataRecord.GetString(myDataRecord.GetOrdinal("Jurisdiccion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Provincia")))
{
myPBCausaExtranaJurisdiccion.Provincia = myDataRecord.GetString(myDataRecord.GetOrdinal("Provincia"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("telefono")))
{
myPBCausaExtranaJurisdiccion.telefono = myDataRecord.GetString(myDataRecord.GetOrdinal("telefono"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("mail")))
{
myPBCausaExtranaJurisdiccion.mail = myDataRecord.GetString(myDataRecord.GetOrdinal("mail"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("caratula")))
{
myPBCausaExtranaJurisdiccion.caratula = myDataRecord.GetString(myDataRecord.GetOrdinal("caratula"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoBusqueda")))
{
myPBCausaExtranaJurisdiccion.idTipoBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NroCausa")))
{
    
    myPBCausaExtranaJurisdiccion.NroCausa = myDataRecord.GetString(myDataRecord.GetOrdinal("NroCausa"));
}
return myPBCausaExtranaJurisdiccion;
}
}

 } 
