using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseTipoCalvicieDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseTipoCalvicie objects.
/// </summary>
public partial class SICClaseTipoCalvicieDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseTipoCalvicie from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseTipoCalvicie in the database.</param>
/// <returns>An SICClaseTipoCalvicie when the Id was found in the database, or null otherwise.</returns>
public static SICClaseTipoCalvicie GetItem(int id)
{
SICClaseTipoCalvicie mySICClaseTipoCalvicie = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseTipoCalvicieSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseTipoCalvicie = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseTipoCalvicie;
}
}

/// <summary>
/// Returns a list with SICClaseTipoCalvicie objects.
/// </summary>
/// <returns>A generics List with the SICClaseTipoCalvicie objects.</returns>
public static SICClaseTipoCalvicieList GetList()
{
SICClaseTipoCalvicieList tempList = new SICClaseTipoCalvicieList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseTipoCalvicieSelectList", myConnection))
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
/// Saves a SICClaseTipoCalvicie in the database.
/// </summary>
/// <param name="mySICClaseTipoCalvicie">The SICClaseTipoCalvicie instance to save.</param>
/// <returns>The new Id if the SICClaseTipoCalvicie is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseTipoCalvicie mySICClaseTipoCalvicie)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseTipoCalvicieInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseTipoCalvicie.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseTipoCalvicie.Id);
}
if (string.IsNullOrEmpty(mySICClaseTipoCalvicie.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseTipoCalvicie.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseTipoCalvicie.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseTipoCalvicie.Letra);
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
/// Deletes a SICClaseTipoCalvicie from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseTipoCalvicie to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseTipoCalvicieDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseTipoCalvicie class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseTipoCalvicie FillDataRecord(IDataRecord myDataRecord )
{
SICClaseTipoCalvicie mySICClaseTipoCalvicie = new SICClaseTipoCalvicie();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseTipoCalvicie.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseTipoCalvicie.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseTipoCalvicie.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseTipoCalvicie;
}
}

 } 
