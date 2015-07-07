using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The BusquedaTatuajesDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaTatuajes objects.
/// </summary>
public partial class BusquedaTatuajesDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaTatuajes from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaTatuajes in the database.</param>
/// <returns>An BusquedaTatuajes when the id was found in the database, or null otherwise.</returns>
public static BusquedaTatuajes GetItem(decimal id)
{
BusquedaTatuajes myBusquedaTatuajes = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaTatuajesSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaTatuajes = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaTatuajes;
}
}

/// <summary>
/// Returns a list with BusquedaTatuajes objects.
/// </summary>
/// <returns>A generics List with the BusquedaTatuajes objects.</returns>
public static BusquedaTatuajesList GetList()
{
BusquedaTatuajesList tempList = new BusquedaTatuajesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaTatuajesSelectList", myConnection))
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
/// Returns a list with BusquedaTatuajes objects.
/// </summary>
/// <returns>A generics List with the BusquedaTatuajes objects.</returns>
public static BusquedaTatuajesList GetListByidBusqueda(decimal idBusqueda)
{
BusquedaTatuajesList tempList = new BusquedaTatuajesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaTatuajesSelectListByidBusqueda", myConnection))
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
/// Returns a list with BusquedaTatuajes objects.
/// </summary>
/// <returns>A generics List with the BusquedaTatuajes objects.</returns>
public static BusquedaTatuajesList GetListByIdClaseTatuaje(int IdClaseTatuaje)
{
BusquedaTatuajesList tempList = new BusquedaTatuajesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaTatuajesSelectListByIdClaseTatuaje", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseTatuaje", IdClaseTatuaje);
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
/// Returns a list with BusquedaTatuajes objects.
/// </summary>
/// <returns>A generics List with the BusquedaTatuajes objects.</returns>
public static BusquedaTatuajesList GetListByIdUbicacionTatuaje(int IdUbicacionTatuaje)
{
BusquedaTatuajesList tempList = new BusquedaTatuajesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaTatuajesSelectListByIdUbicacionTatuaje", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idUbicacionTatuaje", IdUbicacionTatuaje);
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
/// Saves a BusquedaTatuajes in the database.
/// </summary>
/// <param name="myBusquedaTatuajes">The BusquedaTatuajes instance to save.</param>
/// <returns>The new id if the BusquedaTatuajes is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaTatuajes myBusquedaTatuajes)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaTatuajesInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaTatuajes.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaTatuajes.id);
}
if (myBusquedaTatuajes.idBusqueda == null){
myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaTatuajes.idBusqueda);
}
if (myBusquedaTatuajes.IdClaseTatuaje == null){
myCommand.Parameters.AddWithValue("@idClaseTatuaje", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseTatuaje", myBusquedaTatuajes.IdClaseTatuaje);
}
if (myBusquedaTatuajes.IdUbicacionTatuaje == null){
myCommand.Parameters.AddWithValue("@idUbicacionTatuaje", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idUbicacionTatuaje", myBusquedaTatuajes.IdUbicacionTatuaje);
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
/// Saves a BusquedaTatuajes in the database.
/// </summary>
/// <param name="myBusquedaTatuajes">The BusquedaTatuajes instance to save.</param>
/// <returns>The new id if the BusquedaTatuajes is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaTatuajes myBusquedaTatuajes, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("BusquedaTatuajesInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
     myCommand.CommandText = "BusquedaTatuajesInsertUpdateSingleItem";
     myCommand.CommandType = CommandType.StoredProcedure;
     myCommand.Parameters.Clear();
     try
     {
         if (myBusquedaTatuajes.id == -1)
         {
             myCommand.Parameters.AddWithValue("@id", DBNull.Value);
         }
         else
         {
             myCommand.Parameters.AddWithValue("@id", myBusquedaTatuajes.id);
         }
         if (myBusquedaTatuajes.idBusqueda == null)
         {
             myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
         }
         else
         {
             myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaTatuajes.idBusqueda);
         }
         if (myBusquedaTatuajes.IdClaseTatuaje == null)
         {
             myCommand.Parameters.AddWithValue("@idClaseTatuaje", DBNull.Value);
         }
         else
         {
             myCommand.Parameters.AddWithValue("@idClaseTatuaje", myBusquedaTatuajes.IdClaseTatuaje);
         }
         if (myBusquedaTatuajes.IdUbicacionTatuaje == null)
         {
             myCommand.Parameters.AddWithValue("@idUbicacionTatuaje", DBNull.Value);
         }
         else
         {
             myCommand.Parameters.AddWithValue("@idUbicacionTatuaje", myBusquedaTatuajes.IdUbicacionTatuaje);
         }

         DbParameter returnValue;
         returnValue = myCommand.CreateParameter();
         returnValue.Direction = ParameterDirection.ReturnValue;
         myCommand.Parameters.Add(returnValue);

         //myConnection.Open();
         myCommand.ExecuteNonQuery();
         result = Convert.ToInt32(returnValue.Value);
         // myConnection.Close();
         //}
         //}
     }//try
     catch (Exception e)
     {
         //tr.Rollback();
         throw e;
     }
     return result;
   
}

/// <summary>
/// Deletes a BusquedaTatuajes from the database.
/// </summary>
/// <param name="id">The id of the BusquedaTatuajes to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(decimal id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaTatuajesDeleteSingleItem", myConnection))
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
/// Deletes las BusquedaSeniasParticulares de una Busqueda from the database.
/// </summary>
/// <param name="id">The idBusqueda of the BusquedaSeniasParticulares to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BusquedaTatuajesDeleteItemByIdBusqueda", myConnection))
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
/// Initializes a new instance of the BusquedaTatuajes class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaTatuajes FillDataRecord(IDataRecord myDataRecord )
{
BusquedaTatuajes myBusquedaTatuajes = new BusquedaTatuajes();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaTatuajes.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
{
myBusquedaTatuajes.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseTatuaje")))
{
myBusquedaTatuajes.IdClaseTatuaje = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseTatuaje"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdUbicacionTatuaje")))
{
myBusquedaTatuajes.IdUbicacionTatuaje = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdUbicacionTatuaje"));
}
return myBusquedaTatuajes;
}
}

 } 
