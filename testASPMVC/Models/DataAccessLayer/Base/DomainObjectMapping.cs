using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testASPMVC.Models.DataAccessLayer.Base
{
    public class DomainObjectMapping<T> : ClassMap<T> where T : DomainObject
    {
        public DomainObjectMapping()
        {
            Id(i => i.ID).Column("id").GeneratedBy.Assigned();
        }
    }
}