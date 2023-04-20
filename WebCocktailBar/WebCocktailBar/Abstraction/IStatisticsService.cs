namespace WebCocktailBar.Abstraction
{
    public interface IStatisticsService
    {
        int CountProducts();

        int CountClients();

        int CountOrders();

        decimal SumOrders();

    }
}
