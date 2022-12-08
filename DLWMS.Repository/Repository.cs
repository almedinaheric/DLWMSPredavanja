using DLWMS.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Repository
{
    public interface IRepository<TEnitiy, TKey>
    {
        void Save(TEnitiy enitiy);
        void Update(TEnitiy enitiy);
        TEnitiy GetById(TKey key);
        IEnumerable<TEnitiy> GetAll();

    }

    public class Repository<TEnitiy, TKey> : IRepository<TEnitiy, TKey> where TEnitiy : class
    {
        private readonly DLWMSDbContext dbContext;
        private readonly DbSet<TEnitiy> dbSet;

        public Repository(DLWMSDbContext DBContext)
        {
            dbContext = DBContext;
            dbSet = dbContext.Set<TEnitiy>();
        }

        public IEnumerable<TEnitiy> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public TEnitiy GetById(TKey key)
        {
            return dbSet.Find(key);
        }

        public void Save(TEnitiy enitiy)
        {
            dbSet.Add(enitiy);
            dbContext.SaveChanges();
        }

        public void Update(TEnitiy enitiy)
        {
            dbSet.Update(enitiy);
            dbContext.SaveChanges();
        }
    }

    public interface IStudentRepository: IRepository<StudentRepository, int>
    {
        IEnumerable<Student> GetSpecific();
    }

    public class StudentRepository : Repository<Student, int>, IStudentRepository
    {
        public StudentRepository(DLWMSDbContext DBContext) : base(DBContext)
        {
        }

        public IEnumerable<Student> GetSpecific()
        {
            throw new NotImplementedException();
        }

        public void Save(StudentRepository enitiy)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentRepository enitiy)
        {
            throw new NotImplementedException();
        }

        IEnumerable<StudentRepository> IRepository<StudentRepository, int>.GetAll()
        {
            throw new NotImplementedException();
        }

        StudentRepository IRepository<StudentRepository, int>.GetById(int key)
        {
            throw new NotImplementedException();
        }
    }
}
