using System;
using System.Collections.Generic;

namespace OpenWeatherApi
{
	public class Ville
	{
		public string name { set; get;}
		public List<Weather> weather { set; get;}
		public Main main { set; get; }
	}
}
