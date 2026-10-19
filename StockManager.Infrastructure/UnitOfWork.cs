using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;
using StockManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockManager.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Fields

        private readonly StockManagerDbContext context;

        #endregion

        #region Public Properties

        public ICustomerRepository Customers { get; }

        public ICustomerBankCheckRepository CustomersBankChecks { get; }

        public ICustomerInformationRepository CustomersInformation { get; }

        public IOrderRepository Orders { get; }

        public IOrderDetailsRepository OrdersDetails { get; }

        public IDepositRepository Deposits { get; }

        public IProductRepository Products { get; }

        public IProductDefinitionRepository ProductsDefinitions { get; }

        public IProductSpecificationRepository ProductsSpecifications { get; }

        public ICategoryRepository Categories { get; }

        public ISubCategoryRepository SubCategories { get; }

        public ISupplierRepository Suppliers { get; }

        public ISupplierInformationRepository SuppliersInformation { get; }

        public ISupplyRepository Supplies { get; }

        public ICompanyBankCheckRepository CompaniesBankChecks { get; }

        #endregion

        #region Public Constructor

        public UnitOfWork(StockManagerDbContext context)
        {
            this.context = context;

            Customers = new CustomerRepository(context);
            CustomersInformation = new CustomerInformationRepository(context);
            CustomersBankChecks = new CustomerBankCheckRepository(context);

            Orders = new OrderRepository(context);
            OrdersDetails = new OrderDetailsRepository(context);

            Products = new ProductRepository(context);
            ProductsDefinitions = new ProductDefinitionRepository(context);
            ProductsSpecifications = new ProductSpecificationRepository(context);

            Categories = new CategoryRepository(context);
            SubCategories = new SubCategoryRepository(context);

            Suppliers = new SupplierRepository(context);
            SuppliersInformation = new SupplierInformationRepository(context);
            Supplies = new SupplyRepository(context);

            Deposits = new DepositRepository(context);
            CompaniesBankChecks = new CompanyBankCheckRepository(context);
        }

        #endregion

        #region Public Methods

        public int Commit() => context.SaveChanges();

        public void Dispose() => context.Dispose();

        #endregion
    }
}
