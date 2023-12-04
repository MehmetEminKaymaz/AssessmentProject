using AssessmentProject.Application.Invoice.Handler;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.User.Handler;
using AssessmentProject.Data;
using Microsoft.EntityFrameworkCore;

namespace AssessmentProject.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DbContext, DataContext>();

            builder.Services.AddScoped(typeof(CreateInvoiceCommandHandler), typeof(CreateInvoiceCommandHandler));
            builder.Services.AddScoped(typeof(UpdateInvoiceCommandHandler), typeof(UpdateInvoiceCommandHandler));
            builder.Services.AddScoped(typeof(DeleteInvoiceCommandHandler), typeof(DeleteInvoiceCommandHandler));
            builder.Services.AddScoped(typeof(GetInvoiceQueryHandler), typeof(GetInvoiceQueryHandler));

            builder.Services.AddScoped(typeof(CreateUserCommandHandler), typeof(CreateUserCommandHandler));
            builder.Services.AddScoped(typeof(UpdateUserCommandHandler), typeof(UpdateUserCommandHandler));
            builder.Services.AddScoped(typeof(DeleteUserCommandHandler), typeof(DeleteUserCommandHandler));
            builder.Services.AddScoped(typeof(GetUserQueryHandler), typeof(GetUserQueryHandler));

            builder.Services.AddScoped(typeof(CreateStoreCommandHandler), typeof(CreateStoreCommandHandler));
            builder.Services.AddScoped(typeof(UpdateStoreCommandHandler), typeof(UpdateStoreCommandHandler));
            builder.Services.AddScoped(typeof(DeleteStoreCommandHandler), typeof(DeleteStoreCommandHandler));
            builder.Services.AddScoped(typeof(GetStoreQueryHandler), typeof(GetStoreQueryHandler));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
