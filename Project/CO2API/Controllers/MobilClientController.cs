using System;
using System.Web.Http;
using CO2API.Models;
using ProtobufServer;
using CO2API.Handlers;
using CO2API.Interfaces;
using System.Web.Http.Cors;

namespace CO2API.Controllers
{
    /// <summary>
    /// This class handles the reqsiste from mobile clients.
    /// </summary>
    public class MobilClientController : ApiController
    {
        /// <summary>
        /// Creates a trip with the parms from the url.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="StartLocationFormated"></param>
        /// <param name="EndLocationFormated"></param>
        /// <param name="Distance"></param>
        /// <param name="Starttime"></param>
        /// <param name="Endtime"></param>
        /// <param name="BreakCount"></param>
        /// <param name="AvgBreak"></param>
        /// <param name="AvgSpeed"></param>
        /// <returns></returns>
        public string CreateTrip(int UserId, double[] StartLocationFormated, double[] EndLocationFormated, double Distance, DateTime Starttime, DateTime Endtime, int BreakCount, double AvgBreak, double AvgSpeed)
        {
            return "true";
        }
        /// <summary>
        /// Creates a trip from a object that the mobil client sends.
        /// </summary>
        /// <param name="mobilData"></param>
        /// <returns></returns>
        [HttpPost]
        public string CreateTrip([FromBody] MobileClientDataModel mobilData)
        {
            if (mobilData != null)
                return "true";
            return "false";
        }
        /// <summary>
        /// Revices data via protobuf from the mobile client.
        /// </summary>
        /// <param name="data"></param>
        [HttpGet]
        public string TripViaProtobuf(string data)
        {
            try
            {
                IDatabaseHandler database = new DatabaseHandler();
                data = data.Replace(" ", "+");
                ProtobufHandler han = new ProtobufHandler();
                ProtobufServer.Trip tripdata = han.ConvertToProtobuf(data);
                database.CreateTrip(tripdata.UserId,tripdata);
                if (tripdata != null)
                    return "true";
                return "false";
            }
            catch (Exception e)
            {

                return e.Message +" data: " + data;
            }

        }
    }

}