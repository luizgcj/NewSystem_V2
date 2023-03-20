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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(NewSystemDbContext context) : base(context) { }
       
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
           return await Db.Fornecedores.AsNoTracking()
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(f => f.Id== id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(e => e.Endereco)
                .Include(e => e.Produtos)   
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
