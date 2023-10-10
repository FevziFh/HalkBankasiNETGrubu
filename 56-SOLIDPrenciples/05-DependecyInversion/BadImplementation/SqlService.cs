using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_SOLIDPrenciples._05_DependecyInversion.BadImplementation
{
    internal class SqlService
    {
        //private SqlRepository _repository;
        private NoSqlRepository _noSqlRepository;
        public SqlService( NoSqlRepository noSqlRepository)
        {
            //_repository = repository;
            _noSqlRepository = noSqlRepository;
        }
        public void Save()
        {
            _noSqlRepository.Save();
        }
    }
}
