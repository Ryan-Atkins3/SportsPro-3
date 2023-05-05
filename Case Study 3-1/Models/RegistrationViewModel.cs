namespace Case_Study_3_1.Models
{
    public class RegistrationViewModel
    {
        public IEnumerable<Customer> Customers { get; set; } = null!;

        public Customer customer { get; set; } = null!;

        public IEnumerable<Product> products { get; set; } = null!;

        public Product product { get; set; } = null!;

        public int ProductId { get; set; }

        public IEnumerable<Product> customerProducts { get; set; } = null!;

    }
}
