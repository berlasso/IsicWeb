using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The SICClaseCejasDimensionDB class is responsible for interacting with the database to retrieve and store information
/// about SICClaseCejasDimension objects.
/// </summary>
public partial class SICClaseCejasDimensionDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of SICClaseCejasDimension from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the SICClaseCejasDimension in the database.</param>
/// <returns>An SICClaseCejasDimension when the Id was found in the database, or null otherwise.</returns>
public static SICClaseCejasDimension GetItem(int id)
{
SICClaseCejasDimension mySICClaseCejasDimension = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseCejasDimensionSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
mySICClaseCejasDimension = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return mySICClaseCejasDimension;
}
}

/// <summary>
/// Returns a list with SICClaseCejasDimension objects.
/// </summary>
/// <returns>A generics List with the SICClaseCejasDimension objects.</returns>
public static SICClaseCejasDimensionList GetList()
{
SICClaseCejasDimensionList tempList = new SICClaseCejasDimensionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseCejasDimensionSelectList", myConnection))
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
/// Saves a SICClaseCejasDimension in the database.
/// </summary>
/// <param name="mySICClaseCejasDimension">The SICClaseCejasDimension instance to save.</param>
/// <returns>The new Id if the SICClaseCejasDimension is new in the database or the existing Id when an item was updated.</returns>
public static int Save(SICClaseCejasDimension mySICClaseCejasDimension)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseCejasDimensionInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (mySICClaseCejasDimension.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", mySICClaseCejasDimension.Id);
}
if (string.IsNullOrEmpty(mySICClaseCejasDimension.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", mySICClaseCejasDimension.Descripcion);
}
if (string.IsNullOrEmpty(mySICClaseCejasDimension.Letra))
{
myCommand.Parameters.AddWithValue("@letra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@letra", mySICClaseCejasDimension.Letra);
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
/// Deletes a SICClaseCejasDimension from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseCejasDimension to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("SICClaseCejasDimensionDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the SICClaseCejasDimension class and fills it with the data fom the IDataRecord.
/// </summary>
private static SICClaseCejasDimension FillDataRecord(IDataRecord myDataRecord )
{
SICClaseCejasDimension mySICClaseCejasDimension = new SICClaseCejasDimension();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
mySICClaseCejasDimension.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
mySICClaseCejasDimension.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Letra")))
{
mySICClaseCejasDimension.Letra = myDataRecord.GetString(myDataRecord.GetOrdinal("Letra"));
}
return mySICClaseCejasDimension;
}
}

 } 
