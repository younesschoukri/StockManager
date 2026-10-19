using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;
using StockManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StockManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Register StockManagerDbContext

            services.AddDbContext<StockManagerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #endregion

            #region Register Repositories

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerInformationRepository, CustomerInformationRepository>();
            services.AddScoped<ICustomerBankCheckRepository, CustomerBankCheckRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductDefinitionRepository, ProductDefinitionRepository>();
            services.AddScoped<IProductSpecificationRepository, ProductSpecificationRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();

            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierInformationRepository, SupplierInformationRepository>();
            services.AddScoped<ISupplyRepository, SupplyRepository>();

            services.AddScoped<ICompanyBankCheckRepository, CompanyBankCheckRepository>();
            services.AddScoped<IDepositRepository, DepositRepository>();

            #endregion

            #region Register UnitOfWork

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            return services;
        }
    }
}