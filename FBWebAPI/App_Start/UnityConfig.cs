using FBWA.Controllers;
using FBWA.Core.Managers.RestAPI;
using FBWA.Core.Models.RestAPI.Interfaces;
using FBWA.Core.Services;
using FBWA.Core.Services.RestAPI;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace FBWA
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();


			container.RegisterType<IRestClientService, RestClientService>();
			container.RegisterType<IErrorResponseBuilder, ErrorResponseBuilder>();

			container.RegisterType<IRestRequestService, RestRequestService>(
				new InjectionConstructor(
					new ResolvedParameter<IRestClientService>(),
					new ResolvedParameter<IErrorResponseBuilder>()
				));

			container.RegisterType<IFacebookWSContract, FacebookWSManager>(
				new InjectionConstructor(new ResolvedParameter<IRestRequestService>())
				);

			container.RegisterType<IWebAPIDispatcher, WebAPIDispatcher>(
				new InjectionConstructor(new ResolvedParameter<IFacebookWSContract>())
				);

			container.RegisterType<FBController>(
				new InjectionConstructor(new ResolvedParameter<IWebAPIDispatcher>())
				);

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}