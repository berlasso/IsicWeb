using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The PBClaseCalvicieDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseCalvicie objects.
/// </summary>
public partial class PBClaseCalvicieDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseCalvicie from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PBClaseCalvicie in the database.</param>
/// <returns>An PBClaseCalvicie when the Id was found in the database, or null otherwise.</returns>
public static PBClaseCalvicie GetItem(int id)
{
PBClaseCalvicie myPBClaseCalvicie = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseCalvicieSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseCalvicie = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseCalvicie;
}
}

/// <summary>
/// Returns a list with PBClaseCalvicie objects.
/// </summary>
/// <returns>A generics List with the PBClaseCalvicie objects.</returns>
public static PBClaseCalvicieList GetList()
{
PBClaseCalvicieList tempList = new PBClaseCalvicieList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseCalvicieSelectList", myConnection))
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
/// Saves a PBClaseCalvicie in the database.
/// </summary>
/// <param name="myPBClaseCalvicie">The PBClaseCalvicie instance to save.</param>
/// <returns>The new Id if the PBClaseCalvicie is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PBClaseCalvicie myPBClaseCalvicie)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseCalvicieInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseCalvicie.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseCalvicie.Id);
}
if (string.IsNullOrEmpty(myPBClaseCalvicie.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseCalvicie.Descripcion);
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
/// Deletes a PBClaseCalvicie from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseCalvicie to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseCalvicieDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseCalvicie class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseCalvicie FillDataRecord(IDataRecord myDataRecord )
{
PBClaseCalvicie myPBClaseCalvicie = new PBClaseCalvicie();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPBClaseCalvicie.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseCalvicie.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseCalvicie;
}
}

 } 
