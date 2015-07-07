using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseFormaCaraDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseFormaCara objects.
/// </summary>
public partial class SICClaseFormaCaraDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseFormaCara from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseFormaCara in the database.</param>
/// <returns>An SICClaseFormaCara when the Id was found in the database, or null otherwise.</returns>
public static SICClaseFormaCara GetItem(int id)
{
SICClaseFormaCara mySICClaseFormaCara = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaCaraSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseFormaCara = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseFormaCara;
}
}

/// <summary>
/// Returns a list with SICClaseFormaCara objects.
/// </summary>
/// <returns>A generics List with the SICClaseFormaCara objects.</returns>
public static SICClaseFormaCaraList GetList()
{
SICClaseFormaCaraList tempList = new SICClaseFormaCaraList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaCaraSelectList", myConnection))
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
/// Saves a SICClaseFormaCara in the database.
/// </summary>
/// <param name="mySICClaseFormaCara">The SICClaseFormaCara instance to save.</param>
/// <returns>The new Id if the SICClaseFormaCara is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseFormaCara mySICClaseFormaCara)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaCaraInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseFormaCara.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseFormaCara.Id);
}
if (string.IsNullOrEmpty(mySICClaseFormaCara.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseFormaCara.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseFormaCara.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseFormaCara.Letra);
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
/// Deletes a SICClaseFormaCara from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaCara to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaCaraDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseFormaCara class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseFormaCara FillDataRecord(IDataRecord myDataRecord )
{
SICClaseFormaCara mySICClaseFormaCara = new SICClaseFormaCara();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseFormaCara.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseFormaCara.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseFormaCara.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseFormaCara;
}
}

 } 
