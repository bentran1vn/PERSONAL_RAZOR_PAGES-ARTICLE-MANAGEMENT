using BusinessObjects;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class SystemAccountRepository(FunewsManagementDbContext context) : BaseRepository<SystemAccount>(context), ISystemAccountRepository
    {
    }
}
