using System;
using System.Collections.Generic;

namespace Flock
{
	public class BirdGroup
	{
		public List<Bird> Birds = new List<Bird>();
		public double BirdAcceleration;
		public double BirdTopSpeed;

		public Point GroupCenter;

		public BirdGroup(int numBirds, int areaWidth, int areaHeight)
		{
			var rand = new Random();

			for (int i = 0; i < numBirds; i++)
			{
				var location = new Point(rand.NextDouble() * areaWidth, rand.NextDouble()*areaHeight);
				Birds.Add(new Bird { BirdNum = i, Velocity = new Velocity(0, 0), Location = location });
			}
			GroupCenter = GetGroupCenter();
		}

		public BirdGroup(int testCase)
		{
			switch (testCase)
			{
				case 1:
					Birds.Add(new Bird { BirdNum = 1, Velocity = new Velocity(0, 0), Location = new Point(10, 10) });
					Birds.Add(new Bird { BirdNum = 2, Velocity = new Velocity(0, 0), Location = new Point(110, 10) });
					Birds.Add(new Bird { BirdNum = 3, Velocity = new Velocity(0, 0), Location = new Point(10, 110) });
					Birds.Add(new Bird { BirdNum = 4, Velocity = new Velocity(0, 0), Location = new Point(110, 110) });
					GroupCenter = GetGroupCenter();
					break;
				default:
					break;
			}

		}

		public void Tick()
		{
			GroupCenter = GetGroupCenter();
			foreach (var bird in Birds)
			{
				bird.Tick(GroupCenter);
			}
		}

		public Point GetGroupCenter()
		{
			var totalX = 0D;
			var totalY = 0D;

			foreach (var bird in Birds)
			{
				totalX += bird.Location.X;
				totalY += bird.Location.Y;
			}

			return new Point(totalX/Birds.Count, totalY/Birds.Count);
		}

	}
}
