using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseCejasTipoDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseCejasTipo objects.
/// </summary>
public partial class SICClaseCejasTipoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseCejasTipo from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseCejasTipo in the database.</param>
/// <returns>An SICClaseCejasTipo when the Id was found in the database, or null otherwise.</returns>
public static SICClaseCejasTipo GetItem(int id)
{
SICClaseCejasTipo mySICClaseCejasTipo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseCejasTipoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseCejasTipo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseCejasTipo;
}
}

/// <summary>
/// Returns a list with SICClaseCejasTipo objects.
/// </summary>
/// <returns>A generics List with the SICClaseCejasTipo objects.</returns>
public static SICClaseCejasTipoList GetList()
{
SICClaseCejasTipoList tempList = new SICClaseCejasTipoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseCejasTipoSelectList", myConnection))
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
/// Saves a SICClaseCejasTipo in the database.
/// </summary>
/// <param name="mySICClaseCejasTipo">The SICClaseCejasTipo instance to save.</param>
/// <returns>The new Id if the SICClaseCejasTipo is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseCejasTipo mySICClaseCejasTipo)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseCejasTipoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseCejasTipo.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseCejasTipo.Id);
}
if (string.IsNullOrEmpty(mySICClaseCejasTipo.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseCejasTipo.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseCejasTipo.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseCejasTipo.Letra);
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
/// Deletes a SICClaseCejasTipo from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseCejasTipo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseCejasTipoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseCejasTipo class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseCejasTipo FillDataRecord(IDataRecord myDataRecord )
{
SICClaseCejasTipo mySICClaseCejasTipo = new SICClaseCejasTipo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseCejasTipo.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseCejasTipo.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseCejasTipo.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseCejasTipo;
}
}

 } 
