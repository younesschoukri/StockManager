namespace StockManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        ICustomerBankCheckRepository CustomersBankChecks { get; }
        ICustomerInformationRepository CustomersInformation { get; }
        IOrderRepository Orders { get; }
        IOrderDetailsRepository OrdersDetails { get; }
        IDepositRepository Deposits { get; }
        IProductRepository Products { get; }
        IProductDefinitionRepository ProductsDefinitions { get; }
        IProductSpecificationRepository ProductsSpecifications { get; }
        ICategoryRepository Categories { get; }
        ISubCategoryRepository SubCategories { get; }
        ISupplierRepository Suppliers { get; }
        ISupplierInformationRepository SuppliersInformation { get; }
        ISupplyRepository Supplies { get; }
        ICompanyBankCheckRepository CompaniesBankChecks { get; }

        int Commit();
    }
}