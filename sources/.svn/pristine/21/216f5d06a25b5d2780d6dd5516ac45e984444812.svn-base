using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseFormaOrejaDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseFormaOreja objects.
/// </summary>
public partial class SICClaseFormaOrejaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseFormaOreja from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseFormaOreja in the database.</param>
/// <returns>An SICClaseFormaOreja when the Id was found in the database, or null otherwise.</returns>
public static SICClaseFormaOreja GetItem(int id)
{
SICClaseFormaOreja mySICClaseFormaOreja = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaOrejaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseFormaOreja = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseFormaOreja;
}
}

/// <summary>
/// Returns a list with SICClaseFormaOreja objects.
/// </summary>
/// <returns>A generics List with the SICClaseFormaOreja objects.</returns>
public static SICClaseFormaOrejaList GetList()
{
SICClaseFormaOrejaList tempList = new SICClaseFormaOrejaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaOrejaSelectList", myConnection))
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
/// Saves a SICClaseFormaOreja in the database.
/// </summary>
/// <param name="mySICClaseFormaOreja">The SICClaseFormaOreja instance to save.</param>
/// <returns>The new Id if the SICClaseFormaOreja is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseFormaOreja mySICClaseFormaOreja)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaOrejaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseFormaOreja.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseFormaOreja.Id);
}
if (string.IsNullOrEmpty(mySICClaseFormaOreja.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseFormaOreja.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseFormaOreja.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseFormaOreja.Letra);
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
/// Deletes a SICClaseFormaOreja from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaOreja to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaOrejaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseFormaOreja class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseFormaOreja FillDataRecord(IDataRecord myDataRecord )
{
SICClaseFormaOreja mySICClaseFormaOreja = new SICClaseFormaOreja();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseFormaOreja.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseFormaOreja.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseFormaOreja.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseFormaOreja;
}
}

 } 
