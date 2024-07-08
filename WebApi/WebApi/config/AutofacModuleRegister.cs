using Autofac;
using System.Reflection;

namespace WebApi.config
{
    public class AutofacModuleRegister : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
           Assembly interfaceAssembly = Assembly.Load("Interface");
       
           Assembly serviceAssembly = Assembly.Load("Service");

            builder.RegisterAssemblyTypes(interfaceAssembly, serviceAssembly).AsImplementedInterfaces();
           
         }
    }
}
