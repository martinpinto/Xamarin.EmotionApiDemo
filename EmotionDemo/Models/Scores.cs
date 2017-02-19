using System;
using System.Collections.Generic;

namespace EmotionDemo
{
	public class Scores
	{
		public double Anger { get; set; }
		public double Contempt { get; set; }
		public double Disgust { get; set; }
		public double Fear { get; set; }
		public double Happiness { get; set; }
		public double Neutral { get; set; }
		public double Sadness { get; set; }
		public double Surprise { get; set; }

		public Dictionary<ScoreType, double> ScoresList
		{
			get
			{
				return new Dictionary<ScoreType, double> {
					{ScoreType.Anger, Anger},
					{ScoreType.Contempt, Contempt},
					{ScoreType.Disgust, Disgust},
					{ScoreType.Fear, Fear},
					{ScoreType.Happiness, Happiness},
					{ScoreType.Neutral, Neutral},
					{ScoreType.Sadness, Sadness},
					{ScoreType.Surprise, Surprise}
				};
			}
		}

		public enum ScoreType
		{
			Anger,
			Contempt,
			Disgust,
			Fear,
			Happiness,
			Neutral,
			Sadness,
			Surprise
		}
	}
}
