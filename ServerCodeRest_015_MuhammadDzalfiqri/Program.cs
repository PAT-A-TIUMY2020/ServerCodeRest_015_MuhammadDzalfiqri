using ServiceRest_015_Muhammad_Dzalfiqri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServerCodeRest_015_MuhammadDzalfiqri
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:8888/Mahasiswa");
            WebHttpBinding bind = new WebHttpBinding();
            try
            {
                hostObj = new ServiceHost(typeof(TI_UMY), address);
                hostObj.AddServiceEndpoint(typeof(ITI_UMY), bind, "");
                
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior(); 
                smb.HttpGetEnabled = true; 
                hostObj.Description.Behaviors.Add(smb);
                Binding mexbind = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange),
                mexbind, "mex");

                WebHttpBehavior whb = new WebHttpBehavior();
                whb.HelpEnabled = true;
                hostObj.Description.Endpoints[0].EndpointBehaviors.Add(whb);

                hostObj.Open();
                Console.WriteLine("Server is ready!!!!");
                Console.ReadLine();
                hostObj.Close();
            }
            catch (Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
