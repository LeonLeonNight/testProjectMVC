using AutoMapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testASPMVC.Models.DataAccessLayer;

namespace testASPMVC.Services.Base
{
    public abstract class BaseService
    {
        
        protected readonly IMapper mapper;

        protected BaseService()
        {
            mapper = AutoMapperConfiguration.Config.CreateMapper();
        }
    }
}