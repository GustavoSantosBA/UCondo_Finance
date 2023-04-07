using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCondo_Finance_Domain.Enums;

namespace UCondo_Finance_Domain.Entities
{
    public class Financeiro : BaseEntity
    {
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorLancamento { get; set; }
        public string Descricao { get; set; }
        public PeriodicidadeEnum Periodicidade { get; set; }
        public StatusEnum StsLancamento { get; set; }
    }
}
