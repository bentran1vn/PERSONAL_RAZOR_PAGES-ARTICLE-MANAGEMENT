using BusinessObjects;
using Repository.Interface;
using System;

namespace Repository.Implement
{
    public class UnitOfWork(FunewsManagementDbContext context) : IUnitOfWork
    {
        private readonly FunewsManagementDbContext _context = context;

        private ICategoryRepository _categoryRepository = null!;
        private INewsArticleRepository _newArticleRepository = null!;
        private INewsTagRepository _newsTagRepository = null!;
        private ISystemAccountRepository _systemAccountRepository = null!;
        private ITagRepository _tagRepository = null!;

        private readonly object _categoryLock = new object();
        private readonly object _newsArticleLock = new object();
        private readonly object _newsTagLock = new object();
        private readonly object _systemAccountLock = new object();
        private readonly object _tagLock = new object();

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository is null)
                {
                    lock (_categoryLock)
                    {
                        if (_categoryRepository is null)
                        {
                            _categoryRepository = new CategoryRepository(_context);
                        }
                    }
                }
                return _categoryRepository;
            }
        }

        public INewsArticleRepository NewsArticleRepository
        {
            get
            {
                if (_newArticleRepository is null)
                {
                    lock (_newsArticleLock)
                    {
                        if (_newArticleRepository is null)
                        {
                            _newArticleRepository = new NewArticleRepository(_context);
                        }
                    }
                }
                return _newArticleRepository;
            }
        }

        public INewsTagRepository NewsTagRepository
        {
            get
            {
                if (_newsTagRepository is null)
                {
                    lock (_newsTagLock)
                    {
                        if (_newsTagRepository is null)
                        {
                            _newsTagRepository = new NewsTagRepository(_context);
                        }
                    }
                }
                return _newsTagRepository;
            }
        }

        public ISystemAccountRepository SystemAccountRepository
        {
            get
            {
                if (_systemAccountRepository is null)
                {
                    lock (_systemAccountLock)
                    {
                        if (_systemAccountRepository is null)
                        {
                            _systemAccountRepository = new SystemAccountRepository(_context);
                        }
                    }
                }
                return _systemAccountRepository;
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                if (_tagRepository is null)
                {
                    lock (_tagLock)
                    {
                        if (_tagRepository is null)
                        {
                            _tagRepository = new TagRepository(_context);
                        }
                    }
                }
                return _tagRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
