using BlazorPizzaDemoApp.Model;

namespace BlazorPizzaDemoApp.Services;
/// <summary>
/// Defining Service to add AppState parameters sharing mechanism thru whole app..
/// </summary>
public class OrderStateService(ILogger<OrderStateService> logger)
{
    private readonly ILogger<OrderStateService> logger = logger;

    public bool ShowingConfigureDialog { get; private set; }
    public Pizza ConfiguringPizza { get; private set; }
    public Order Order { get; private set; } = new Order();



    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = [],
        };

        ShowingConfigureDialog = true;
    }

    public void CancelConfigurePizzaDialog(string msg)
    {
        ConfiguringPizza = null;

        ShowingConfigureDialog = false;
        // Handle the click event here
        logger.LogInformation(msg);  // Outputs: Button clicked
    }

    public void ConfirmConfigurePizzaDialog()
    {
        Order.Pizzas.Add(ConfiguringPizza);
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }

    public void ResetOrder()
    {
        Order = new();
    }
}
