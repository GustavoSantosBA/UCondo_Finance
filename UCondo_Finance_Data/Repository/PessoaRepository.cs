using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCondo_Finance_Data.Context;
using UCondo_Finance_Data.Interface;
using UCondo_Finance_Domain.Entities;
using UCondo_Finance_Domain.Enums;

namespace UCondo_Finance_Data.Repository
{
    public class PessoaRepository : IBaseRepository
    {
        public void DeleteItemById(int id)
        {
            using (SqlConnection connection = new UCondo_Finance_Context().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"UPDATE Pessoa Set 
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
            var objInsert = Entity as Pessoa;
            using (SqlConnection connection = new UCondo_Finance_Context().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"INSERT INTO Pessoa (NomePessoa,TipoPessoa,RefCode) 
                       OUTPUT INSERTED.Id
                       VALUES (
                                '{objInsert.NomePessoa}', 
                                '{objInsert.TipoPessoa}', 
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
            var pessoaList = new List<Pessoa>();
            using (SqlConnection connection = new UCondo_Finance_Context().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"Select 
                            Id,
                            NomePessoa, 
                            TipoPessoa, 
                            RefCode 
                          From Pessoa
                          Where Deleted = 0", 
                        connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        pessoaList.Add(new Pessoa
                        {
                            Id = (int)reader["Id"],
                            NomePessoa = (string)reader["NomePessoa"],
                            TipoPessoa = (TipoPessoaEnum)reader["TipoPessoa"],
                            RefCode = (string)reader["RefCode"]
                        });
                    }
                    reader.Close();
                    connection.Dispose();

                    return pessoaList as IEnumerable<T>;
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
            var pessoa = new Pessoa();
            using (SqlConnection connection = new UCondo_Finance_Context().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"Select 
                            Id,
                            NomePessoa, 
                            TipoPessoa, 
                            RefCode 
                          From Pessoa
                          Where Deleted = 0 and Id = {id}",
                        connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        pessoa.Id = (int)reader["Id"];
                        pessoa.NomePessoa = (string)reader["NomePessoa"];
                        pessoa.TipoPessoa = (TipoPessoaEnum)reader["TipoPessoa"];
                        pessoa.RefCode = (string)reader["RefCode"];
                    }
                    reader.Close();
                    connection.Dispose();
                    return pessoa as T;
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
            var objUpdate = Entity as Pessoa;
            using (SqlConnection connection = new UCondo_Finance_Context().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"UPDATE Pessoa Set 
                                  NomePessoa  = '{objUpdate.NomePessoa}', 
                                  TipoPessoa = '{objUpdate.TipoPessoa}'
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
