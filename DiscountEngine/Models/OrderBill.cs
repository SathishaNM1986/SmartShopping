namespace DiscountEngine.Models
{
    public class OrderBill
    {
        public decimal OriginalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public bool PromoEligible { get; set; }
        public bool PromoApplied { get; set; }
    }
}
