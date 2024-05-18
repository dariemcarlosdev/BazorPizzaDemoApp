namespace BlazingPizzaDemoApp.Model;

public class OrderWithStatus
{
    public readonly static TimeSpan PreparationDuration = TimeSpan.FromSeconds(5);
    public readonly static TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1); // Unrealistic, but more interesting to watch

    public Order Order { get; set; }

    public string StatusText { get; set; }

    public bool IsDelivered => StatusText == "Delivered";

    /// <summary>
    /// To simulate a real backend process, we fake status updates based on the amount of time since the order was placed
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public static OrderWithStatus FromOrder(Order order)
    {
   
        string statusText;
        var dispatchTime = order.CreatedTime.Add(PreparationDuration);

        if (DateTime.Now < dispatchTime)
        {
            statusText = "Preparing";
        }
        else if (DateTime.Now < dispatchTime + DeliveryDuration)
        {
            statusText = "Out for delivery";
        }
        else
        {
            statusText = "Delivered";
        }

        return new OrderWithStatus
        {
            Order = order,
            StatusText = statusText
        };
    }


}
