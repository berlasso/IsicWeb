using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The BusquedaGrupoSanguineoDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaGrupoSanguineo objects.
/// </summary>
public partial class BusquedaGrupoSanguineoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaGrupoSanguineo from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaGrupoSanguineo in the database.</param>
/// <returns>An BusquedaGrupoSanguineo when the id was found in the database, or null otherwise.</returns>
public static BusquedaGrupoSanguineo GetItem(decimal id)
{
BusquedaGrupoSanguineo myBusquedaGrupoSanguineo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaGrupoSanguineoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaGrupoSanguineo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaGrupoSanguineo;
}
}

/// <summary>
/// Returns a list with BusquedaGrupoSanguineo objects.
/// </summary>
/// <returns>A generics List with the BusquedaGrupoSanguineo objects.</returns>
public static BusquedaGrupoSanguineoList GetList()
{
BusquedaGrupoSanguineoList tempList = new BusquedaGrupoSanguineoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaGrupoSanguineoSelectList", myConnection))
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
/// Returns a list with BusquedaGrupoSanguineo objects.
/// </summary>
/// <returns>A generics List with the BusquedaGrupoSanguineo objects.</returns>
public static BusquedaGrupoSanguineoList GetListByidBusqueda(decimal idBusqueda)
{
BusquedaGrupoSanguineoList tempList = new BusquedaGrupoSanguineoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaGrupoSanguineoSelectListByidBusqueda", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idBusqueda", idBusqueda);
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
/// Returns a list with BusquedaGrupoSanguineo objects.
/// </summary>
/// <returns>A generics List with the BusquedaGrupoSanguineo objects.</returns>
public static BusquedaGrupoSanguineoList GetListByidGrupoSanguineo(int idGrupoSanguineo)
{
BusquedaGrupoSanguineoList tempList = new BusquedaGrupoSanguineoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaGrupoSanguineoSelectListByidGrupoSanguineo", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idGrupoSanguineo", idGrupoSanguineo);
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
/// Saves a BusquedaGrupoSanguineo in the database.
/// </summary>
/// <param name="myBusquedaGrupoSanguineo">The BusquedaGrupoSanguineo instance to save.</param>
/// <returns>The new id if the BusquedaGrupoSanguineo is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaGrupoSanguineo myBusquedaGrupoSanguineo, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //using (SqlCommand myCommand = new SqlCommand("BusquedaGrupoSanguineoInsertUpdateSingleItem", myConnection))
    //{
    //myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.CommandText = "BusquedaGrupoSanguineoInsertUpdateSingleItem";
    myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.Parameters.Clear();
    try
    {
        if (myBusquedaGrupoSanguineo.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myBusquedaGrupoSanguineo.id);
        }
        if (myBusquedaGrupoSanguineo.idBusqueda == null)
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaGrupoSanguineo.idBusqueda);
        }
        if (myBusquedaGrupoSanguineo.idGrupoSanguineo == null)
        {
            myCommand.Parameters.AddWithValue("@idGrupoSanguineo", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idGrupoSanguineo", myBusquedaGrupoSanguineo.idGrupoSanguineo);
        }

        DbParameter returnValue;
        returnValue = myCommand.CreateParameter();
        returnValue.Direction = ParameterDirection.ReturnValue;
        myCommand.Parameters.Add(returnValue);

        //myConnection.Open();
        myCommand.ExecuteNonQuery();
        result = Convert.ToInt32(returnValue.Value);
        //myConnection.Close();
        //}
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
/// Deletes a BusquedaGrupoSanguineo from the database.
/// </summary>
/// <param name="id">The id of the BusquedaGrupoSanguineo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(decimal id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaGrupoSanguineoDeleteSingleItem", myConnection))
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

/// <summary>
/// Deletes las BusquedaGrupoSanguineo de una Busqueda from the database.
/// </summary>
/// <param name="id">The idBusqueda of the BusquedaGrupoSanguineo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BusquedaGrupoSanguineoDeleteItemByIdBusqueda", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.AddWithValue("@idBusqueda", idBusqueda);
            myConnection.Open();
            result = myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }
    return result > 0;
}

#endregion

/// <summary>
/// Initializes a new instance of the BusquedaGrupoSanguineo class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaGrupoSanguineo FillDataRecord(IDataRecord myDataRecord )
{
BusquedaGrupoSanguineo myBusquedaGrupoSanguineo = new BusquedaGrupoSanguineo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaGrupoSanguineo.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
{
myBusquedaGrupoSanguineo.idBusqueda = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("idBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idGrupoSanguineo")))
{
myBusquedaGrupoSanguineo.idGrupoSanguineo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idGrupoSanguineo"));
}
return myBusquedaGrupoSanguineo;
}
}

 } 
