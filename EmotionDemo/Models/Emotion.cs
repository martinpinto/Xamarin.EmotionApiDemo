using System;
using System.Collections.Generic;

namespace EmotionDemo
{
	public class Emotion
	{
		public FaceRectangle FaceRectangle { get; set; }

		public Scores Scores { get; set; }

		public string ActualScore { get; set; }

		public Emotion(FaceRectangle faceRectangle, Scores scores)
		{
			FaceRectangle = faceRectangle;
			Scores = scores;
		}

	}

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
	}

	public class FaceRectangle
	{
		public int Height { get; set; }
		public int Left { get; set; }
		public int Top { get; set; }
		public int Width { get; set; }
	}
}
