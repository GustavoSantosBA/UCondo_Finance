using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCondo_Finance_Domain.Enums;

namespace UCondo_Finance_Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public string NomePessoa { get; set; }
        public TipoPessoaEnum TipoPessoa { get; set; }
    }
}
