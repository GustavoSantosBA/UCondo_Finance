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
    public class FinanceiroRepository : IBaseRepository
    {
        public void DeleteItemById(int id)
        {
            using (SqlConnection connection = new UCondo_Finance_Context().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"UPDATE Financeiro Set 
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
            var objInsert = Entity as Financeiro;
            using (SqlConnection connection = new UCondo_Finance_Context().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"INSERT INTO Financeiro (PessoaId, DataVencimento, ValorLancamento,Descricao,Periodicidade,StsLancamento,TipoLancamento,Deleted,RefCode) 
                       OUTPUT INSERTED.Id
                       VALUES (
                                '{objInsert.PessoaId}', 
                                '{objInsert.DataVencimento.ToString("yyyy-MM-dd")}', 
                                 {objInsert.ValorLancamento}, 
                                '{objInsert.Descricao}',        
                                '{objInsert.Periodicidade}', 
                                '{objInsert.StsLancamento}', 
                                '{objInsert.TipoLancamento}',
                                '0',
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
            var financeiroList = new List<Financeiro>();
            using (SqlConnection connection = new UCondo_Finance_Context().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"Select 
                            A.Id,
                            A.PessoaId,
                            A.DataVencimento,
                            A.ValorLancamento,
                            A.Descricao,
                            A.Periodicidade,
                            A.StsLancamento,
                            A.TipoLancamento,
                            B.NomePessoa,
                            B.TipoPessoa
                          From Financeiro A INNER JOIN PESSOA B on A.PessoaId = B.Id
                          Where A.Deleted = 0",
                        connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        financeiroList.Add(new Financeiro
                        {
                            Id = (int)reader["Id"],
                            PessoaId = (int)reader["PessoaId"],
                            DataVencimento = (DateTime)reader["DataVencimento"],
                            ValorLancamento = (decimal)reader["ValorLancamento"],
                            Descricao = (string)reader["Descricao"],
                            Periodicidade = (PeriodicidadeEnum)reader["Periodicidade"],
                            StsLancamento = (StatusEnum)reader["StsLancamento"],
                            TipoLancamento = (TipoLancamentoEnum)reader["TipoLancamento"],
                            Pessoa = new Pessoa()
                            {
                                Id = (int)reader["PessoaId"],
                                NomePessoa = (string)reader["NomePessoa"]
                            }
                        });
                    }
                    reader.Close();
                    connection.Dispose();

                    return financeiroList as IEnumerable<T>;
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
            var financeiro = new Financeiro();
            using (SqlConnection connection = new UCondo_Finance_Context().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"Select 
                            A.Id,
                            A.PessoaId,
                            A.DataVencimento,
                            A.ValorLancamento,
                            A.Descricao,
                            A.Periodicidade,
                            A.StsLancamento,
                            A.TipoLancamento,
                            B.NomePessoa,
                            B.TipoPessoa
                          From Financeiro A INNER JOIN PESSOA B on A.PessoaId = B.Id
                          Where A.Deleted = 0",
                        connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        financeiro.Id = (int)reader["Id"];
                        financeiro.PessoaId = (int)reader["PessoaId"];
                        financeiro.DataVencimento = (DateTime)reader["DataVencimento"];
                        financeiro.ValorLancamento = (decimal)reader["ValorLancamento"];
                        financeiro.Descricao = (string)reader["Descricao"];
                        financeiro.Periodicidade = (PeriodicidadeEnum)reader["Periodicidade"];
                        financeiro.StsLancamento = (StatusEnum)reader["StsLancamento"];
                        financeiro.TipoLancamento = (TipoLancamentoEnum)reader["TipoLancamento"];
                        financeiro.RefCode = (string)reader["RefCode"];
                        financeiro.Pessoa = new Pessoa()
                        {
                            Id = (int)reader["PessoaId"],
                            NomePessoa = (string)reader["NomePessoa"]
                        };
                    }
                    reader.Close();
                    connection.Dispose();
                    return financeiro as T;
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
            var objUpdate = Entity as Financeiro;
            using (SqlConnection connection = new UCondo_Finance_Context().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"UPDATE Usuarios Set 
                                  PessoaId  = '{objUpdate.PessoaId}', 
                                  DataVencimento = '{objUpdate.DataVencimento.ToString("yyyy-MM-dd")}', 
                                  ValorLancamento = '{objUpdate.ValorLancamento}',
                                  Descricao = '{objUpdate.Descricao}',
                                  Periodicidade = '{objUpdate.Periodicidade}',
                                  StsLancamento = '{objUpdate.StsLancamento}',
                                  Periodicidade = '{objUpdate.Periodicidade}',
                                  TipoLancamento = '{objUpdate.TipoLancamento}'
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
