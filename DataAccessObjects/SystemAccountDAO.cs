using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessObjects
{
    public class SystemAccountDAO(IUnitOfWork unitOfWork)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public SystemAccount? Login(string username, string password)
        {
            var account = _unitOfWork.SystemAccountRepository.FindEnityByConditionn(x => x.AccountEmail.Equals(username));
            if (account.AccountPassword.Equals(password))
            {
                return account;
            }
            return null;
        }
    }
}
