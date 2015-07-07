using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
/// <summary>
/// The LocalidadDB class is responsible for interacting with the database to retrieve and store information
/// about Localidad objects.
/// </summary>
public partial class LocalidadDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of Localidad from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the Localidad in the database.</param>
/// <returns>An Localidad when the id was found in the database, or null otherwise.</returns>
public static Localidad GetItem(int id)
{
Localidad myLocalidad = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("LocalidadSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myLocalidad = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myLocalidad;
}
}

/// <summary>
/// Returns a list with Localidad objects.
/// </summary>
/// <returns>A generics List with the Localidad objects.</returns>
public static LocalidadList GetList()
{
    LocalidadList tempList = new LocalidadList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("LocalidadSelectList", myConnection))
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
/// Returns a list with Localidad objects matching localidad
/// </summary>
/// <param name="localidad">localidad being searched</param>
/// <returns>A generics List with the Localidad objects that match localidad.</returns>
public static LocalidadList GetList(string localidad)
{
    LocalidadList tempList = new LocalidadList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("LocalidadSelectListByLocalidad", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@localidad", localidad);
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
/// Returns a list with Localidad objects.
/// </summary>
/// <returns>A generics List with the Localidad objects.</returns>
public static LocalidadList GetListByPartido(int Partido)
{
LocalidadList tempList = new LocalidadList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("LocalidadSelectListByPartido", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@partido", Partido);
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
/// Returns a list with Localidad objects.
/// </summary>
/// <returns>A generics List with the Localidad objects.</returns>
public static LocalidadList GetListByProvincia(int Provincia)
{
LocalidadList tempList = new LocalidadList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("LocalidadSelectListByProvincia", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@provincia", Provincia);
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
/// Saves a Localidad in the database.
/// </summary>
/// <param name="myLocalidad">The Localidad instance to save.</param>
/// <returns>The new id if the Localidad is new in the database or the existing id when an item was updated.</returns>
public static int Save(Localidad myLocalidad)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("LocalidadInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myLocalidad.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myLocalidad.id);
}
if (string.IsNullOrEmpty(myLocalidad.localidad))
{
myCommand.Parameters.AddWithValue("@localidad", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@localidad", myLocalidad.localidad);
}

    myCommand.Parameters.AddWithValue("@partido", myLocalidad.Partido);

if (string.IsNullOrEmpty(myLocalidad.CodigoPostal))
{
myCommand.Parameters.AddWithValue("@codigoPostal", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@codigoPostal", myLocalidad.CodigoPostal);
}

myCommand.Parameters.AddWithValue("@provincia", myLocalidad.Provincia);


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
/// Deletes a Localidad from the database.
/// </summary>
/// <param name="id">The id of the Localidad to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("LocalidadDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the Localidad class and fills it with the data fom the IDataRecord.
/// </summary>
private static Localidad FillDataRecord(IDataRecord myDataRecord )
{
Localidad myLocalidad = new Localidad();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myLocalidad.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Localidad")))
{
myLocalidad.localidad = myDataRecord.GetString(myDataRecord.GetOrdinal("Localidad"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Partido")))
{
myLocalidad.Partido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Partido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CodigoPostal")))
{
myLocalidad.CodigoPostal = myDataRecord.GetString(myDataRecord.GetOrdinal("CodigoPostal"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Provincia")))
{
myLocalidad.Provincia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Provincia"));
}
return myLocalidad;
}
}

 } 
