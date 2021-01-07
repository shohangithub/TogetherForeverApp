using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TogetherForeverApp.Data;
using TogetherForeverApp.ViewModels.Members;
using TogetherForeverApp.Views;

namespace TogetherForeverApp
{
    public static class Locator
    {
        private static IServiceProvider serviceProvider;
        public static void Initialize()
        {
            var services = new ServiceCollection();
           // services.AddSingleton<IDatabase,MemberRepository>();
            services.AddTransient<NewMemberViewModel>();
            services.AddTransient<MemberViewModel>();
            services.AddTransient<NewMemberPage>();
            services.AddTransient<MemberPage>();
            serviceProvider = services.BuildServiceProvider();
        }
        public static T Resolved<T>() => serviceProvider.GetService<T>();
    }
}
