using AdminPanelService.Data.Context;
using AdminPanelService.Service.Interfaces;
using AdminPanelService.Service.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminPanelService.Service
{
	public static class ServiceExtension
	{
		public static void AddService(this IServiceCollection services)
		{
            services.AddTransient<IReceptionService, ReceptionService>();
			services.AddTransient<IEmailService, EmailService>();
		}
	}
}
