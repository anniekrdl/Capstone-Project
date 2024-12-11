namespace OnlineWebshop
{
    class OrderManager : IOrderManager
    {
        private OrderDatabaseService _orderDatabaseService = new OrderDatabaseService();
        private OrderItemDatabaseService _orderItemDatabaseService = new OrderItemDatabaseService();

        public async Task<Order?> GetOrderById(int id)
        {
            return await _orderDatabaseService.GetOrdersByOrderId(id);

        }

        public async Task<int> CreateOrderId(int customerId)
        {
            int orderId = 0;

            //new order      
            Order order = new Order(null, customerId, null, OrderStatus.AANGEMAAKT);
            await _orderDatabaseService.AddOrder(order);

            // find orderId
            List<int> foundOrders = await _orderDatabaseService.GetOrderIdByCustomerId(customerId);
            //Console.WriteLine($"Orders found total: {foundOrders.Count}. Id: {foundOrders.First()}");
            foreach (int foundOrder in foundOrders)
            {
                Order? order1 = await GetOrderById(foundOrder);

                if (order1 != null && order1.OrderStatus == OrderStatus.AANGEMAAKT)
                {
                    orderId = foundOrder;
                    break;
                }
            }

            return orderId;


        }



        public async Task<int> GetOrCreateOrderId(int customerId)
        {
            List<int> foundOrders = await _orderDatabaseService.GetOrderIdByCustomerId(customerId);

            if (foundOrders.Any())
            {
                int foundOrderId = foundOrders.First();

                Order? orderFound = await GetOrderById(foundOrderId);
                if (orderFound != null && orderFound.OrderStatus == OrderStatus.AANGEMAAKT)
                {
                    return foundOrderId;
                }
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
            if (items.Count != 0)
            {
                try
                {
                    if (customerId.HasValue)
                    {
                        int orderId = await CreateOrderId(customerId.Value);

                        Console.WriteLine($"orderId gevonden: {orderId}");

                        foreach (SelectedProductItem item in items)
                        {
                            OrderItem orderItem = new OrderItem(null, orderId, item.ProductId, item.NumberOfItems, item.Product);

                            await _orderItemDatabaseService.AddOrderItem(orderItem);
                            //update Order status

                            Order? order = await GetOrderById(orderId);
                            Console.WriteLine($"order geplaatst {order.Id}");

                            if (order != null)
                            {
                                order.UpdateOrderStatus(OrderStatus.GEPLAATST);
                                await UpdateOrder(order);
                            }


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
            else
            {
                Console.WriteLine("\nJe winkelwagen is leeg.");
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

        public async void ShowOrders(List<Order> orders)
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

                //orderItems
                List<OrderItem> orderItemsList = await _orderItemDatabaseService.GetOrderItemByOrderId(int.Parse(orderId));


                Console.WriteLine($@"            {orderId}| {date}| {status}");
                foreach (OrderItem orderItem in orderItemsList)
                {
                    //TODO product is null
                    Console.WriteLine($"{orderItem.NumberOfItems}x {orderItem.Id}");
                }

            }


        }

    }

}