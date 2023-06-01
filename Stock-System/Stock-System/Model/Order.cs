using System.ComponentModel.DataAnnotations;

namespace Stock_System.Model
{
    public class Order
    {
        public int orderId { get; set; }
        public int stockID { get; set; }

        [Required]
        public string person { get; set; }

        [Required]
        public string stockName { get; set; }

        [Required]
        public int quantity { get; set; }

        public int price { get; set; }
    }
}