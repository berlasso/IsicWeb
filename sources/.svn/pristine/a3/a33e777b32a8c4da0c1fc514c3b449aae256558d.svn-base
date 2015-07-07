using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseEstaturaDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseEstatura objects.
/// </summary>
public partial class SICClaseEstaturaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseEstatura from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseEstatura in the database.</param>
/// <returns>An SICClaseEstatura when the Id was found in the database, or null otherwise.</returns>
public static SICClaseEstatura GetItem(int id)
{
SICClaseEstatura mySICClaseEstatura = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseEstaturaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseEstatura = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseEstatura;
}
}

/// <summary>
/// Returns a list with SICClaseEstatura objects.
/// </summary>
/// <returns>A generics List with the SICClaseEstatura objects.</returns>
public static SICClaseEstaturaList GetList()
{
SICClaseEstaturaList tempList = new SICClaseEstaturaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseEstaturaSelectList", myConnection))
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
/// Saves a SICClaseEstatura in the database.
/// </summary>
/// <param name="mySICClaseEstatura">The SICClaseEstatura instance to save.</param>
/// <returns>The new Id if the SICClaseEstatura is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseEstatura mySICClaseEstatura)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseEstaturaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseEstatura.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseEstatura.Id);
}
if (string.IsNullOrEmpty(mySICClaseEstatura.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseEstatura.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseEstatura.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseEstatura.Letra);
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
/// Deletes a SICClaseEstatura from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseEstatura to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseEstaturaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseEstatura class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseEstatura FillDataRecord(IDataRecord myDataRecord )
{
SICClaseEstatura mySICClaseEstatura = new SICClaseEstatura();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseEstatura.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseEstatura.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseEstatura.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseEstatura;
}
}

 } 
