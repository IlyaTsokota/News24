using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News24.Data.Infrastructure;
using News24.Data.Repositories;
using News24.Model;

namespace News24.Service
{
    public interface IArticleService
    {
        Article GetArticle(int id);

        List<Article> GetArticles();

        IEnumerable<ValidationResult> CanAddProduct(Article newArticle);

        void CreateArticle(Article article);

        void UpdateArticle(Article article);

        void DeleteArticle(Article article);

    }
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ValidationResult> CanAddProduct(Article newArticle)
        {
            Article article;
            if (newArticle.ArticleId == 0)
            {
                article = _articleRepository.Get(x => x.Head == newArticle.Head);
            }
            else
            {
                article = _articleRepository.Get(
                    x => x.Head == newArticle.Head && x.ArticleId != newArticle.ArticleId);
            }
            if (article != null)
            {
                yield return new ValidationResult("Статья с данным заголовком уже существует!!");
            }
        }

    
        public void CreateArticle(Article article)
        {
            _articleRepository.Add(article);
           _unitOfWork.Commit();
        }

     
        public void DeleteArticle(Article article)
        {
            _articleRepository.Delete(article);
            _unitOfWork.Commit();
        }

        public Article GetArticle(int id)
        {
            var article = _articleRepository.GetById(id);
            return article;
        }

        public List<Article> GetArticles() => _articleRepository.GetAll().ToList();

       

        public void UpdateArticle(Article article)
        {
            _articleRepository.Update(article);
            _unitOfWork.Commit();
        }
    }
}
