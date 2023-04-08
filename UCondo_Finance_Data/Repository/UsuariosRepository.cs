using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCondo_Finance_Data.Context;
using UCondo_Finance_Data.Interface;
using UCondo_Finance_Domain.Entities;

namespace UCondo_Finance_Data.Repository
{
    public class UsuariosRepository : IBaseRepository
    {
        public void DeleteItemById(int id)
        {
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"UPDATE Usuarios Set 
                                  Deleted = 1,  
                                  DeletedDate = GetDate()
                           Where Id = {id}
                         ",
                        connection);
                    command.ExecuteNonQuery();
                    connection.Dispose();
                }
                catch (Exception)
                {
                    connection.Dispose();
                }
            }
        }

        public T InsertItem<T>(T Entity) where T : class
        {
            var objInsert = Entity as Usuarios;
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"INSERT INTO Usuarios (NomeUsuario, EmailUsuario, SenhaUsuario, Deleted, RefCode) 
                       OUTPUT INSERTED.Id
                       VALUES (
                                '{objInsert.NomeUsuario}', 
                                '{objInsert.EmailUsuario}', 
                                '{objInsert.SenhaUsuario}',
                                0,
                                '{Guid.NewGuid()}'
                              )",
                        connection);
                    int newId = (int)command.ExecuteScalar();
                    objInsert.Id = newId;
                    connection.Dispose();
                }
                catch (Exception)
                {
                    connection.Dispose();
                }

                var objInserted = objInsert as T;
                return objInserted;
            }
        }

        public IEnumerable<T> ListItem<T>() where T : class
        {
            var usuariosList = new List<Usuarios>();
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"Select 
                            Id,
                            NomeUsuario, 
                            EmailUsuario, 
                            SenhaUsuario,
                            RefCode 
                          From Usuarios
                          Where Deleted = 0", connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        usuariosList.Add(new Usuarios
                        {
                            Id = (int)reader["Id"],
                            NomeUsuario = (string)reader["NomeUsuario"],
                            EmailUsuario = (string)reader["EmailUsuario"],
                            SenhaUsuario = (string)reader["SenhaUsuario"],
                            RefCode = (string)reader["RefCode"]
                        });
                    }
                    reader.Close();
                    connection.Dispose();

                    return usuariosList as IEnumerable<T>;
                }
                catch (Exception)
                {
                    connection.Dispose();
                    return null;
                }
            }
        }

        public T ListItemById<T>(int id) where T : class
        {
            var usuario = new Usuarios();
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"Select 
                            Id,
                            NomeUsuario, 
                            EmailUsuario, 
                            SenhaUsuario,
                            RefCode 
                          From Usuarios
                          Where Deleted = 0 and Id = {id}",
                        connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        usuario.Id = (int)reader["Id"];
                        usuario.NomeUsuario = (string)reader["NomeUsuario"];
                        usuario.EmailUsuario = (string)reader["EmailUsuario"];
                        usuario.SenhaUsuario = (string)reader["SenhaUsuario"];
                        usuario.RefCode = (string)reader["RefCode"];
                    }
                    reader.Close();
                    connection.Dispose();
                    return usuario as T;
                }
                catch (Exception)
                {
                    connection.Dispose();
                    return null;
                }
            }
        }

        public void UpdateItem<T>(T Entity) where T : class
        {
            var objUpdate = Entity as Usuarios;
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"UPDATE Usuarios Set 
                                  NomeUsuario  = '{objUpdate.NomeUsuario}', 
                                  EmailUsuario = '{objUpdate.EmailUsuario}', 
                                  SenhaUsuario = '{objUpdate.SenhaUsuario}',
                           Where Id = {objUpdate.Id}
                         ",
                        connection);
                    command.ExecuteNonQuery();
                    connection.Dispose();
                }
                catch (Exception)
                {
                    connection.Dispose();
                }
            }
        }
    }
}
