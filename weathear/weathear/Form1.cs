using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weathear
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string url = "https://api.openweathermap.org/data/2.5/weather?q=Donetsk&appid=0ade4ff8fdb2d9a0ceec38baa9fe25c8&units=metric";
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse res = (HttpWebResponse)req.GetResponse();
			StreamReader reader = new StreamReader(res.GetResponseStream());
			string response = reader.ReadToEnd();
			richTextBox1.Text = response;
			WeatherResponse wr = JsonConvert.DeserializeObject<WeatherResponse>(response);
			lCity.Text = wr.Name;
			lTemperatura.Text = wr.Main.Temp.ToString();
		}
	}
}
