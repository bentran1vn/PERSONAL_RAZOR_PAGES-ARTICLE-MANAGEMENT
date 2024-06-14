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
        
        public IEnumerable<SystemAccount> GetAllSystemAccounts()
        {
            return _unitOfWork.SystemAccountRepository.GetAll();
        }

        public void Add(SystemAccount account)
        {
            _unitOfWork.SystemAccountRepository.Add(account);
            _unitOfWork.SaveChanges();
        }
        
        public void Update(SystemAccount account)
        {
            _unitOfWork.SystemAccountRepository.Update(account);
            _unitOfWork.SaveChanges();
        }
        
        public void Remove(SystemAccount account)
        {
            _unitOfWork.SystemAccountRepository.Remove(account);
            _unitOfWork.SaveChanges();
        }
        
        public SystemAccount? GetSystemAccountById(short id)
        {
            return _unitOfWork.SystemAccountRepository.FindEnityByConditionn(x => x.AccountId == id);
        }

        public int GetId()
        {
            return _unitOfWork.SystemAccountRepository.GetAll().Select(x => x.AccountId).Max() + 1;
        }
    }
}
