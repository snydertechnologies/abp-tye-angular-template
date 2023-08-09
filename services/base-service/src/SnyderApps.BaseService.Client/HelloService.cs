using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;

namespace SnyderApps.BaseService.Client
{
	[DependsOn(
		typeof(AbpAspNetCoreMvcModule),
		typeof(AbpAutofacModule)
	)]
	public class MinimalModule : AbpModule
	{
	}
	
	public class HelloService : ITransientDependency
	{
		public string SayHi()
		{
			return "Hi from service";
		}
	}
}
