using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
    public partial class UsuarioAutorizadoDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of Usuarios from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the Usuarios in the database.</param>
        /// <returns>An Usuarios when the id was found in the database, or null otherwise.</returns>
        public static UsuarioAutorizado GetItem(string id)
        {
            UsuarioAutorizado myUsuarios = null;
        using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
        {
        using (SqlCommand myCommand = new SqlCommand("UsuariosAutorizadoSelectSingleItem", myConnection))
        {
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.AddWithValue("@idUsuario", id);

        myConnection.Open();
        using (SqlDataReader myReader = myCommand.ExecuteReader())
        {
        if (myReader.Read()) {
            myUsuarios = new UsuarioAutorizado();
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
            public static UsuarioAutorizadoList GetList()
            {
                UsuarioAutorizadoList tempList = new UsuarioAutorizadoList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
            using (SqlCommand myCommand = new SqlCommand("UsuarioAutorizadoSelectList", myConnection))
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
/// Saves a Usuarios in the database.
/// </summary>
/// <param name="myUsuarios">The Usuarios instance to save.</param>
/// <returns>The new id if the Usuarios is new in the database or the existing id when an item was updated.</returns>
public static bool Save(UsuarioAutorizado myUsuarios)
{
    bool result = false;
    //int numerador = 0;
    
    Persona per = new Persona();
    PersonalPoderJudicial ppj = new PersonalPoderJudicial();
    Usuarios usu = null;
    //usu = UsuariosDB.GetItem(myUsuarios.NombreUsuario.Trim());
    if (myUsuarios!=null && myUsuarios.idUsuario!=null)
        usu = UsuariosDB.GetItem(myUsuarios.idUsuario);
    if (usu.id != null)
    {
        ppj = PersonalPoderJudicialDB.GetItem(usu.idPersonalPoderJudicial);
        if (ppj != null)
        {
            per = PersonaDB.GetItem(ppj.idPersona);
            if (per == null)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    else
    {
        per.id = -1;
        //NumeradoresManuales nm = NumeradoresManualesDB.ActualizarItem(myUsuarios.idDepartamento);
        //if (nm != null)
        //{
        //    numerador = nm.Numerador;
        //}
        //else
        //{
        //    return false;
        //}
        //per.id = myUsuarios.idDepartamento.ToString().PadLeft(2,'0') + nm.Numerador.ToString().PadLeft(12,'0');
        //ppj.id = myUsuarios.idDepartamento.ToString().PadLeft(2, '0') + nm.Numerador.ToString().PadLeft(12, '0');

    }
    per.activo = true;
    per.Nombre = myUsuarios.Nombre;
    per.Apellido = myUsuarios.Apellido;
    ppj.idJerarquia = myUsuarios.idJerarquia;
    ppj.idPuntoGestion = myUsuarios.idPuntoGestion;
    //ppj.idPersona = per.id.ToString();
    usu.activo = myUsuarios.activo;
    if (usu.id==null)
        usu.id = myUsuarios.NombreUsuario;
    usu.idGrupoUsuario = myUsuarios.idGrupoUsuario;
    //usu.idPersonalPoderJudicial = ppj.id;
    usu.NombreUsuario = myUsuarios.NombreUsuario;
    usu.EsReferenteTrata = myUsuarios.EsReferenteTrata;
    int idPersona = PersonaDB.Save(per);
    if (idPersona != 0)
        ppj.id = idPersona.ToString();
        ppj.idPersona = idPersona;
        usu.idPersonalPoderJudicial = idPersona.ToString();
        if (PersonalPoderJudicialDB.Save(ppj) != null)
            if (UsuariosDB.Save(usu) != null)
                result = true;
    return result;
}


#endregion

/// <summary>
/// Initializes a new instance of the Usuarios class and fills it with the data fom the IDataRecord.
/// </summary>
private static UsuarioAutorizado FillDataRecord(IDataRecord myDataRecord )
{
UsuarioAutorizado myUsuarios = new UsuarioAutorizado();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuario")))
{
    myUsuarios.idUsuario = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuario"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersonalPoderJudicial")))
{
myUsuarios.idPersonalPoderJudicial = myDataRecord.GetString(myDataRecord.GetOrdinal("idPersonalPoderJudicial"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersona")))
{
    myUsuarios.idPersona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPersona"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NombreUsuario")))
{
myUsuarios.NombreUsuario = myDataRecord.GetString(myDataRecord.GetOrdinal("NombreUsuario"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idGrupoUsuario")))
{
myUsuarios.idGrupoUsuario = myDataRecord.GetString(myDataRecord.GetOrdinal("idGrupoUsuario"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("activo")))
{
myUsuarios.activo = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("activo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Apellido")))
{
    myUsuarios.Apellido = myDataRecord.GetString(myDataRecord.GetOrdinal("Apellido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Nombre")))
{
    myUsuarios.Nombre = myDataRecord.GetString(myDataRecord.GetOrdinal("Nombre"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idJerarquia")))
{
    myUsuarios.idJerarquia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idJerarquia"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPuntoGestion")))
{
    myUsuarios.idPuntoGestion = myDataRecord.GetString(myDataRecord.GetOrdinal("idPuntoGestion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EsReferenteTrata")))
{
    myUsuarios.EsReferenteTrata = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("EsReferenteTrata"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDepartamento")))
{
    myUsuarios.idDepartamento = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDepartamento"));
}

return myUsuarios;
}
}

    }

