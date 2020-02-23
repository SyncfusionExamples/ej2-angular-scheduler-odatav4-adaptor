using System.Web.Http;
using System.Web.Http.OData.Batch;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Restful_Crud.Models;

namespace Restful_Crud
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // OData configuration and services

            // OData routes
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            ODataBatchHandler batchHandler = new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer);
            builder.EntitySet<EventData>("EventDatas");
            config.Routes.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel(), batchHandler);
        }
    }
}