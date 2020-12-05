using System;
using System.Collections.Generic;
using System.Text;

namespace WellsFargo.Libraries.ORM.Interfaces
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; }
        public string DatabaseName { get; }
        public string CollectionName { get; }
    }
}
