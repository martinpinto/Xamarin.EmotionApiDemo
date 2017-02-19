using System;
using System.Collections.Generic;

namespace EmotionDemo
{
	public class Emotion
	{
		public FaceRectangle FaceRectangle { get; set; }

		public Scores Scores { get; set; }

		public Scores.ScoreType EmotionType { get; set; }

		public double ActualScore
		{
			get
			{
				double maxValue = 0.0;
				if (Scores != null)
				{
					foreach (var score in Scores.ScoresList)
					{
						if (score.Value > maxValue)
						{
							maxValue = Math.Max(maxValue, score.Value);
							EmotionType = score.Key;
						}
					}
				}

				return maxValue;
			}

		}

		public Emotion(FaceRectangle faceRectangle, Scores scores)
		{
			FaceRectangle = faceRectangle;
			Scores = scores;
		}

	}

}
