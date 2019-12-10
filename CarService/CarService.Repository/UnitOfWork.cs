using CarService.Repository.Abstract;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ISession Session { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}