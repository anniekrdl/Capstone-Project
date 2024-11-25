namespace OnlineWebshop
{
    class OrderManager
    {
        private OrderDatabaseService _orderDatabaseService = new OrderDatabaseService();
        private OrderItemDatabaseService _orderItemDatabaseService = new OrderItemDatabaseService();

        public async Task<Order?> GetOrderById(int id)
        {
            return await _orderDatabaseService.GetOrdersByOrderId(id);

        }


        public async Task<int> GetOrCreateOrderId(int customerId)
        {
            List<int> foundOrders = await _orderDatabaseService.GetOrderIdByCustomerId(customerId);

            if (foundOrders.Any())
            {
                return foundOrders.First();
            }

            //new order      
            Order order = new Order(null, customerId, null, OrderStatus.AANGEMAAKT);
            await _orderDatabaseService.AddOrder(order);

            // find orderId
            foundOrders = await _orderDatabaseService.GetOrderIdByCustomerId(customerId);
            Console.WriteLine($"Orders found total: {foundOrders.Count}. Id: {foundOrders.First()}");

            return foundOrders.First();


        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderDatabaseService.GetOrders();
        }

        public async Task<bool> PlaceOrderFromShoppingCart(List<ShoppingCartItem> items, int? customerId)
        {

            try
            {
                if (customerId.HasValue)
                {
                    int orderId = await GetOrCreateOrderId(customerId.Value);

                    foreach (SelectedProductItem item in items)
                    {
                        OrderItem orderItem = new OrderItem(null, orderId, item.ProductId, item.NumberOfItems, item.Product);

                        await _orderItemDatabaseService.AddOrderItem(orderItem);


                    }

                    return true;

                }
                else
                {
                    Console.WriteLine("customerId is null.");
                    return false;
                }


            }
            catch (System.Exception)
            {

                return false;
            }

        }


        public async Task<bool> UpdateOrder(Order order)
        {
            return await _orderDatabaseService.UpdateOrder(order);
        }


        public async Task<List<Order>> GetOrdersByCustomerId(int customerId)
        {
            return await _orderDatabaseService.GetOrdersByCustomerId(customerId);
        }

        public void ShowOrders(List<Order> orders)
        {

            Console.WriteLine(@"
            Bestellingoverzicht:
            
            ID  | Datum         | Status
            -----------------------------------");

            foreach (Order order in orders)
            {
                string orderId = order.Id.ToString().PadRight(4);
                string date = order.Date.ToString().PadRight(14);
                string status = order.OrderStatus.ToString().PadRight(12);

                Console.WriteLine($@"            {orderId}| {date}| {status}");

            }


        }

    }

}