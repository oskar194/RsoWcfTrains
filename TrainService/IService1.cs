using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TrainService {
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract(Name ="Service1")]
	public interface IService1 {

		[OperationContract(Name ="GetTripWithDate")]
		List<string> GetTrip(string fromCity, string toCity, DateTime fromDate, DateTime toDate);

		[OperationContract(Name = "GetTripWithoutDate")]
		[FaultContract(typeof(MyException))]
		List<string> GetTrip(string fromCity, string toCity);

		// TODO: Add your service operations here
	}


	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	class MyException {
		private string msg;

		public MyException(string msg) {
			this.msg = msg;
		}

		[DataMember]
		public string Msg { get { return msg; } set { msg = value; } }
	}
}
