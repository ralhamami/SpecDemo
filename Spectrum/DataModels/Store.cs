using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.DataModels
{
    public class StoreResponseData
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public int count { get; set; }
        public List<Store> locations { get; set; }
    }

    public class Store
    {
        public string locationName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string hours { get; set; }
        public List<Photo> photos { get; set; }
    }

    public class Photo
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public List<Derivative> derivatives { get; set; }
    }

    public class Derivative
    {

        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
