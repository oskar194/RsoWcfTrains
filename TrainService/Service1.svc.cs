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
	public class DataTrain {
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
			return "From " + CityFrom + " at " + FromDate.ToShortDateString()+ " " + FromDate.ToShortTimeString() + " to " + CityTo + " at " + ToDate.ToShortDateString() + " " + ToDate.ToShortTimeString();
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
		private readonly DateTime defaultToDate = new DateTime(3000, 12, 30);
		private readonly DateTime defaultFromDate = new DateTime(1900, 1, 1);
		public Service1() {
			list = parseDocument(Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data","trains.csv"));
		}

		public List<string> GetTrip(string fromCity, string toCity) {
			return GetTrip(fromCity, toCity, defaultFromDate, defaultToDate);
		}

		public bool AssertThatCityExist(string city) {
			bool found = false;
			foreach(DataTrain dataTrain in list) {
				if(dataTrain.CityFrom.Equals(city) || dataTrain.CityTo.Equals(city)) {
					found = true;
				}
			}
			return found;
		}

		public List<DataTrain> ExtractMatchingTrains(List<DataTrain> trainsList, string fromCity, DateTime fromDate, DateTime toDate) {
			List<DataTrain> initList = new List<DataTrain>();
			foreach (DataTrain dataTrain in trainsList) {
				if (dataTrain.CityFrom.Equals(fromCity) && dataTrain.FromDate.CompareTo(fromDate) >= 0 && dataTrain.ToDate.CompareTo(toDate) <= 0) {
					initList.Add(dataTrain);
				}
			}
			return initList;
		}

		public List<string> GetTrip(string fromCity, string toCity, DateTime fromDate, DateTime toDate){
			if (!AssertThatCityExist(fromCity))
				throw new FaultException<MyException>(new MyException("City " + fromCity + " not found"));
			if(!AssertThatCityExist(toCity))
				throw new FaultException<MyException>(new MyException("City " + toCity + " not found"));
			List<DataTrain> path = new List<DataTrain>();
			List<DataTrain> initList = new List<DataTrain>();
			List<string> result = new List<string>();
			initList = ExtractMatchingTrains(list, fromCity, fromDate, toDate);
			if(initList.Count > 0) {
				foreach (DataTrain dataTrain in initList) {
					if (dataTrain.CityTo.Equals(toCity)) {
						result.Add(dataTrain.ToString());
					} else {
						path.Add(dataTrain);
					}
				}
			}
			foreach(DataTrain dt in path) {
				List<DataTrain> expanded = ExtractMatchingTrains(list, dt.CityTo, dt.FromDate, toDate);
				foreach (DataTrain dataTrain in expanded) {
					if (dataTrain.CityTo.Equals(toCity)) {
						result.Add("Start in : " + dt.ToString() + " and " + dataTrain.ToString());
					}
				}
			}
			if(result.Count < 1)
				throw new FaultException<MyException>(new MyException("Any connection cannot be found"));
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
