using NHibernate;

namespace CarService.Repository.Abstract
{
    public interface IUnitOfWork
    {
        //ISession Session { get; set; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}