using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;

namespace TrainService {
	class DataTrain {
		string cityFrom;
		string cityTo;
		DateTime fromDate;
		DateTime toDate;


		public DataTrain(string cityFrom, string cityTo, DateTime fromDate, DateTime toDate) {
			this.CityFrom = cityFrom;
			this.CityTo = cityTo;
			this.FromDate = fromDate;
			this.ToDate = toDate;
		}
		public override string ToString() {
			return "From " + CityFrom + "departure: " + FromDate.ToShortDateString() + " to " + CityTo + " arrives " + ToDate.ToShortDateString();
		}

		public string CityFrom {
			get {
				return cityFrom;
			}

			set {
				cityFrom = value;
			}
		}

		public string CityTo {
			get {
				return cityTo;
			}

			set {
				cityTo = value;
			}
		}

		public DateTime FromDate {
			get {
				return fromDate;
			}

			set {
				fromDate = value;
			}
		}

		public DateTime ToDate {
			get {
				return toDate;
			}

			set {
				toDate = value;
			}
		}
	}
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IService1 {
		private List<DataTrain> list;
		private readonly DateTime defaultFromDate = new DateTime(3000, 12, 30);
		private readonly DateTime defaultToDate = new DateTime(1900, 1, 1);
		public Service1() {
			list = parseDocument(Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data","trains.csv"));
		}

		public List<string> GetTrip(string fromCity, string toCity) {
			return GetTrip(fromCity, toCity, defaultFromDate, defaultToDate);
		}

		public List<string> GetTrip(string fromCity, string toCity, DateTime fromDate, DateTime toDate){
			List<DataTrain> path = new List<DataTrain>();
			List<string> result = new List<string>();
			foreach (DataTrain d in list) {
				if (d.CityFrom.Equals(fromCity) && DateTime.Compare(d.FromDate, fromDate) >= 0 
													&& DateTime.Compare(d.ToDate, toDate) <= 0) {
					if (d.CityTo.Equals(toCity)) {
						path.Add(d);
					}
					GetTrip(d.CityTo, toCity, fromDate, toDate);
				}
			}
			if(path.Count > 0) {
				result.Add("Path start");
				foreach (DataTrain d in path) {
					result.Add(d.ToString());
				}
				result.Add("Path end");
			}
			return result;
		}

		private List<DataTrain> parseDocument(string path) {
			string[] tab = File.ReadAllLines(path);
			List<DataTrain> list = new List<DataTrain>();
			foreach(string s in tab) {
				string[] fields = s.Split(',');
				list.Add(new DataTrain(fields[0], fields[2], DateTime.Parse(fields[1]), DateTime.Parse(fields[3])));
			}
			return list;
		}
	}


}
