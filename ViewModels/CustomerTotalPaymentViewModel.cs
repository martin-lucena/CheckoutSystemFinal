using CheckoutSystem.Models;

namespace CheckoutSystem.ViewModels
{
    public class CustomerTotalPaymentViewModel
    {
        public Customer? Customer { get; set; }
        public decimal TotalPayment { get; set; }
    }
}
