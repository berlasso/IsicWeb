using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseRostroDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseRostro objects.
/// </summary>
public partial class PBClaseRostroDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseRostro from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseRostro in the database.</param>
/// <returns>An PBClaseRostro when the Id was found in the database, or null otherwise.</returns>
public static PBClaseRostro GetItem(int id)
{
PBClaseRostro myPBClaseRostro = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseRostroSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseRostro = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseRostro;
}
}

/// <summary>
/// Returns a list with PBClaseRostro objects.
/// </summary>
/// <returns>A generics List with the PBClaseRostro objects.</returns>
public static PBClaseRostroList GetList()
{
PBClaseRostroList tempList = new PBClaseRostroList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseRostroSelectList", myConnection))
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
/// Saves a PBClaseRostro in the database.
/// </summary>
/// <param name="myPBClaseRostro">The PBClaseRostro instance to save.</param>
/// <returns>The new Id if the PBClaseRostro is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseRostro myPBClaseRostro)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseRostroInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseRostro.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseRostro.Id);
}
if (string.IsNullOrEmpty(myPBClaseRostro.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseRostro.Descripcion);
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
/// Deletes a PBClaseRostro from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseRostro to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseRostroDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseRostro class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseRostro FillDataRecord(IDataRecord myDataRecord )
{
PBClaseRostro myPBClaseRostro = new PBClaseRostro();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseRostro.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseRostro.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseRostro;
}
}

 } 
