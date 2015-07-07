using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseFormaNarizDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseFormaNariz objects.
/// </summary>
public partial class SICClaseFormaNarizDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseFormaNariz from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseFormaNariz in the database.</param>
/// <returns>An SICClaseFormaNariz when the Id was found in the database, or null otherwise.</returns>
public static SICClaseFormaNariz GetItem(int id)
{
SICClaseFormaNariz mySICClaseFormaNariz = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaNarizSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseFormaNariz = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseFormaNariz;
}
}

/// <summary>
/// Returns a list with SICClaseFormaNariz objects.
/// </summary>
/// <returns>A generics List with the SICClaseFormaNariz objects.</returns>
public static SICClaseFormaNarizList GetList()
{
SICClaseFormaNarizList tempList = new SICClaseFormaNarizList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaNarizSelectList", myConnection))
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
/// Saves a SICClaseFormaNariz in the database.
/// </summary>
/// <param name="mySICClaseFormaNariz">The SICClaseFormaNariz instance to save.</param>
/// <returns>The new Id if the SICClaseFormaNariz is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseFormaNariz mySICClaseFormaNariz)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaNarizInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseFormaNariz.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseFormaNariz.Id);
}
if (string.IsNullOrEmpty(mySICClaseFormaNariz.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseFormaNariz.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseFormaNariz.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseFormaNariz.Letra);
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
/// Deletes a SICClaseFormaNariz from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaNariz to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaNarizDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseFormaNariz class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseFormaNariz FillDataRecord(IDataRecord myDataRecord )
{
SICClaseFormaNariz mySICClaseFormaNariz = new SICClaseFormaNariz();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseFormaNariz.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseFormaNariz.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseFormaNariz.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseFormaNariz;
}
}

 } 
