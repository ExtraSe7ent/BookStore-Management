using System;

namespace BookStore.Entities
{
    public class RevenueReport
    {
        public DateTime Date { get; set; }     
        public decimal TotalRevenue { get; set; } 
        public int TransactionCount { get; set; }
    }
}