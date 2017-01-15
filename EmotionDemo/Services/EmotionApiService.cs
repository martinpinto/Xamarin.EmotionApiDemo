using System;
using System.Collections.Generic;
using System.Linq;

namespace EmotionDemo
{
	public class EmotionApiService
	{
		public EmotionApiService()
		{
		}

		public static IEnumerable<Person> GetPersons(string searchText = null)
		{
			var persons = new List<Person>
			{
				new Person
					{
						Name = "Alice", ImageUrl = "http://lorempixel.com/100/100/people/1", Status = "Hey I'm free."
					},
				new Person
					{
						Name = "Bob", ImageUrl = "http://lorempixel.com/100/100/people/2", Status = "Sorry, not available."
					}
			};

			if (string.IsNullOrWhiteSpace(searchText))
			{
				return persons;
			}

			return persons.Where(c => c.Name.StartsWith(searchText));
		}
	}
}
