namespace OnlineWebshop
{

    class Program
    {


        static async Task Main(string[] args)
        {


            UI uI = new UI();

            await uI.StartWebshop();

        }
    }
}