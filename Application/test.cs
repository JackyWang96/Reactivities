using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public interface ICustomer
    {
        
    }
    
    public abstract class Customer : ICustomer{
        public string name {get; set;}

        public void Enquiry(){
            Console.WriteLine("Explain him product");
        }

        public abstract decimal Discount();
    }    

    public class PlatiniumCustomer : Customer{
        public override decimal Discount()
        {
            Console.WriteLine("asdasdas");
            return 0;
        }
    }

    public class Test{
        static void Main(string[] args){
            PlatiniumCustomer t1 = new PlatiniumCustomer();
            t1.Enquiry();
        }
    }
    
}