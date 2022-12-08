using DLWMS.Core;
using DLWMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Servicee
{
    public interface IPredmetService : IBaseService<Predmet, int>
    {
        IEnumerable<Predmet> GetBySemestar(int semestar);
    }

    public class PredmetService : BaseService<Predmet, int>, IPredmetService
    {
        public PredmetService(IRepository<Predmet, int> repository) : base(repository)
        {

        }

        public IEnumerable<Predmet> GetBySemestar(int semestar)
        {
            return repository.GetAll();
        }
    }
}
