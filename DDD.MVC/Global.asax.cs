
using DDD.Application;
using DDD.Application.Base;
using DDD.Application.Interfaces;
using DDD.Application.Interfaces.Base;
using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Repositories.Base;
using DDD.Domain.Interfaces.Services;
using DDD.Domain.Interfaces.Services.Base;
using DDD.Domain.Services;
using DDD.Domain.Services.Base;
using DDD.Infra.Data.Repositories;
using DDD.Infra.Data.Repositories.Base;
using DDD.MVC.AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DDD.MVC
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			var container = new Container();
			container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>), Lifestyle.Transient);
			container.Register<IClientAppService, ClientAppService>(Lifestyle.Transient);
			container.Register<IPhoneAppService, PhoneAppService>(Lifestyle.Transient);

			container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Transient);
			container.Register<IClientService, ClientService>(Lifestyle.Transient);
			container.Register<IPhoneService, PhoneService>(Lifestyle.Transient);

			container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Transient);
			container.Register<IClientRepository, ClientRepository>(Lifestyle.Transient);
			container.Register<IPhoneRepository, PhoneRepository>(Lifestyle.Transient);

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AutoMapperConfig.RegisterMappings();
		}
	}
}
