using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testASPMVC.Interfaces
{
    public interface IDomainObject
    {
        Guid ID { get; set; }
    }
}
