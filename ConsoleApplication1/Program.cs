using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ConsoleApplication1.ServiceReference1;

namespace ConsoleApplication1 {
	class Program {
		public Service1Client client = new Service1Client();
		static void Main(string[] args) {
			Program p = new Program();
			
			p.TryFindWithDate("A", "C", new DateTime(2017, 05, 10, 8, 0, 0), new DateTime(2017, 05, 11, 3, 0, 0));
			p.TryFindWithDate("A", "F", new DateTime(2017, 05, 10, 8, 0, 0), new DateTime(2017, 05, 11, 3, 0, 0));
			p.TryFindWithDate("G", "C", new DateTime(2017, 05, 10, 8, 0, 0), new DateTime(2017, 05, 11, 3, 0, 0));
			p.TryFindWithDate("C", "D", new DateTime(2017, 05, 10, 8, 0, 0), new DateTime(2017, 06, 11, 3, 0, 0));
			p.TryFindWithDate("B", "C", new DateTime(2018, 05, 10, 8, 0, 0), new DateTime(2017, 06, 11, 3, 0, 0));
			p.client.Close();
			Console.ReadKey();
		}


		public void TryFindWithDate(string cityFrom, string cityTo, DateTime dateFrom, DateTime dateTo) {
			Console.WriteLine("Trying to find path from " + cityFrom +
				" to " + cityTo + " at " + dateFrom.ToShortDateString() + " " + dateFrom.ToShortTimeString()
				+ " to " + dateTo.ToShortDateString() + " " + dateTo.ToShortTimeString());
			try {
				string[] s = client.GetTripWithDate(cityFrom, cityTo, dateFrom, dateTo);
				if (!s.Equals(null)) {
					foreach (string x in s) {
						Console.WriteLine(x);
					}
				}
			} catch(FaultException<MyException> ex) {
				Console.WriteLine("Exception: " + ex.Detail.Msg.ToString());
			}
		}

		public void TryFindWithoutDate(string cityFrom, string cityTo) {
			Console.WriteLine("Trying to find path from " + cityFrom +
				" to " + cityTo);
			try {
				string[] s = client.GetTripWithoutDate(cityFrom, cityTo);
				if (!s.Equals(null)) {
					foreach (string x in s) {
						Console.WriteLine(x);
					}
				}
			} catch (FaultException<MyException> ex) {
				Console.WriteLine("Exception: " + ex.Detail.Msg.ToString());
			}
		}
	}
}
