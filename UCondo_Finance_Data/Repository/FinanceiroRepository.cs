using CrossCutting_Extensions;
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
        private decimal GetVlrLancamento(TipoLancamentoEnum tipoLancamento, decimal vlrLancamento)
        {
            if ((tipoLancamento == TipoLancamentoEnum.Saida && vlrLancamento > 0) || (tipoLancamento == TipoLancamentoEnum.Entrada && vlrLancamento < 0))
            {
                return (vlrLancamento * -1);
            }
            else
            {
                return vlrLancamento;
            }
        }
        public void DeleteItemById(int id)
        {
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"UPDATE Financeiro Set 
                                  Deleted = 1,  
                                  DeletedDate = GetDate()
                           Where Id = {id}",
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
            //
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"INSERT INTO Financeiro (DataVencimento, ValorLancamento,Descricao,Periodicidade,StsLancamento,TipoLancamento,Deleted,RefCode) 
                       OUTPUT INSERTED.Id
                       VALUES (
                                '{objInsert.DataVencimento.ToString("yyyy-MM-dd")}', 
                                 {GetVlrLancamento(objInsert.TipoLancamento, objInsert.ValorLancamento)}, 
                                '{objInsert.Descricao}',        
                                {objInsert.Periodicidade.EnumToInt()}, 
                                {objInsert.StsLancamento.EnumToInt()}, 
                                {objInsert.TipoLancamento.EnumToInt()},
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
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"Select 
                            Id,
                            DataVencimento,
                            ValorLancamento,
                            Descricao,
                            Periodicidade,
                            StsLancamento,
                            TipoLancamento
                          From Financeiro Where Deleted = 0",
                        connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        financeiroList.Add(new Financeiro
                        {
                            Id = (int)reader["Id"],
                            DataVencimento = (DateTime)reader["DataVencimento"],
                            ValorLancamento = (decimal)reader["ValorLancamento"],
                            Descricao = (string)reader["Descricao"],
                            Periodicidade = Extensions.ParseEnum<PeriodicidadeEnum>((int)reader["Periodicidade"]),
                            StsLancamento = Extensions.ParseEnum<StatusEnum>((int)reader["StsLancamento"]),
                            TipoLancamento = Extensions.ParseEnum<TipoLancamentoEnum>((int)reader["TipoLancamento"])
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
        }public IEnumerable<T> ListItemByPeriodo<T>(DateTime fromDate, DateTime toDate) where T : class
        {
            var financeiroList = new List<Financeiro>();
            var where = new List<string>();
            if (fromDate != DateTime.MinValue) { where.Add($"DataVencimento >= '{fromDate.ToString("yyyy-MM-dd")}'"); }
            if (toDate != DateTime.MinValue) { where.Add($"DataVencimento <= '{toDate.ToString("yyyy-MM-dd")}'"); }
            string whereQryStr = (where.Count() > 0) ? " and " + String.Join(" and ", where.ToArray()) : "";
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"Select 
                            Id,
                            DataVencimento,
                            ValorLancamento,
                            Descricao,
                            Periodicidade,
                            StsLancamento,
                            TipoLancamento
                          From Financeiro Where Deleted = 0
                          {whereQryStr}",
                        connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        financeiroList.Add(new Financeiro
                        {
                            Id = (int)reader["Id"],
                            DataVencimento = (DateTime)reader["DataVencimento"],
                            ValorLancamento = (decimal)reader["ValorLancamento"],
                            Descricao = (string)reader["Descricao"],
                            Periodicidade = Extensions.ParseEnum<PeriodicidadeEnum>((int)reader["Periodicidade"]),
                            StsLancamento = Extensions.ParseEnum<StatusEnum>((int)reader["StsLancamento"]),
                            TipoLancamento = Extensions.ParseEnum<TipoLancamentoEnum>((int)reader["TipoLancamento"])
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
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"Select 
                            Id,
                            DataVencimento,
                            ValorLancamento,
                            Descricao,
                            Periodicidade,
                            StsLancamento,
                            TipoLancamento,
                            RefCode
                          From Financeiro Where Deleted = 0 And Id = {id}",
                        connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        financeiro.Id = (int)reader["Id"];
                        financeiro.DataVencimento = (DateTime)reader["DataVencimento"];
                        financeiro.ValorLancamento = (decimal)reader["ValorLancamento"];
                        financeiro.Descricao = (string)reader["Descricao"];
                        financeiro.Periodicidade = Extensions.ParseEnum<PeriodicidadeEnum>((int)reader["Periodicidade"]);
                        financeiro.StsLancamento = Extensions.ParseEnum<StatusEnum>((int)reader["StsLancamento"]);
                        financeiro.TipoLancamento = Extensions.ParseEnum<TipoLancamentoEnum>((int)reader["TipoLancamento"]);
                        financeiro.RefCode = (string)reader["RefCode"];
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
            using (SqlConnection connection = new UCondoFinanceContext().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        $@"UPDATE Financeiro Set 
                                  DataVencimento = '{objUpdate.DataVencimento.ToString("yyyy-MM-dd")}', 
                                  ValorLancamento = {GetVlrLancamento(objUpdate.TipoLancamento, objUpdate.ValorLancamento)},
                                  Descricao = '{objUpdate.Descricao}',
                                  Periodicidade = {objUpdate.Periodicidade.EnumToInt()},
                                  StsLancamento = {objUpdate.StsLancamento.EnumToInt()},
                                  TipoLancamento = {objUpdate.TipoLancamento.EnumToInt()}
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
