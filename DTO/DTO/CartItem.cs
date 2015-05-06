namespace DTO.DTO
{
    public class CartItem
    {
        public int id { get; set; }

        public int? chartid { get; set; }

        public int? qty { get; set; }

        public int? productId { get; set; }

        public Cart Cart { get; set; }
    }
}