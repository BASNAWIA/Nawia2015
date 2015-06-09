using Common.Logging;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Services
{
    public abstract class BaseService
    {
        protected IUnitOfWork UnitOfWork { get; private set; }

        private ILog log = LogManager.GetCurrentClassLogger();

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Transaction(Action action)
        {
            try
            {
                UnitOfWork.BeginTransaction();
                action();
                UnitOfWork.SaveChanges();
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                log.Error("Blad wykonywania transakcji", ex);
                throw new Exception("Blad wykonywania transakcji", ex);
            }
        }
    }
}
