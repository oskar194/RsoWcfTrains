using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using TrainService;

namespace TrainServiceHost {
	class Program {
		static void Main(string[] args) {
			Uri baseUri = new Uri("http://localhost:8080/Service");
			ServiceHost selfHost = new ServiceHost(typeof(Service1), baseUri);
			try {
				selfHost.AddServiceEndpoint(typeof(IService1), new WSHttpBinding(), "Service1");
				ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
				behavior.HttpGetEnabled = true;
				selfHost.Description.Behaviors.Add(behavior);
				selfHost.Open();
				Console.WriteLine("Service is ready");
				Console.WriteLine("Press ENTER to close service");
				Console.WriteLine("");
				Console.ReadLine();
				selfHost.Close();
			} catch (CommunicationException e) {
				Console.WriteLine("Exception occured {0}", e.Message);
				selfHost.Abort();
			}
		}
	}
}
