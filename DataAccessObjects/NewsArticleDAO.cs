using BusinessObjects;
using Repository.Interface;


namespace DataAccessObjects
{
    public class NewsArticleDao(IUnitOfWork unitOfWork)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        
        public IEnumerable<NewsArticle> GetAllNewsArticles()
        {
            return _unitOfWork.NewsArticleRepository.GetAllNewsArticlesIncludes();
        }

        public void Add(NewsArticle newsArticle)
        {
            _unitOfWork.NewsArticleRepository.Add(newsArticle);
            _unitOfWork.SaveChanges();
        }
        
        public void Update(NewsArticle newsArticle)
        {
            _unitOfWork.NewsArticleRepository.Update(newsArticle);
            _unitOfWork.SaveChanges();
        }
        
        public void Remove(NewsArticle newsArticle)
        {
            _unitOfWork.NewsArticleRepository.Remove(newsArticle);
            _unitOfWork.SaveChanges();
        }
        
        public NewsArticle? GetNewsArticleById(string id)
        {
            return _unitOfWork.NewsArticleRepository.GetNewsArticlesByIdIncludes(id);
        }

        // public int GetId()
        // {
        //     return _unitOfWork.SystemAccountRepository.GetAll().Select(x => x.AccountId).Max() + 1;
        // }
    }
}
