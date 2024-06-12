using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        INewsArticleRepository NewsArticleRepository { get; }
        INewsTagRepository NewsTagRepository { get; }
        ISystemAccountRepository SystemAccountRepository { get; }
        ITagRepository TagRepository { get; }
        void SaveChanges();
    }
}
