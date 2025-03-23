using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;


namespace ClassLibrary2
{

    /// Purpose : Update Default Contact Description
    /// Target : Contact
    /// Message : Create
    /// OPeration : post
    /// Mode : sync

    public class ClassLibrary2 : IPlugin
    {

        public void Execute(IServiceProvider serviceProvider)
        {

            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            tracingService.Trace("Function start");

            // Obtain the execution context from the service provider.  
            IPluginExecutionContext context = (IPluginExecutionContext)
            serviceProvider.GetService(typeof(IPluginExecutionContext));

            /// "Target" represent entity on which code is executed
            if (context.InputParameters.Contains("Target") &&
    context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parameters.  
                Entity entity = (Entity)context.InputParameters["Target"];


                //entity object has information related to id of record, if it's runing in pre-operation or post-operation
                //post-operation mean that data is saved into database and it's possible to know if record is related to (GUID, primary key) obviously 
                //entity.LogicName give actual table name
                //entity.Attribute give value related to different attribute of record

                if (entity.LogicalName.Equals("ahmed_event"))
                {
                    string jobTitle = entity.Attributes.Contains("jobTitle") ? entity.Attributes["jobTitle"].ToString() : string.Empty;
                    if (jobTitle.Equals(string.Empty))
                    {
                        entity.Attributes["ahmed_name_of_event"] = "**";

                    }
                }

            }

            tracingService.Trace("Function end");

            ///           gather user for example from context
            //            context.UserId = context.UserId.ToString(); 


        }




        //            throw new NotImplementedException();

        //            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
        //            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
        //            IOrganizationService _service = factory.CreateOrganizationService(context.InitiatingUserId);

        //            if(context.PrimaryEntityName == "account") {
        //                Entity accountRecord = _service.Retreive("account", context.PrimaryEntityId, new ColumnSet("name", "telephone1"));
        //            }

    }
}
