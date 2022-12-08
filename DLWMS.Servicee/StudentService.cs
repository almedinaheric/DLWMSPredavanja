using DLWMS.Core;
using DLWMS.Repository;
using Microsoft.EntityFrameworkCore;

namespace DLWMS.Servicee
{
    public interface IBaseService<TEntity, TKey>
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
    }

    public interface IStudentService : IBaseService<Student, int>
    {
        IEnumerable<Student> GetByIndex(string index);
    }


    public class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey> where TEntity : class
    {
        protected readonly IRepository<TEntity, TKey> repository;
        public BaseService(IRepository<TEntity, TKey> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(TKey id)
        {
            return repository.GetById(id);
        }

        public void Save(TEntity entity)
        {
            repository.Save(entity);
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }
    }

    public class StudentService : BaseService<Student, int>, IStudentService
    {
        public StudentService(IRepository<Student, int> repository) :base(repository)
        {
           
        }

        public IEnumerable<Student> GetByIndex(string index)
        {
            return repository.GetAll().Where(x => x.BrojIndeksa == index);
        }
    }
}