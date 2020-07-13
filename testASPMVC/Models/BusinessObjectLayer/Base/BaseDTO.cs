using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using testASPMVC.Interfaces;

namespace testASPMVC.Models.BusinessObjectLayer.Base
{
    public class BaseDTO : IBaseDTO
    {
        [DisplayName("Идентификатор")]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
    }
}