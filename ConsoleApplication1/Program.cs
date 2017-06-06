using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ConsoleApplication1.ServiceReference1;

namespace ConsoleApplication1 {
	class Program {
		static void Main(string[] args) {
			//2017 - 05 - 10 8:00
			//	2017 - 05 - 10 10:00
			Service1Client client = new Service1Client();
			client.GetTripWithDate("A", "B", new DateTime(2017, 05, 10, 8, 0, 0), new DateTime(2017, 05, 10, 10, 0, 0));
			// Użyj zmiennej „client” do wywoływania operacji dla usługi.

			// Zawsze zamykaj klienta.
			client.Close();
		}
	}
}
