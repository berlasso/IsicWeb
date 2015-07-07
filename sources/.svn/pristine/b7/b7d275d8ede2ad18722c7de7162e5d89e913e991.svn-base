using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseFormaBocaDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseFormaBoca objects.
/// </summary>
public partial class SICClaseFormaBocaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseFormaBoca from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseFormaBoca in the database.</param>
/// <returns>An SICClaseFormaBoca when the Id was found in the database, or null otherwise.</returns>
public static SICClaseFormaBoca GetItem(int id)
{
SICClaseFormaBoca mySICClaseFormaBoca = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaBocaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseFormaBoca = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseFormaBoca;
}
}

/// <summary>
/// Returns a list with SICClaseFormaBoca objects.
/// </summary>
/// <returns>A generics List with the SICClaseFormaBoca objects.</returns>
public static SICClaseFormaBocaList GetList()
{
SICClaseFormaBocaList tempList = new SICClaseFormaBocaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaBocaSelectList", myConnection))
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
/// Saves a SICClaseFormaBoca in the database.
/// </summary>
/// <param name="mySICClaseFormaBoca">The SICClaseFormaBoca instance to save.</param>
/// <returns>The new Id if the SICClaseFormaBoca is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseFormaBoca mySICClaseFormaBoca)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaBocaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseFormaBoca.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseFormaBoca.Id);
}
if (string.IsNullOrEmpty(mySICClaseFormaBoca.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseFormaBoca.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseFormaBoca.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseFormaBoca.Letra);
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
/// Deletes a SICClaseFormaBoca from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaBoca to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseFormaBocaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseFormaBoca class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseFormaBoca FillDataRecord(IDataRecord myDataRecord )
{
SICClaseFormaBoca mySICClaseFormaBoca = new SICClaseFormaBoca();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseFormaBoca.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseFormaBoca.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseFormaBoca.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseFormaBoca;
}
}

 } 
