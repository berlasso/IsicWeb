using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
/// <summary>
/// The PBClaseTipoJurisdiccionCausaDB class is responsible for interacting with the database to retrieve and store information
/// about PBClaseTipoJurisdiccionCausa objects.
/// </summary>
public partial class PBClaseTipoJurisdiccionCausaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PBClaseTipoJurisdiccionCausa from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the PBClaseTipoJurisdiccionCausa in the database.</param>
/// <returns>An PBClaseTipoJurisdiccionCausa when the id was found in the database, or null otherwise.</returns>
public static PBClaseTipoJurisdiccionCausa GetItem(int id)
{
PBClaseTipoJurisdiccionCausa myPBClaseTipoJurisdiccionCausa = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTipoJurisdiccionCausaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPBClaseTipoJurisdiccionCausa = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPBClaseTipoJurisdiccionCausa;
}
}

/// <summary>
/// Returns a list with PBClaseTipoJurisdiccionCausa objects.
/// </summary>
/// <returns>A generics List with the PBClaseTipoJurisdiccionCausa objects.</returns>
public static PBClaseTipoJurisdiccionCausaList GetList()
{
PBClaseTipoJurisdiccionCausaList tempList = new PBClaseTipoJurisdiccionCausaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTipoJurisdiccionCausaSelectList", myConnection))
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
/// Saves a PBClaseTipoJurisdiccionCausa in the database.
/// </summary>
/// <param name="myPBClaseTipoJurisdiccionCausa">The PBClaseTipoJurisdiccionCausa instance to save.</param>
/// <returns>The new id if the PBClaseTipoJurisdiccionCausa is new in the database or the existing id when an item was updated.</returns>
public static int Save(PBClaseTipoJurisdiccionCausa myPBClaseTipoJurisdiccionCausa)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTipoJurisdiccionCausaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPBClaseTipoJurisdiccionCausa.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPBClaseTipoJurisdiccionCausa.id);
}
if (string.IsNullOrEmpty(myPBClaseTipoJurisdiccionCausa.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myPBClaseTipoJurisdiccionCausa.Descripcion);
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
/// Deletes a PBClaseTipoJurisdiccionCausa from the database.
/// </summary>
/// <param name="id">The id of the PBClaseTipoJurisdiccionCausa to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PBClaseTipoJurisdiccionCausaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PBClaseTipoJurisdiccionCausa class and fills it with the data fom the IDataRecord.
/// </summary>
private static PBClaseTipoJurisdiccionCausa FillDataRecord(IDataRecord myDataRecord )
{
PBClaseTipoJurisdiccionCausa myPBClaseTipoJurisdiccionCausa = new PBClaseTipoJurisdiccionCausa();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myPBClaseTipoJurisdiccionCausa.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myPBClaseTipoJurisdiccionCausa.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myPBClaseTipoJurisdiccionCausa;
}
}

 } 
