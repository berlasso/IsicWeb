using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using MPBA.SIAC.BusinessEntities;

using MPBA.AutoresIgnorados.BusinessEntities;

using MPBA.SIAC.Dal;
using MPBA.PersonasBuscadas.Dal;
namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The AutoresDB class is responsible for interacting with the database to retrieve and store information
/// about Autores objects.
/// </summary>
public partial class AutoresDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of Autores from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the Autores in the database.</param>
/// <returns>An Autores when the id was found in the database, or null otherwise.</returns>
public static Autores GetItem(int id)
{
Autores myAutores = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("AutoresSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myAutores = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myAutores;
}
}

/// <summary>
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetList()
{
AutoresList tempList = new AutoresList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("AutoresSelectList", myConnection))
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListJoinedPersonasByIdPersona(int idPersona)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresJoinedPersonasSelectListByIdPersona", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idPersona", idPersona);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidDelito(int idDelito)
{
AutoresList tempList = new AutoresList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidDelito", myConnection))
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidPersona(int idPersona)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidPersona", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idPersona", idPersona);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseEdadAproximada(int idClaseEdadAproximada)
{
AutoresList tempList = new AutoresList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseEdadAproximada", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseEdadAproximada", idClaseEdadAproximada);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseLugarDelCuerpo(int idClaseLugarDelCuerpo)
{
AutoresList tempList = new AutoresList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseLugarDelCuerpo", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseLugarDelCuerpo", idClaseLugarDelCuerpo);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseRostro(int idClaseRostro)
{
AutoresList tempList = new AutoresList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseRostro", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseRostro", idClaseRostro);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseSeniaParticular(int idClaseSeniaParticular)
{
AutoresList tempList = new AutoresList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseSeniaParticular", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseSeniaParticular", idClaseSeniaParticular);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseSexo(int idClaseSexo)
{
AutoresList tempList = new AutoresList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseSexo", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseSexo", idClaseSexo);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseTatuaje(int idClaseTatuaje)
{
AutoresList tempList = new AutoresList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseTatuaje", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseTatuaje", idClaseTatuaje);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidDimensionCeja(int idDimensionCeja)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidDimensionCeja", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idDimensionCeja", idDimensionCeja);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidTipoCeja(int idTipoCeja)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidTipoCeja", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idTipoCeja", idTipoCeja);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseColorCabello(int idClaseColorCabello)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseColorCabello", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idClaseColorCabello", idClaseColorCabello);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseColorOjos(int idClaseColorOjos)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseColorOjos", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idClaseColorOjos", idClaseColorOjos);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseColorPiel(int idClaseColorPiel)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseColorPiel", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idClaseColorPiel", idClaseColorPiel);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseEstatura(int idClaseEstatura)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseEstatura", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idClaseEstatura", idClaseEstatura);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidFormaBoca(int idFormaBoca)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidFormaBoca", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idFormaBoca", idFormaBoca);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseFormaCara(int idClaseFormaCara)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseFormaCara", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idClaseFormaCara", idClaseFormaCara);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidFormaLabioInferior(int idFormaLabioInferior)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidFormaLabioInferior", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idFormaLabioInferior", idFormaLabioInferior);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidFormaLabioSuperior(int idFormaLabioSuperior)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidFormaLabioSuperior", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idFormaLabioSuperior", idFormaLabioSuperior);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidFormaMenton(int idFormaMenton)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidFormaMenton", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idFormaMenton", idFormaMenton);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidFormaNariz(int idFormaNariz)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidFormaNariz", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idFormaNariz", idFormaNariz);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidFormaOreja(int idFormaOreja)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidFormaOreja", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idFormaOreja", idFormaOreja);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseRobustez(int idClaseRobustez)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseRobustez", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idClaseRobustez", idClaseRobustez);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseTipoCabello(int idClaseTipoCabello)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseTipoCabello", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idClaseTipoCabello", idClaseTipoCabello);
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
/// Returns a list with Autores objects.
/// </summary>
/// <returns>A generics List with the Autores objects.</returns>
public static AutoresList GetListByidClaseCalvicie(int idClaseCalvicie)
{
    AutoresList tempList = new AutoresList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresSelectListByidClaseCalvicie", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idClaseCalvicie", idClaseCalvicie);
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
/// Saves a Autores in the database.
/// </summary>
/// <param name="myAutores">The Autores instance to save.</param>
/// <returns>The new id if the Autores is new in the database or the existing id when an item was updated.</returns>
public static int Save(Autores myAutores)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("AutoresInsertUpdateSingleItem", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;

            if (myAutores.id == -1)
            {
                myCommand.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@id", myAutores.id);
            }

            myCommand.Parameters.AddWithValue("@idDelito", myAutores.idDelito);

            if (string.IsNullOrEmpty(myAutores.idCausa))
            {
                myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idCausa", myAutores.idCausa);
            }
            if (string.IsNullOrEmpty(myAutores.Nro))
            {
                myCommand.Parameters.AddWithValue("@nro", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@nro", myAutores.Nro);
            }

            myCommand.Parameters.AddWithValue("@idClaseEdadAproximada", myAutores.idClaseEdadAproximada);

            myCommand.Parameters.AddWithValue("@idClaseSexo", myAutores.idClaseSexo);
            if (myAutores.idClaseEstatura == null)
            {
                myCommand.Parameters.AddWithValue("@idClaseEstatura", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idClaseEstatura", myAutores.idClaseEstatura);
            }
            if (myAutores.idClaseRobustez == null)
            {
                myCommand.Parameters.AddWithValue("@idClaseRobustez", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idClaseRobustez", myAutores.idClaseRobustez);
            }
            if (myAutores.idClaseColorPiel == null)
            {
                myCommand.Parameters.AddWithValue("@idClaseColorPiel", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idClaseColorPiel", myAutores.idClaseColorPiel);
            }
            if (myAutores.idClaseColorOjos == null)
            {
                myCommand.Parameters.AddWithValue("@idClaseColorOjos", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idClaseColorOjos", myAutores.idClaseColorOjos);
            }
            if (myAutores.idClaseColorCabello == null)
            {
                myCommand.Parameters.AddWithValue("@idClaseColorCabello", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idClaseColorCabello", myAutores.idClaseColorCabello);
            }
            if (myAutores.idClaseTipoCabello == null)
            {
                myCommand.Parameters.AddWithValue("@idClaseTipoCabello", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idClaseTipoCabello", myAutores.idClaseTipoCabello);
            }
            if (myAutores.idClaseCalvicie == null)
            {
                myCommand.Parameters.AddWithValue("@idClaseCalvicie", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idClaseCalvicie", myAutores.idClaseCalvicie);
            }
            if (myAutores.idClaseFormaCara == null)
            {
                myCommand.Parameters.AddWithValue("@idClaseFormaCara", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idClaseFormaCara", myAutores.idClaseFormaCara);
            }
            if (myAutores.idDimensionCeja == null)
            {
                myCommand.Parameters.AddWithValue("@idDimensionCeja", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idDimensionCeja", myAutores.idDimensionCeja);
            }
            if (myAutores.idTipoCeja == null)
            {
                myCommand.Parameters.AddWithValue("@idTipoCeja", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idTipoCeja", myAutores.idTipoCeja);
            }
            if (myAutores.idFormaMenton == null)
            {
                myCommand.Parameters.AddWithValue("@idFormaMenton", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idFormaMenton", myAutores.idFormaMenton);
            }
            if (myAutores.idFormaOreja == null)
            {
                myCommand.Parameters.AddWithValue("@idFormaOreja", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idFormaOreja", myAutores.idFormaOreja);
            }
            if (myAutores.idFormaNariz == null)
            {
                myCommand.Parameters.AddWithValue("@idFormaNariz", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idFormaNariz", myAutores.idFormaNariz);
            }
            if (myAutores.idFormaBoca == null)
            {
                myCommand.Parameters.AddWithValue("@idFormaBoca", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idFormaBoca", myAutores.idFormaBoca);
            }
            if (myAutores.idFormaLabioInferior == null)
            {
                myCommand.Parameters.AddWithValue("@idFormaLabioInferior", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idFormaLabioInferior", myAutores.idFormaLabioInferior);
            }
            if (myAutores.idFormaLabioSuperior == null)
            {
                myCommand.Parameters.AddWithValue("@idFormaLabioSuperior", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idFormaLabioSuperior", myAutores.idFormaLabioSuperior);
            }
            if (string.IsNullOrEmpty(myAutores.idSic))
            {
                myCommand.Parameters.AddWithValue("@idSic", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idSic", myAutores.idSic);
            }


            myCommand.Parameters.AddWithValue("@idClaseRostro", myAutores.idClaseRostro);

            if (string.IsNullOrEmpty(myAutores.CubiertoCon))
            {
                myCommand.Parameters.AddWithValue("@cubiertoCon", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@cubiertoCon", myAutores.CubiertoCon);
            }

          /*  myCommand.Parameters.AddWithValue("@idClaseSeniaParticular", myAutores.idClaseSeniaParticular);

            if (string.IsNullOrEmpty(myAutores.UbicacionSeniaParticular))
            {
                myCommand.Parameters.AddWithValue("@ubicacionSeniaParticular", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@ubicacionSeniaParticular", myAutores.UbicacionSeniaParticular);
            }

            myCommand.Parameters.AddWithValue("@idClaseLugarDelCuerpo", myAutores.idClaseLugarDelCuerpo);
           

            myCommand.Parameters.AddWithValue("@idClaseTatuaje", myAutores.idClaseTatuaje);
            */
            //if (string.IsNullOrEmpty(myAutores.OtroTatuaje))
            //{
            //    myCommand.Parameters.AddWithValue("@otroTatuaje", DBNull.Value);
            //}
            //else
            //{
            //    myCommand.Parameters.AddWithValue("@otroTatuaje", myAutores.OtroTatuaje);
            //}
            if (string.IsNullOrEmpty(myAutores.OtraCaracteristica))
            {
                myCommand.Parameters.AddWithValue("@otraCaracteristica", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@otraCaracteristica", myAutores.OtraCaracteristica);
            }
            myCommand.Parameters.AddWithValue("@idPersona", myAutores.idPersona);
            if (string.IsNullOrEmpty(myAutores.idImputadoSimp))
            {
                myCommand.Parameters.AddWithValue("@idImputadoSimp", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idImputadoSimp", myAutores.idImputadoSimp);
            }
            myCommand.Parameters.AddWithValue("@baja", myAutores.Baja);

            if (string.IsNullOrEmpty(myAutores.idUsuarioUltimaModificacion))
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myAutores.idUsuarioUltimaModificacion);
            }
            if (myAutores.FechaUltimaModificacion == null)
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myAutores.FechaUltimaModificacion);
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

public static int Save(Autores myAutores, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("AutoresInsertUpdateSingleItem", myConnection))
    //    {
    try
    {
        myCommand.CommandText = "AutoresInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();

        if (myAutores.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myAutores.id);
        }

        myCommand.Parameters.AddWithValue("@idDelito", myAutores.idDelito);

        if (string.IsNullOrEmpty(myAutores.idCausa))
        {
            myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idCausa", myAutores.idCausa);
        }
        if (string.IsNullOrEmpty(myAutores.Nro))
        {
            myCommand.Parameters.AddWithValue("@nro", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@nro", myAutores.Nro);
        }

        myCommand.Parameters.AddWithValue("@idClaseEdadAproximada", myAutores.idClaseEdadAproximada);

        myCommand.Parameters.AddWithValue("@idClaseSexo", myAutores.idClaseSexo);
        if (myAutores.idClaseEstatura == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseEstatura", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseEstatura", myAutores.idClaseEstatura);
        }
        if (myAutores.idClaseRobustez == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseRobustez", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseRobustez", myAutores.idClaseRobustez);
        }
        if (myAutores.idClaseColorPiel == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseColorPiel", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseColorPiel", myAutores.idClaseColorPiel);
        }
        if (myAutores.idClaseColorOjos == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseColorOjos", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseColorOjos", myAutores.idClaseColorOjos);
        }
        if (myAutores.idClaseColorCabello == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseColorCabello", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseColorCabello", myAutores.idClaseColorCabello);
        }
        if (myAutores.idClaseTipoCabello == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseTipoCabello", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseTipoCabello", myAutores.idClaseTipoCabello);
        }
        if (myAutores.idClaseCalvicie == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseCalvicie", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseCalvicie", myAutores.idClaseCalvicie);
        }
        if (myAutores.idClaseFormaCara == null)
        {
            myCommand.Parameters.AddWithValue("@idClaseFormaCara", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idClaseFormaCara", myAutores.idClaseFormaCara);
        }
        if (myAutores.idDimensionCeja == null)
        {
            myCommand.Parameters.AddWithValue("@idDimensionCeja", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idDimensionCeja", myAutores.idDimensionCeja);
        }
        if (myAutores.idTipoCeja == null)
        {
            myCommand.Parameters.AddWithValue("@idTipoCeja", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idTipoCeja", myAutores.idTipoCeja);
        }
        if (myAutores.idFormaMenton == null)
        {
            myCommand.Parameters.AddWithValue("@idFormaMenton", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idFormaMenton", myAutores.idFormaMenton);
        }
        if (myAutores.idFormaOreja == null)
        {
            myCommand.Parameters.AddWithValue("@idFormaOreja", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idFormaOreja", myAutores.idFormaOreja);
        }
        if (myAutores.idFormaNariz == null)
        {
            myCommand.Parameters.AddWithValue("@idFormaNariz", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idFormaNariz", myAutores.idFormaNariz);
        }
        if (myAutores.idFormaBoca == null)
        {
            myCommand.Parameters.AddWithValue("@idFormaBoca", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idFormaBoca", myAutores.idFormaBoca);
        }
        if (myAutores.idFormaLabioInferior == null)
        {
            myCommand.Parameters.AddWithValue("@idFormaLabioInferior", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idFormaLabioInferior", myAutores.idFormaLabioInferior);
        }
        if (myAutores.idFormaLabioSuperior == null)
        {
            myCommand.Parameters.AddWithValue("@idFormaLabioSuperior", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idFormaLabioSuperior", myAutores.idFormaLabioSuperior);
        }
        if (string.IsNullOrEmpty(myAutores.idSic))
        {
            myCommand.Parameters.AddWithValue("@idSic", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idSic", myAutores.idSic);
        }
        myCommand.Parameters.AddWithValue("@idClaseRostro", myAutores.idClaseRostro);

        if (string.IsNullOrEmpty(myAutores.CubiertoCon))
        {
            myCommand.Parameters.AddWithValue("@cubiertoCon", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@cubiertoCon", myAutores.CubiertoCon);
        }

       /* myCommand.Parameters.AddWithValue("@idClaseSeniaParticular", myAutores.idClaseSeniaParticular);

        if (string.IsNullOrEmpty(myAutores.UbicacionSeniaParticular))
        {
            myCommand.Parameters.AddWithValue("@ubicacionSeniaParticular", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@ubicacionSeniaParticular", myAutores.UbicacionSeniaParticular);
        }

        myCommand.Parameters.AddWithValue("@idClaseLugarDelCuerpo", myAutores.idClaseLugarDelCuerpo);


        myCommand.Parameters.AddWithValue("@idClaseTatuaje", myAutores.idClaseTatuaje);
        */
        //if (string.IsNullOrEmpty(myAutores.OtroTatuaje))
        //{
        //    myCommand.Parameters.AddWithValue("@otroTatuaje", DBNull.Value);
        //}
        //else
        //{
        //    myCommand.Parameters.AddWithValue("@otroTatuaje", myAutores.OtroTatuaje);
        //}
        if (string.IsNullOrEmpty(myAutores.OtraCaracteristica))
        {
            myCommand.Parameters.AddWithValue("@otraCaracteristica", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@otraCaracteristica", myAutores.OtraCaracteristica);
        }
        if (myAutores.idPersona == 0)
        {
            myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idPersona", myAutores.idPersona);
        }
        //myCommand.Parameters.AddWithValue("@idPersona", myAutores.idPersona);
        if (string.IsNullOrEmpty(myAutores.idImputadoSimp))
        {
            myCommand.Parameters.AddWithValue("@idImputadoSimp", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idImputadoSimp", myAutores.idImputadoSimp);
        }
        myCommand.Parameters.AddWithValue("@baja", myAutores.Baja);

        if (string.IsNullOrEmpty(myAutores.idUsuarioUltimaModificacion))
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myAutores.idUsuarioUltimaModificacion);
        }
        if (myAutores.FechaUltimaModificacion == null)
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myAutores.FechaUltimaModificacion);
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
/// Deletes a Autores from the database.
/// </summary>
/// <param name="id">The id of the Autores to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("AutoresDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the Autores class and fills it with the data fom the IDataRecord.
/// </summary>
private static Autores FillDataRecord(IDataRecord myDataRecord )
{
Autores myAutores = new Autores();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myAutores.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDelito")))
{
myAutores.idDelito = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDelito"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCausa")))
{
myAutores.idCausa = myDataRecord.GetString(myDataRecord.GetOrdinal("idCausa"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Nro")))
{
myAutores.Nro = myDataRecord.GetString(myDataRecord.GetOrdinal("Nro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Nombre")))
{
    myAutores.Nombre = myDataRecord.GetString(myDataRecord.GetOrdinal("Nombre"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Apellido")))
{
    myAutores.Apellido = myDataRecord.GetString(myDataRecord.GetOrdinal("Apellido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DocumentoNumero")))
{
    myAutores.DocumentoNumero = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DocumentoNumero"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseEdadAproximada")))
{
myAutores.idClaseEdadAproximada = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseEdadAproximada"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseSexo")))
{
myAutores.idClaseSexo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseSexo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseEstatura")))
{
    myAutores.idClaseEstatura = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseEstatura"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseRobustez")))
{
    myAutores.idClaseRobustez = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseRobustez"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseColorPiel")))
{
    myAutores.idClaseColorPiel = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseColorPiel"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseColorOjos")))
{
    myAutores.idClaseColorOjos = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseColorOjos"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseColorCabello")))
{
    myAutores.idClaseColorCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseColorCabello"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseTipoCabello")))
{
    myAutores.idClaseTipoCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseTipoCabello"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseCalvicie")))
{
    myAutores.idClaseCalvicie = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseCalvicie"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseFormaCara")))
{
    myAutores.idClaseFormaCara = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseFormaCara"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDimensionCeja")))
{
    myAutores.idDimensionCeja = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDimensionCeja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoCeja")))
{
    myAutores.idTipoCeja = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoCeja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaMenton")))
{
    myAutores.idFormaMenton = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaMenton"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaOreja")))
{
    myAutores.idFormaOreja = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaOreja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaNariz")))
{
    myAutores.idFormaNariz = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaNariz"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaBoca")))
{
    myAutores.idFormaBoca = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaBoca"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaLabioInferior")))
{
    myAutores.idFormaLabioInferior = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaLabioInferior"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaLabioSuperior")))
{
    myAutores.idFormaLabioSuperior = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaLabioSuperior"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idSic")))
{
    myAutores.idSic = myDataRecord.GetString(myDataRecord.GetOrdinal("idSic"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseRostro")))
{
myAutores.idClaseRostro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseRostro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CubiertoCon")))
{
myAutores.CubiertoCon = myDataRecord.GetString(myDataRecord.GetOrdinal("CubiertoCon"));

}
   myAutores.seniasParticularess = SeniasParticularesDB.GetListByidAutor(myAutores.id);
   myAutores.tatuajesPersonas = TatuajesPersonaDB.GetListByidAutor(myAutores.id);
   

if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OtraCaracteristica")))
{
myAutores.OtraCaracteristica = myDataRecord.GetString(myDataRecord.GetOrdinal("OtraCaracteristica"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersona")))
{
    myAutores.idPersona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPersona"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idImputadoSimp")))
{
    myAutores.idImputadoSimp = myDataRecord.GetString(myDataRecord.GetOrdinal("idImputadoSimp"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myAutores.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
{
myAutores.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myAutores.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
return myAutores;
}
}

 } 
