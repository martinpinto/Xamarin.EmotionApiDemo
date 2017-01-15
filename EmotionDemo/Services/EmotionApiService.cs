using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace EmotionDemo
{
	public class EmotionApiService
	{
		private const string BasePictureSmallUrl = "http://lorempixel.com/100/100/people/";
		private const string BasePictureLargeUrl = "http://lorempixel.com/1000/1000/people/";

		public static IEnumerable<Person> GetPersons(string searchText = null)
		{
			var persons = new List<Person>
			{
				new Person
					{
					Name = "Alice", ImageUrl = BasePictureSmallUrl + "4", Status = "Hey I'm free."
					},
				new Person
					{
					Name = "Bob", ImageUrl = BasePictureSmallUrl + "2", Status = "With my kids."
					},
				new Person
					{
					Name = "Carol", ImageUrl = BasePictureSmallUrl + "5", Status = "On the train."
					},
				new Person
					{
					Name = "Dave", ImageUrl = BasePictureSmallUrl + "8", Status = "Sorry, not available."
					},
				new Person
					{
					Name = "Eva", ImageUrl = BasePictureSmallUrl + "9", Status = "Looking at the sky."
					}
			};

			if (string.IsNullOrWhiteSpace(searchText))
			{
				return persons;
			}

			return persons.Where(c => c.Name.StartsWith(searchText));
		}

		public async static Task<JContainer> GetEmotion(Person person)
		{

			using (var client = new HttpClient())
			{
				// Request headers
				//client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");
				client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "5208331e269c407fb64f7bac7188c6ea");

				var uri = "https://api.projectoxford.ai/emotion/v1.0/recognize";

				HttpResponseMessage response;
				var bytes = await Download(BasePictureLargeUrl + person.ImageUrl.Substring(person.ImageUrl.Length - 1));

				using (var content = new ByteArrayContent(bytes))
				{
					content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
					response = await client.PostAsync(uri, content);
					if (response.IsSuccessStatusCode)
					{
						string jsonResponse = response.Content.ReadAsStringAsync().Result;
						var data = (JContainer) JsonConvert.DeserializeObject(jsonResponse);
						//return jsonResponse;
						return data;
					}
				}

				return null;
			}
		}

		public async static Task<byte[]> Download(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				byte[] fileArray = await client.GetByteArrayAsync(url);
				return fileArray;
			}

		}

	}
}
