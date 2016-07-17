using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using FBWebAPI.Core.Models.RestAPI.Interfaces;
using FBWebAPI.Core.Services.RestAPI;
using FBWebAPI.Core.Settings.RestAPI;
using FBWebAPI.Core.Managers.RestAPI;
using FBWebAPI.Core.Services;
using FBWebAPI.Controllers;
using System.Web.Http;

namespace FBWebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            /*
            container.RegisterType<IRestClientSettings, RestClientSettings>();
            container.RegisterType<IRestClientFactory, RestClientFactory>(
                new InjectionConstructor(new ResolvedParameter<IRestClientSettings>())
                );
            container.RegisterType<IRestRequestFactory, RestRequestFactory>();
            container.RegisterType<IErrorResponseBuilder, ErrorResponseBuilder>();

            container.RegisterType<IRestRequestService, RestRequestService>(
                new InjectionConstructor(
                    new ResolvedParameter<IRestClientFactory>(),
                    new ResolvedParameter<IRestRequestFactory>(),
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

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            */

            container.RegisterInstance<IRestClientSettings>(new RestClientSettings())
                .RegisterType<IRestClientFactory, RestClientFactory>(
                new InjectionConstructor(new ResolvedParameter<IRestClientSettings>())
                )
                .RegisterType<IRestRequestFactory, RestRequestFactory>()
                .RegisterType<IErrorResponseBuilder, ErrorResponseBuilder>()
                .RegisterType<IRestRequestService, RestRequestService>(
                new InjectionConstructor(
                    new ResolvedParameter<IRestClientFactory>(),
                    new ResolvedParameter<IRestRequestFactory>(),
                    new ResolvedParameter<IErrorResponseBuilder>()
                ))
                .RegisterType<IFacebookWSContract, FacebookWSManager>(
                new InjectionConstructor(new ResolvedParameter<IRestRequestService>())
                )
                .RegisterType<IWebAPIDispatcher, WebAPIDispatcher>(
                new InjectionConstructor(new ResolvedParameter<IFacebookWSContract>())
                )
                .RegisterType<FBController>(
                new InjectionConstructor(new ResolvedParameter<IWebAPIDispatcher>())
                );
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}