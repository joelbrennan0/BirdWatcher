using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchParameters = new BirdSearch
            {
                Size = "Medium",
                Country = "United States",
                Colors = new List<string> { "White", "Brown", "Black" },
                Page = 0,
                PageSize = 5
            };
            Console.WriteLine("Type any key to begin search");
            var birds = BirdRepository.LoadBirds();

            while(Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine($"Page: {searchParameters.Page}");

                birds.Search(searchParameters).ToList().ForEach(b =>
                {
                    Console.WriteLine($"Common Name: {b.CommonName}");
                });
                searchParameters.Page++;
            }
        }
    }
}
