using BF.Dependency;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF
{
    public class Bootstrapper
    {
        private Type _startupType;

        public IConfiguration _configuration { get; }

        private ILogger _logger;

        public IIocManager IocManager { get; }
        
        public Bootstrapper(Type startupType, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _startupType = startupType;
            _configuration = configuration;
            IocManager = BF.Dependency.IocManager.Instance;
            IocManager.IocContainer.Register(Component.For<IConfiguration>().Instance(configuration));
        }

        public static Bootstrapper Create(Type startupType, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            return new Bootstrapper(startupType, configuration);
        }
        public void Initialize() 
        {
            ResolveLogger();
            try
            {
                RegisterBootstrapper();
                IocManager.Register<TypeManager>(DependencyLifeStyle.Singleton);
                var typeManeger = IocManager.Resolve<TypeManager>();
                typeManeger.Initialize(_startupType);
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex.ToString(), ex);
                throw;
            }
        }

        private void RegisterBootstrapper()
        {
            if (!IocManager.IsRegistered<Bootstrapper>())
            {
                IocManager.IocContainer.Register(
                    Component.For<Bootstrapper>().Instance(this)
                    );
            }
        }

        private void ResolveLogger()
        {
            if (IocManager.IsRegistered<ILoggerFactory>())
            {
                _logger = IocManager.Resolve<ILoggerFactory>().Create(typeof(Bootstrapper));
            }
        }
    }
}
