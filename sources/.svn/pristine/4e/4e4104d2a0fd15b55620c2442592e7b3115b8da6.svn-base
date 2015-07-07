using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The ComisariaDB class is responsible for interacting with the database to retrieve and store information
/// about Comisaria objects.
/// </summary>
public partial class ComisariaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of Comisaria from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the Comisaria in the database.</param>
/// <returns>An Comisaria when the id was found in the database, or null otherwise.</returns>
public static Comisaria GetItem(int id)
{
Comisaria myComisaria = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ComisariaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myComisaria = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myComisaria;
}
}

/// <summary>
/// Gets an instance of Comisaria from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the Comisaria in the database.</param>
/// <returns>An Comisaria when the id was found in the database, or null otherwise.</returns>
public static Comisaria GetItemByDescripcion(string descComisaria)
{
    Comisaria myComisaria = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("ComisariaSelectSingleItemByDescripcion", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@comisaria", descComisaria);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myComisaria = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myComisaria;
    }
}

/// <summary>
/// Returns a list with Comisaria objects.
/// </summary>
/// <returns>A generics List with the Comisaria objects.</returns>
public static ComisariaList GetList()
{
ComisariaList tempList = new ComisariaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ComisariaSelectList", myConnection))
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
/// Returns a list with Comisaria objects.
/// </summary>
/// <returns>A generics List with the Comisaria objects.</returns>
public static ComisariaList GetListByidDepartamento(int idDepartamento)
{
ComisariaList tempList = new ComisariaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ComisariaSelectListByidDepartamento", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idDepartamento", idDepartamento);
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
return tempList;
}
}

/// <summary>
/// Saves a Comisaria in the database.
/// </summary>
/// <param name="myComisaria">The Comisaria instance to save.</param>
/// <returns>The new id if the Comisaria is new in the database or the existing id when an item was updated.</returns>
public static int Save(Comisaria myComisaria)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ComisariaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myComisaria.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myComisaria.id);
}
if (string.IsNullOrEmpty(myComisaria.comisaria))
{
myCommand.Parameters.AddWithValue("@comisaria", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@comisaria", myComisaria.comisaria);
}

    myCommand.Parameters.AddWithValue("@idDepartamento", myComisaria.idDepartamento);


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
/// Deletes a Comisaria from the database.
/// </summary>
/// <param name="id">The id of the Comisaria to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ComisariaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the Comisaria class and fills it with the data fom the IDataRecord.
/// </summary>
private static Comisaria FillDataRecord(IDataRecord myDataRecord )
{
Comisaria myComisaria = new Comisaria();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myComisaria.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Comisaria")))
{
myComisaria.comisaria = myDataRecord.GetString(myDataRecord.GetOrdinal("Comisaria"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDepartamento")))
{
myComisaria.idDepartamento = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDepartamento"));
}
return myComisaria;
}
}

 } 
