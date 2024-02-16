namespace WebApp.Models
{
    public interface ISelectInterface
    {
        public List<Orders> getDetails();
        public void setDetails(List<Orders> details);

        public void getId(List<Orders> detail);

    }
}
