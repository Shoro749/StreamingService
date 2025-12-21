using StreamingService.Models;

namespace StreamingService.Data.Seeders.ModelSeeders
{
    public static class PaymentSeeder
    {
        public static async Task<List<Payment>?> SeedAsync(AppDbContext context)
        {
            if (context.Payments.Any())
                return null;

            var payments = new List<Payment>
            {
                new Payment
                {
                    
                    Amount = 9.99m,
                    Currency = "USD",
                    Provider = "LiqPay",
                    Method = "Card",
                    TransactionId = "TXN001",
                    Status = "Completed",
                    CreatedAt = DateTime.UtcNow.AddDays(-10)
                },
                new Payment
                {
                   
                    Amount = 19.99m,
                    Currency = "USD",
                    Provider = "Fondy",
                    Method = "GooglePay",
                    TransactionId = "TXN002",
                    Status = "Completed",
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                   
                    
                },
                new Payment
                {
                   
                    Amount = 29.99m,
                    Currency = "USD",
                    Provider = "LiqPay",
                    Method = "ApplePay",
                    TransactionId = "TXN003",
                    Status = "Pending",
                    CreatedAt = DateTime.UtcNow
                }
            };


            await context.Payments.AddRangeAsync(payments);
            await context.SaveChangesAsync();

            return payments;
        }
    }
}