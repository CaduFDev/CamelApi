using AutoMapper;
using CamelDev.CamelApi.Api.DTO;
using CamelDev.CamelApi.Domain_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace CamelDev.CamelApi.Api.AutoMapper
{
    public class AutoMapperManager
    {

        private static readonly Lazy<AutoMapperManager> _instance
        = new Lazy<AutoMapperManager>(() =>
        {
            return new AutoMapperManager();
        });

        public static AutoMapperManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private MapperConfiguration _config;
        
        public IMapper Mapper
        {
            get
            {
                return _config.CreateMapper();
            }
        }
        
        private AutoMapperManager()
        {
            _config = new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<Aluno, AlunoDTO>();
                cfg.CreateMap<AlunoDTO, Aluno>();
            });
        }
    }
}