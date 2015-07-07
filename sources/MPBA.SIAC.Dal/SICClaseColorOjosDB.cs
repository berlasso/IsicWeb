using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseColorOjosDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseColorOjos objects.
/// </summary>
public partial class SICClaseColorOjosDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseColorOjos from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseColorOjos in the database.</param>
/// <returns>An SICClaseColorOjos when the Id was found in the database, or null otherwise.</returns>
public static SICClaseColorOjos GetItem(int id)
{
SICClaseColorOjos mySICClaseColorOjos = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorOjosSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseColorOjos = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseColorOjos;
}
}

/// <summary>
/// Returns a list with SICClaseColorOjos objects.
/// </summary>
/// <returns>A generics List with the SICClaseColorOjos objects.</returns>
public static SICClaseColorOjosList GetList()
{
SICClaseColorOjosList tempList = new SICClaseColorOjosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorOjosSelectList", myConnection))
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
/// Saves a SICClaseColorOjos in the database.
/// </summary>
/// <param name="mySICClaseColorOjos">The SICClaseColorOjos instance to save.</param>
/// <returns>The new Id if the SICClaseColorOjos is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseColorOjos mySICClaseColorOjos)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorOjosInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseColorOjos.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseColorOjos.Id);
}
if (string.IsNullOrEmpty(mySICClaseColorOjos.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseColorOjos.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseColorOjos.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseColorOjos.Letra);
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
/// Deletes a SICClaseColorOjos from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseColorOjos to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseColorOjosDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseColorOjos class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseColorOjos FillDataRecord(IDataRecord myDataRecord )
{
SICClaseColorOjos mySICClaseColorOjos = new SICClaseColorOjos();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseColorOjos.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseColorOjos.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseColorOjos.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseColorOjos;
}
}

 } 
