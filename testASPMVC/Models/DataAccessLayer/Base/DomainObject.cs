using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testASPMVC.Interfaces;

namespace testASPMVC.Models.DataAccessLayer.Base
{
    public class DomainObject : IDomainObject
    {
        protected Guid _id;

        public virtual Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}