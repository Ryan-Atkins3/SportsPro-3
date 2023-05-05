namespace Case_Study_3_1.Models.Validation
{
	public class Validate
	{
        private static Repository<Customer> data { get; set; }

		

        public static string CheckCustomer(SportsProContext context, Customer customer)
		{
			data = new Repository<Customer>(context);
			//var DbCus = context.Customers.FirstOrDefault(c => c.Email == customer.Email);
			var DbCus = data.Get(new QueryOptions<Customer>
			{
				Where = c => c.Email == customer.Email
			});

			if (DbCus == null)
			{
				return "";
			} else
			{
				return $"{customer.Email} is already in the database.";
			}
		}
	}
}
