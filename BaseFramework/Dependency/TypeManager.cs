using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BF.Dependency
{
    public class TypeManager
    {
        private readonly IIocManager _iocManager;

        public TypeManager(IIocManager iocManager) {
            _iocManager = iocManager;
        }
        public void Initialize(Type startupType) {
            var assemblies = LoadAssemblies(startupType.Assembly);
            foreach (var assembly in assemblies)
            {
                RegisterAssembly(assembly);
            }
        }

        private void RegisterAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes();

            _iocManager.IocContainer.Register(
                Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ITransientDependency>()
                    .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                );

            _iocManager.IocContainer.Register(
                Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ISingletonDependency>()
                    .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleSingleton()
                );

            _iocManager.IocContainer.Register(
                Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<IScopedDependency>()
                    .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleScoped()
                );

            //Windsor Interceptors
            _iocManager.IocContainer.Register(
                Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<IInterceptor>()
                    .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                    .WithService.Self()
                    .LifestyleTransient()
                );
        }

        private IEnumerable<Assembly> LoadAssemblies(Assembly assembly)
        {
            var file = new FileInfo(assembly.Location);
            var files=file.Directory.GetFiles("*.dll").Select(x=>x.FullName);
            return files.Select(MapAssembly).Where(x=>x!=null);
        }

        private Assembly MapAssembly(string filename)
        {
            try
            {
                var assembly = Assembly.LoadFrom(filename);
                return assembly;
            }
            catch 
            {
                return null;
            }
        }
    }
}
