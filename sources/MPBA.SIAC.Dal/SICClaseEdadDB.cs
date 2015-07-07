using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseEdadDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseEdad objects.
/// </summary>
public partial class SICClaseEdadDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseEdad from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseEdad in the database.</param>
/// <returns>An SICClaseEdad when the Id was found in the database, or null otherwise.</returns>
public static SICClaseEdad GetItem(int id)
{
SICClaseEdad mySICClaseEdad = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseEdadSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseEdad = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseEdad;
}
}

/// <summary>
/// Returns a list with SICClaseEdad objects.
/// </summary>
/// <returns>A generics List with the SICClaseEdad objects.</returns>
public static SICClaseEdadList GetList()
{
SICClaseEdadList tempList = new SICClaseEdadList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseEdadSelectList", myConnection))
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
/// Saves a SICClaseEdad in the database.
/// </summary>
/// <param name="mySICClaseEdad">The SICClaseEdad instance to save.</param>
/// <returns>The new Id if the SICClaseEdad is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseEdad mySICClaseEdad)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseEdadInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseEdad.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseEdad.Id);
}
if (string.IsNullOrEmpty(mySICClaseEdad.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseEdad.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseEdad.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseEdad.Letra);
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
/// Deletes a SICClaseEdad from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseEdad to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseEdadDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseEdad class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseEdad FillDataRecord(IDataRecord myDataRecord )
{
SICClaseEdad mySICClaseEdad = new SICClaseEdad();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseEdad.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseEdad.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseEdad.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseEdad;
}
}

 } 
