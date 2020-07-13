using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testASPMVC.Models.DataAccessLayer
{
    public class AutoMapperConfiguration
    {
        private static MapperConfiguration _config;
        public static MapperConfiguration Config
        {
            get
            {
                if (_config == null)
                {
                    _config = new MapperConfiguration(cfg =>
                    {
                        
                    });
                }
                return _config;
            }
        }
    }
}