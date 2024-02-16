namespace WebApp.Models
{
    public class GetDetails : ISelectInterface
    {
        public List<Orders> getDetails()
        {
            List<Orders> detail = new List<Orders> {
                    new Orders(1,new DateTime(2022,12,1),400,"1234567812",1,10,4000),
                    new Orders(2,new DateTime(2020,11,21),500,"1234567812",6,10,5000)
                };
            Console.WriteLine("Done From GetDetails, Something is done here");
            return detail;
        }
        public void setDetails(List<Orders> detail)
        {
            foreach (Orders item in detail)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Done From GetDetails, Something is done here, Value is Printing CheckOut");
        }

        public void getId(List<Orders> details)
        {
            foreach (Orders item in details)
            {
                Console.WriteLine(item.orderid);
            }
            Console.WriteLine("Done From GetDetails, Something is done here, Ids are printing Check THIS OUT");
        }
    }
}
