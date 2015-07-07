using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;
using System.Collections.Generic;


namespace MPBA.SIAC.Dal
{
/// <summary>
/// The PersonaDB class is responsible for interacting with the database to retrieve and store information
/// about Persona objects.
/// </summary>
public partial class PersonaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of Persona from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the Persona in the database.</param>
/// <returns>An Persona when the id was found in the database, or null otherwise.</returns>
public static Persona GetItem(string id)
{
Persona myPersona = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", Convert.ToInt32(id));

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPersona = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPersona;
}
}

/// <summary>
/// Gets an instance of Persona from the underlying datasource.
/// </summary>
/// <param name="id">The unique idNumerico of the Persona in the database.</param>
/// <returns>An Persona when the idNumerico was found in the database, or null otherwise.</returns>
public static Persona GetItem(int id)
{
    Persona myPersona = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PersonaSelectSingleItem", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@id", id);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myPersona = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myPersona;
    }
}

/// <summary>
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetList()
{
PersonaList tempList = new PersonaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonaSelectList", myConnection))
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
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona who is referente objects.</returns>
public static PersonaList Getreferentes()
{
    PersonaList tempList = new PersonaList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PersonaSelectReferente", myConnection))
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
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByIdEstadoCivilPaterno(int IdEstadoCivilPaterno)
{
PersonaList tempList = new PersonaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByIdEstadoCivilPaterno", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idEstadoCivilPaterno", IdEstadoCivilPaterno);
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
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByidEstadoCivil(int idEstadoCivil)
{
PersonaList tempList = new PersonaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByidEstadoCivil", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idEstadoCivil", idEstadoCivil);
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
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByidTipoPersona(int idTipoPersona)
{
    PersonaList tempList = new PersonaList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByidTipoPersona", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
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
        return tempList;
    }
}

/// <summary>
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByIdEstadoCivilMaterno(int IdEstadoCivilMaterno)
{
PersonaList tempList = new PersonaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByIdEstadoCivilMaterno", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idEstadoCivilMaterno", IdEstadoCivilMaterno);
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
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByidNacionalidad(int idNacionalidad)
{
PersonaList tempList = new PersonaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByidNacionalidad", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idNacionalidad", idNacionalidad);
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
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByidProvincia(int idProvincia)
{
PersonaList tempList = new PersonaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByidProvincia", myConnection))
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
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByidTipoDNI(int idTipoDNI)
{
PersonaList tempList = new PersonaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByidTipoDNI", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idTipoDNI", idTipoDNI);
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
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByDocNro(int docNro)
{
    PersonaList tempList = new PersonaList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByDocNro", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@docNro", docNro);
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
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByDocNroApellido(int? docNro,string apellido)
{
    PersonaList tempList = new PersonaList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByDocNroApellido", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@docNro", docNro);
            myCommand.Parameters.AddWithValue("@apellido", apellido);
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
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByidApellido(string apellido)
{
    PersonaList tempList = new PersonaList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByApellido", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@apellido", apellido);
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

private static DataTable CreateDataTable(IEnumerable<int> ids)
{
    DataTable table = new DataTable();
    table.Columns.Add("ID", typeof(long));
    foreach (int id in ids)
    {
        table.Rows.Add(id);
    }
    return table;
}
// Da de Baja Logica a Una Persona hallada o Desaparecida, conjuntamente define el Motivo de Baja
// Actualiza la tabla PersonasEncontradas a traves de un stored Prodecure
public static string UpdateBaja(string ippHallada, string ippDesaparecida, int MotivoDeBaja,
    int IppOrigen, string Usuario,  IEnumerable<int> ids)
{



    //parameter = command.Parameters.AddWithValue("@Display", CreateDataTable(ids));}
    SqlConnection myConnection = null;
    SqlCommand myCommand = null;
    try
    {
        using (myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
        {
            using (myCommand = new SqlCommand("PersonasUpdateBaja", myConnection))
            {
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.AddWithValue("@ippHallada", ippHallada);
                myCommand.Parameters.AddWithValue("@ippDesaparecida", ippDesaparecida);
                myCommand.Parameters.AddWithValue("@MotivoDeBaja", MotivoDeBaja);
                myCommand.Parameters.AddWithValue("@IppOrigen", IppOrigen);
                myCommand.Parameters.AddWithValue("@Usuario", Usuario);
                
                SqlParameter parameter;
                parameter= myCommand.Parameters.AddWithValue("@TPersonas", CreateDataTable(ids));
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.PersonasType";

             


                myConnection.Open();
                myCommand.ExecuteNonQuery();

            }
        }
    }
    catch (Exception ex)
    {
        return ex.Message;
    }
    finally
    {  
       myConnection.Close();
      
    }
    return "OK";

}



/// <summary>
/// Returns a list with Persona objects.
/// </summary>
/// <returns>A generics List with the Persona objects.</returns>
public static PersonaList GetListByidCreador(string idCreador)
{
PersonaList tempList = new PersonaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonaSelectListByidCreador", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idCreador", idCreador);
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
/// Saves a Persona in the database.
/// </summary>
/// <param name="myPersona">The Persona instance to save.</param>
/// <returns>The new id if the Persona is new in the database or the existing id when an item was updated.</returns>
public static int Save(Persona myPersona)
{
      int result = 0;
      using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
      {
          using (SqlCommand myCommand = new SqlCommand("PersonaInsertUpdateSingleItem", myConnection))
          {
              myCommand.CommandType = CommandType.StoredProcedure;

              if (myPersona.id == -1)
              {
                  myCommand.Parameters.AddWithValue("@id", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@id", myPersona.id);
              }
              if (string.IsNullOrEmpty(myPersona.Nombre))
              {
                  myCommand.Parameters.AddWithValue("@nombre", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@nombre", myPersona.Nombre);
              }
              if (string.IsNullOrEmpty(myPersona.Apellido))
              {
                  myCommand.Parameters.AddWithValue("@apellido", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@apellido", myPersona.Apellido);
              }
              if (string.IsNullOrEmpty(myPersona.Apodo))
              {
                  myCommand.Parameters.AddWithValue("@apodo", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@apodo", myPersona.Apodo);
              }
              if (myPersona.idTipoDNI == null)
              {
                  myCommand.Parameters.AddWithValue("@idTipoDNI", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@idTipoDNI", myPersona.idTipoDNI);
              }
              if (myPersona.DocumentoNumero == null)
              {
                  myCommand.Parameters.AddWithValue("@documentoNumero", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@documentoNumero", myPersona.DocumentoNumero);
              }
              if (string.IsNullOrEmpty(myPersona.Sexo))
              {
                  myCommand.Parameters.AddWithValue("@sexo", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@sexo", myPersona.Sexo);
              }
              if (string.IsNullOrEmpty(myPersona.Direccion))
              {
                  myCommand.Parameters.AddWithValue("@direccion", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@direccion", myPersona.Direccion);
              }
              if (string.IsNullOrEmpty(myPersona.Telefono))
              {
                  myCommand.Parameters.AddWithValue("@telefono", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@telefono", myPersona.Telefono);
              }
              if (string.IsNullOrEmpty(myPersona.EMail))
              {
                  myCommand.Parameters.AddWithValue("@eMail", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@eMail", myPersona.EMail);
              }
              if (myPersona.FechaNacimiento == null)
              {
                  myCommand.Parameters.AddWithValue("@fechaNacimiento", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@fechaNacimiento", myPersona.FechaNacimiento);
              }
              if (myPersona.Localidad == null)
              {
                  myCommand.Parameters.AddWithValue("@localidad", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@localidad", myPersona.Localidad);
              }
              if (myPersona.Partido == null)
              {
                  myCommand.Parameters.AddWithValue("@partido", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@partido", myPersona.Partido);
              }
              if (myPersona.idProvincia == null)
              {
                  myCommand.Parameters.AddWithValue("@idProvincia", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@idProvincia", myPersona.idProvincia);
              }
              if (string.IsNullOrEmpty(myPersona.idCreador))
              {
                  myCommand.Parameters.AddWithValue("@idCreador", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@idCreador", myPersona.idCreador);
              }
              if (string.IsNullOrEmpty(myPersona.colegio))
              {
                  myCommand.Parameters.AddWithValue("@colegio", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@colegio", myPersona.colegio);
              }
              if (string.IsNullOrEmpty(myPersona.Tomo))
              {
                  myCommand.Parameters.AddWithValue("@tomo", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@tomo", myPersona.Tomo);
              }
              if (string.IsNullOrEmpty(myPersona.Folio))
              {
                  myCommand.Parameters.AddWithValue("@folio", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@folio", myPersona.Folio);
              }
              if (myPersona.FechaAlta == null)
              {
                  myCommand.Parameters.AddWithValue("@fechaAlta", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@fechaAlta", myPersona.FechaAlta);
              }
              if (myPersona.PersonalPoderJudicial == null)
              {
                  myCommand.Parameters.AddWithValue("@personalPoderJudicial", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@personalPoderJudicial", myPersona.PersonalPoderJudicial);
              }
              if (myPersona.activo == null)
              {
                  myCommand.Parameters.AddWithValue("@activo", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@activo", myPersona.activo);
              }
              if (myPersona.Muerto == null)
              {
                  myCommand.Parameters.AddWithValue("@muerto", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@muerto", myPersona.Muerto);
              }
              if (myPersona.idEstadoCivil == null)
              {
                  myCommand.Parameters.AddWithValue("@idEstadoCivil", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@idEstadoCivil", myPersona.idEstadoCivil);
              }
              if (string.IsNullOrEmpty(myPersona.profesion))
              {
                  myCommand.Parameters.AddWithValue("@profesion", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@profesion", myPersona.profesion);
              }
              if (string.IsNullOrEmpty(myPersona.LugarNacimiento))
              {
                  myCommand.Parameters.AddWithValue("@lugarNacimiento", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@lugarNacimiento", myPersona.LugarNacimiento);
              }
              if (myPersona.idNacionalidad == null)
              {
                  myCommand.Parameters.AddWithValue("@idNacionalidad", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@idNacionalidad", myPersona.idNacionalidad);
              }
              if (string.IsNullOrEmpty(myPersona.Padre))
              {
                  myCommand.Parameters.AddWithValue("@padre", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@padre", myPersona.Padre);
              }
              if (string.IsNullOrEmpty(myPersona.Madre))
              {
                  myCommand.Parameters.AddWithValue("@madre", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@madre", myPersona.Madre);
              }
              if (string.IsNullOrEmpty(myPersona.ProfesionPadre))
              {
                  myCommand.Parameters.AddWithValue("@profesionPadre", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@profesionPadre", myPersona.ProfesionPadre);
              }
              if (string.IsNullOrEmpty(myPersona.ProfesionMadre))
              {
                  myCommand.Parameters.AddWithValue("@profesionMadre", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@profesionMadre", myPersona.ProfesionMadre);
              }
              if (string.IsNullOrEmpty(myPersona.Conyuge))
              {
                  myCommand.Parameters.AddWithValue("@conyuge", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@conyuge", myPersona.Conyuge);
              }
              if (string.IsNullOrEmpty(myPersona.NumeroIRNR))
              {
                  myCommand.Parameters.AddWithValue("@numeroIRNR", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@numeroIRNR", myPersona.NumeroIRNR);
              }
              if (string.IsNullOrEmpty(myPersona.NumeroIDAPMS))
              {
                  myCommand.Parameters.AddWithValue("@numeroIDAPMS", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@numeroIDAPMS", myPersona.NumeroIDAPMS);
              }
              if (string.IsNullOrEmpty(myPersona.DefensorParticular))
              {
                  myCommand.Parameters.AddWithValue("@defensorParticular", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@defensorParticular", myPersona.DefensorParticular);
              }
              if (myPersona.Edad == null)
              {
                  myCommand.Parameters.AddWithValue("@edad", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@edad", myPersona.Edad);
              }
              if (myPersona.IdEstadoCivilMaterno == null)
              {
                  myCommand.Parameters.AddWithValue("@idEstadoCivilMaterno", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@idEstadoCivilMaterno", myPersona.IdEstadoCivilMaterno);
              }
              if (myPersona.IdEstadoCivilPaterno == null)
              {
                  myCommand.Parameters.AddWithValue("@idEstadoCivilPaterno", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@idEstadoCivilPaterno", myPersona.IdEstadoCivilPaterno);
              }
              if (myPersona.idTipoPersona == null)
              {
                  myCommand.Parameters.AddWithValue("@idTipoPersona", DBNull.Value);
              }
              else
              {
                  myCommand.Parameters.AddWithValue("@idTipoPersona", myPersona.idTipoPersona);
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
          //myConnection.Close();
          //}
      }
    return result;
}

/// <summary>
/// Deletes a Persona from the database.
/// </summary>
/// <param name="id">The id of the Persona to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the Persona class and fills it with the data fom the IDataRecord.
/// </summary>
private static Persona FillDataRecord(IDataRecord myDataRecord )
{
Persona myPersona = new Persona();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
    myPersona.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}

if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Apellido")))
{
    myPersona.Apellido = myDataRecord.GetString(myDataRecord.GetOrdinal("Apellido"));
    myPersona.NombreCompleto = myDataRecord.GetString(myDataRecord.GetOrdinal("Apellido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Nombre")))
{
myPersona.Nombre = myDataRecord.GetString(myDataRecord.GetOrdinal("Nombre"));
    if (myPersona.NombreCompleto != "")
        myPersona.NombreCompleto = myPersona.NombreCompleto + ", " + myDataRecord.GetString(myDataRecord.GetOrdinal("Nombre"));
    else
        myPersona.NombreCompleto = myDataRecord.GetString(myDataRecord.GetOrdinal("Nombre"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Apodo")))
{
myPersona.Apodo = myDataRecord.GetString(myDataRecord.GetOrdinal("Apodo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoDNI")))
{
myPersona.idTipoDNI = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoDNI"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DocumentoNumero")))
{
    myPersona.DocumentoNumero = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DocumentoNumero"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Sexo")))
{
myPersona.Sexo = myDataRecord.GetString(myDataRecord.GetOrdinal("Sexo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Direccion")))
{
myPersona.Direccion = myDataRecord.GetString(myDataRecord.GetOrdinal("Direccion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Telefono")))
{
myPersona.Telefono = myDataRecord.GetString(myDataRecord.GetOrdinal("Telefono"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EMail")))
{
myPersona.EMail = myDataRecord.GetString(myDataRecord.GetOrdinal("EMail"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaNacimiento")))
{
myPersona.FechaNacimiento = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaNacimiento"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Localidad")))
{
myPersona.Localidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Localidad"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Partido")))
{
myPersona.Partido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Partido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idProvincia")))
{
myPersona.idProvincia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idProvincia"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCreador")))
{
myPersona.idCreador = myDataRecord.GetString(myDataRecord.GetOrdinal("idCreador"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("colegio")))
{
myPersona.colegio = myDataRecord.GetString(myDataRecord.GetOrdinal("colegio"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Tomo")))
{
myPersona.Tomo = myDataRecord.GetString(myDataRecord.GetOrdinal("Tomo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Folio")))
{
myPersona.Folio = myDataRecord.GetString(myDataRecord.GetOrdinal("Folio"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaAlta")))
{
myPersona.FechaAlta = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaAlta"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PersonalPoderJudicial")))
{
myPersona.PersonalPoderJudicial = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PersonalPoderJudicial"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("activo")))
{
myPersona.activo = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("activo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Muerto")))
{
myPersona.Muerto = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Muerto"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idEstadoCivil")))
{
myPersona.idEstadoCivil = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idEstadoCivil"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("profesion")))
{
myPersona.profesion = myDataRecord.GetString(myDataRecord.GetOrdinal("profesion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LugarNacimiento")))
{
myPersona.LugarNacimiento = myDataRecord.GetString(myDataRecord.GetOrdinal("LugarNacimiento"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idNacionalidad")))
{
myPersona.idNacionalidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idNacionalidad"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Padre")))
{
myPersona.Padre = myDataRecord.GetString(myDataRecord.GetOrdinal("Padre"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Madre")))
{
myPersona.Madre = myDataRecord.GetString(myDataRecord.GetOrdinal("Madre"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ProfesionPadre")))
{
myPersona.ProfesionPadre = myDataRecord.GetString(myDataRecord.GetOrdinal("ProfesionPadre"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ProfesionMadre")))
{
myPersona.ProfesionMadre = myDataRecord.GetString(myDataRecord.GetOrdinal("ProfesionMadre"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Conyuge")))
{
myPersona.Conyuge = myDataRecord.GetString(myDataRecord.GetOrdinal("Conyuge"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NumeroIRNR")))
{
myPersona.NumeroIRNR = myDataRecord.GetString(myDataRecord.GetOrdinal("NumeroIRNR"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NumeroIDAPMS")))
{
myPersona.NumeroIDAPMS = myDataRecord.GetString(myDataRecord.GetOrdinal("NumeroIDAPMS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DefensorParticular")))
{
myPersona.DefensorParticular = myDataRecord.GetString(myDataRecord.GetOrdinal("DefensorParticular"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Edad")))
{
myPersona.Edad = myDataRecord.GetInt16(myDataRecord.GetOrdinal("Edad"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdEstadoCivilMaterno")))
{
myPersona.IdEstadoCivilMaterno = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdEstadoCivilMaterno"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdEstadoCivilPaterno")))
{
myPersona.IdEstadoCivilPaterno = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdEstadoCivilPaterno"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoPersona")))
{
myPersona.idTipoPersona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoPersona"));
}
return myPersona;
}
}

 } 
