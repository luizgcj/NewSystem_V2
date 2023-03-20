using Microsoft.EntityFrameworkCore;
using NewSystem.Business.Interfaces;
using NewSystem.Business.Models;
using NewSystem.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSystem.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(NewSystemDbContext context) : base(context) { }
        

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()               
                .FirstOrDefaultAsync(e => e.FornecedorId== fornecedorId);
        }
    }
}
