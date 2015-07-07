using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The ClaseSeniaParticularDB class is responsible for interacting with the database to retrieve and store information
/// about ClaseSeniaParticular objects.
/// </summary>
public partial class ClaseSeniaParticularDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of ClaseSeniaParticular from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the ClaseSeniaParticular in the database.</param>
/// <returns>An ClaseSeniaParticular when the id was found in the database, or null otherwise.</returns>
public static ClaseSeniaParticular GetItem(int id)
{
ClaseSeniaParticular myClaseSeniaParticular = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseSeniaParticularSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myClaseSeniaParticular = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myClaseSeniaParticular;
}
}

/// <summary>
/// Returns a list with ClaseSeniaParticular objects.
/// </summary>
/// <returns>A generics List with the ClaseSeniaParticular objects.</returns>
public static ClaseSeniaParticularList GetList()
{
ClaseSeniaParticularList tempList = new ClaseSeniaParticularList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseSeniaParticularSelectList", myConnection))
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
/// Saves a ClaseSeniaParticular in the database.
/// </summary>
/// <param name="myClaseSeniaParticular">The ClaseSeniaParticular instance to save.</param>
/// <returns>The new id if the ClaseSeniaParticular is new in the database or the existing id when an item was updated.</returns>
public static int Save(ClaseSeniaParticular myClaseSeniaParticular)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseSeniaParticularInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myClaseSeniaParticular.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myClaseSeniaParticular.id);
}
if (string.IsNullOrEmpty(myClaseSeniaParticular.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myClaseSeniaParticular.Descripcion);
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
/// Deletes a ClaseSeniaParticular from the database.
/// </summary>
/// <param name="id">The id of the ClaseSeniaParticular to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseSeniaParticularDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the ClaseSeniaParticular class and fills it with the data fom the IDataRecord.
/// </summary>
private static ClaseSeniaParticular FillDataRecord(IDataRecord myDataRecord )
{
ClaseSeniaParticular myClaseSeniaParticular = new ClaseSeniaParticular();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myClaseSeniaParticular.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myClaseSeniaParticular.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myClaseSeniaParticular;
}
}

 } 
