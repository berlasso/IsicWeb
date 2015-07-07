using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
/// <summary>
/// The DepartamentoDB class is responsible for interacting with the database to retrieve and store information
/// about Departamento objects.
/// </summary>
public partial class DepartamentoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of Departamento from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the Departamento in the database.</param>
/// <returns>An Departamento when the Id was found in the database, or null otherwise.</returns>
public static Departamento GetItem(int id)
{
Departamento myDepartamento = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("DepartamentoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myDepartamento = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myDepartamento;
}
}

/// <summary>
/// Returns a list with Departamento objects.
/// </summary>
/// <returns>A generics List with the Departamento objects.</returns>
public static DepartamentoList GetList()
{
DepartamentoList tempList = new DepartamentoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("DepartamentoSelectList", myConnection))
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
/// Saves a Departamento in the database.
/// </summary>
/// <param name="myDepartamento">The Departamento instance to save.</param>
/// <returns>The new Id if the Departamento is new in the database or the existing Id when an item was updated.</returns>
public static int Save(Departamento myDepartamento)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("DepartamentoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myDepartamento.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myDepartamento.Id);
}
if (myDepartamento.IdCorte == -1)
{
    myCommand.Parameters.AddWithValue("@idCorte", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idCorte", myDepartamento.IdCorte);
}
if (string.IsNullOrEmpty(myDepartamento.departamento))
{
myCommand.Parameters.AddWithValue("@departamento", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@departamento", myDepartamento.departamento);
}
if (string.IsNullOrEmpty(myDepartamento.DescripcionCorta))
{
myCommand.Parameters.AddWithValue("@descripcionCorta", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcionCorta", myDepartamento.DescripcionCorta);
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
/// Deletes a Departamento from the database.
/// </summary>
/// <param name="id">The Id of the Departamento to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("DepartamentoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the Departamento class and fills it with the data fom the IDataRecord.
/// </summary>
private static Departamento FillDataRecord(IDataRecord myDataRecord )
{
Departamento myDepartamento = new Departamento();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myDepartamento.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdCorte")))
{
    myDepartamento.IdCorte = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdCorte"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Departamento")))
{
myDepartamento.departamento = myDataRecord.GetString(myDataRecord.GetOrdinal("Departamento"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DescripcionCorta")))
{
myDepartamento.DescripcionCorta = myDataRecord.GetString(myDataRecord.GetOrdinal("DescripcionCorta"));
}
return myDepartamento;
}
}

 } 
