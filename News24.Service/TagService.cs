using News24.Data.Infrastructure;
using News24.Data.Repositories;
using News24.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News24.Service
{
    public interface ITagService
    {
        void AddTags(List<Tag> tags);

        void Update(Tag tag);

        void Delete(Tag tag);

        List<Tag> GetTags(int articleId);
         
        Tag GetTag(int id);
    }
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        private readonly IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddTags(List<Tag> tags)
        {
            foreach (var item in tags)
            {
                _tagRepository.Add(item);
            }
            _unitOfWork.Commit();
        }

        public void Delete(Tag tag)
        {
            _tagRepository.Delete(tag);
            _unitOfWork.Commit();
        }

        public void Update(Tag tag)
        {
            _tagRepository.Update(tag);
            _unitOfWork.Commit();
        }

        public List<Tag> GetTags(int articleId) => _tagRepository.GetAll().Where(x=>x.ArticleId == articleId).ToList();

        public Tag GetTag(int id) => _tagRepository.GetById(id);
    }
}
