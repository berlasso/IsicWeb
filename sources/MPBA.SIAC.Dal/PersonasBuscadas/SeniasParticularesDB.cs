using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The SeniasParticularesDB class is responsible for interacting with the database to retrieve and store information
/// about SeniasParticulares objects.
/// </summary>
public partial class SeniasParticularesDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SeniasParticulares from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the SeniasParticulares in the database.</param>
/// <returns>An SeniasParticulares when the id was found in the database, or null otherwise.</returns>
public static SeniasParticulares GetItem(int id)
{
SeniasParticulares mySeniasParticulares = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SeniasParticularesSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySeniasParticulares = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySeniasParticulares;
}
}


/// <summary>
/// Gets an instance of SeniasParticulares from the underlying datasource.
/// </summary>
/// <param name="idPersona">The unique idPersona of the SeniasParticulares in the database.</param>
/// /// <param name="idTablaDestino">The unique idTablaDestino of the SeniasParticulares in the database.</param>
/// <returns>An SeniasParticulares when the id was found in the database, or null otherwise.</returns>
public static SeniasParticularesList GetList(int idPersona, int idTablaDestino)
{
    SeniasParticularesList tempList = new SeniasParticularesList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("SeniasParticularesSelectListByIdPersona", myConnection))
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
}
return tempList;

}



/// <summary>
/// Returns a list with SeniasParticulares objects.
/// </summary>
/// <returns>A generics List with the SeniasParticulares objects.</returns>
public static SeniasParticularesList GetList()
{
SeniasParticularesList tempList = new SeniasParticularesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SeniasParticularesSelectList", myConnection))
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
/// Returns a list with SeniasParticulares objects.
/// </summary>
/// <returns>A generics List with the SeniasParticulares objects.</returns>
public static SeniasParticularesList GetListByidSeniaParticular(int idSeniaParticular)
{
SeniasParticularesList tempList = new SeniasParticularesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SeniasParticularesSelectListByidSeniaParticular", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idSeniaParticular", idSeniaParticular);
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
/// Returns a list with SeniasParticulares objects.
/// </summary>
/// <returns>A generics List with the SeniasParticulares objects.</returns>
public static SeniasParticularesList GetListByidTablaDestino(int idTablaDestino)
{
SeniasParticularesList tempList = new SeniasParticularesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SeniasParticularesSelectListByidTablaDestino", myConnection))
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
/// Returns a list with SeniasParticulares objects.
/// </summary>
/// <returns>A generics List with the SeniasParticulares objects.</returns>
public static SeniasParticularesList GetListByidUbicacionSeniaParticular(int idUbicacionSeniaParticular)
{
SeniasParticularesList tempList = new SeniasParticularesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SeniasParticularesSelectListByidUbicacionSeniaParticular", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", idUbicacionSeniaParticular);
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
/// Returns a list with SeniasParticulares objects.
/// </summary>
/// <returns>A generics List with the SeniasParticulares objects.</returns>
public static SeniasParticularesList GetListByidPersona(int idPersona,int idTablaDestino)
{
SeniasParticularesList tempList = new SeniasParticularesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SeniasParticularesSelectListByidPersona", myConnection))
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
/// Returns a list with SeniasParticulares objects.
/// </summary>
/// <returns>A generics List with the SeniasParticulares objects.</returns>
public static SeniasParticularesList GetListByIpp(string ipp, int idTablaDestino)
{
    SeniasParticularesList tempList = new SeniasParticularesList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("SeniasParticularesSelectListByIpp", myConnection))
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


/// <summary>
/// Saves a SeniasParticulares in the database.
/// </summary>
/// <param name="mySeniasParticulares">The SeniasParticulares instance to save.</param>
/// <returns>The new id if the SeniasParticulares is new in the database or the existing id when an item was updated.</returns>
public static int Save(SeniasParticulares mySeniasParticulares, SqlCommand myCommand)
{
int result = 0;
//using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
//{
//using (SqlCommand myCommand = new SqlCommand("SeniasParticularesInsertUpdateSingleItem", myConnection))
//{
//myCommand.CommandType = CommandType.StoredProcedure;
try
{
    myCommand.CommandText = "SeniasParticularesInsertUpdateSingleItem";
    myCommand.CommandType = CommandType.StoredProcedure;
    myCommand.Parameters.Clear();
if (mySeniasParticulares.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySeniasParticulares.id);
}
if (mySeniasParticulares.idPersona == null){
myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPersona", mySeniasParticulares.idPersona);
}
if (mySeniasParticulares.idSeniaParticular == null){
myCommand.Parameters.AddWithValue("@idSeniaParticular", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idSeniaParticular", mySeniasParticulares.idSeniaParticular);
}
if (mySeniasParticulares.idUbicacionSeniaParticular == null){
myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", mySeniasParticulares.idUbicacionSeniaParticular);
}
if (mySeniasParticulares.idTablaDestino == null){
myCommand.Parameters.AddWithValue("@idTablaDestino", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTablaDestino", mySeniasParticulares.idTablaDestino);
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

public static int Save(SeniasParticulares mySeniasParticulares)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("SeniasParticularesInsertUpdateSingleItem", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;

            if (mySeniasParticulares.id == -1)
            {
                myCommand.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@id", mySeniasParticulares.id);
            }
            if (mySeniasParticulares.idPersona == null)
            {
                myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idPersona", mySeniasParticulares.idPersona);
            }
            if (mySeniasParticulares.idSeniaParticular == null)
            {
                myCommand.Parameters.AddWithValue("@idSeniaParticular", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idSeniaParticular", mySeniasParticulares.idSeniaParticular);
            }
            if (mySeniasParticulares.idUbicacionSeniaParticular == null)
            {
                myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", mySeniasParticulares.idUbicacionSeniaParticular);
            }
            if (mySeniasParticulares.idTablaDestino == null)
            {
                myCommand.Parameters.AddWithValue("@idTablaDestino", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idTablaDestino", mySeniasParticulares.idTablaDestino);
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
/// Deletes a SeniasParticulares from the database.
/// </summary>
/// <param name="id">The id of the SeniasParticulares to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SeniasParticularesDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SeniasParticulares class and fills it with the data fom the IDataRecord.
/// </summary>
private static SeniasParticulares FillDataRecord(IDataRecord myDataRecord )
{
SeniasParticulares mySeniasParticulares = new SeniasParticulares();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
mySeniasParticulares.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersona")))
{
mySeniasParticulares.idPersona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPersona"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idSeniaParticular")))
{
mySeniasParticulares.idSeniaParticular = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idSeniaParticular"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUbicacionSeniaParticular")))
{
mySeniasParticulares.idUbicacionSeniaParticular = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idUbicacionSeniaParticular"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTablaDestino")))
{
mySeniasParticulares.idTablaDestino = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTablaDestino"));
}
return mySeniasParticulares;
}
}

 } 
