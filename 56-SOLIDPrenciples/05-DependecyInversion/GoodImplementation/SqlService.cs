using _56_SOLIDPrenciples._05_DependecyInversion.BadImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_SOLIDPrenciples._05_DependecyInversion.GoodImplementation
{
    internal class SqlService
    {
        private IRepository _repository;

        public SqlService(IRepository repository)
        {
            _repository = repository;
        }
        public void Save()
        {
            _repository.Save();
        }
    }
}
