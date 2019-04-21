using System;

namespace Flock
{
	public class Bird
	{
		public Point Location;
		public Velocity Velocity = new Velocity(0,0);

		public int BirdNum;

		public double Acceleration = 2;
		public double TopSpeed = 8;

		//I think this implementation is wrong somehow.
		//The Flock always moves up/left, never down/right.
		public void tick(Point groupCenter)
		{
			//find birds distance from the center of the flock
			var xDiff = groupCenter.X - Location.X;
			var yDiff = groupCenter.Y - Location.Y;

			//Find the percentage that each direction is
			var xDiffNorm = xDiff / Math.Abs(xDiff + yDiff);
			var yDiffNorm = yDiff / Math.Abs(xDiff + yDiff);

			//each direction applies its percentage of the acceleration
			//to the birds velocity
			Velocity.XDelta += xDiffNorm * Acceleration;
			Velocity.YDelta += yDiffNorm * Acceleration;

			ApplyLimits();

			Location.X += Velocity.XDelta;
			Location.Y += Velocity.YDelta;
		}

		//This sucks. Bird can travel faster diagonally than in a
		//cardinal direction. I haven't tried to work out the
		//math to do this properly yet.
		private void ApplyLimits()
		{
			if (Velocity.XDelta > TopSpeed)
			{
				Velocity.XDelta = TopSpeed;
			}

			if (Velocity.YDelta > TopSpeed)
			{
				Velocity.YDelta = TopSpeed;
			}

			//Should add something that keeps the bird on the screen.
		}

	}
}
