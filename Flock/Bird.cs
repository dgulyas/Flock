using System;

namespace Flock
{
	public class Bird
	{
		public Point Location;
		public Velocity Velocity = new Velocity(0,0);

		public int BirdNum;

		public double Acceleration = 5;
		public double TopSpeed = 8;

		public void Tick(Point groupCenter)
		{
			//find birds distance from the center of the flock
			var xDiff = groupCenter.X - Location.X;
			var yDiff = groupCenter.Y - Location.Y;

			//Find the percentage that each direction is
			var xDiffNorm = xDiff / (Math.Abs(xDiff) + Math.Abs(yDiff));
			var yDiffNorm = yDiff / (Math.Abs(xDiff) + Math.Abs(yDiff));

			//each direction applies its percentage of the acceleration
			//to the birds velocity
			Velocity.XDelta += xDiffNorm * Acceleration;
			Velocity.YDelta += yDiffNorm * Acceleration;

			//DecayVelocity();
			//ApplySpeedLimits();

			Location.X += Velocity.XDelta;
			Location.Y += Velocity.YDelta;

			KeepOnScreen();
		}

		//This sucks. Bird can travel faster diagonally than in a
		//cardinal direction. I haven't tried to work out the
		//trig to do this properly yet.
		private void ApplySpeedLimits()
		{
			if (Velocity.XDelta > TopSpeed)
			{
				Velocity.XDelta = TopSpeed;
			}

			if (Velocity.YDelta > TopSpeed)
			{
				Velocity.YDelta = TopSpeed;
			}
		}

		private void DecayVelocity(double decayRate = 0.98)
		{
			//Currently a flock has constant energy, either
			//potential energy (distance from flock center) or
			//kinetic energy. This function drains that energy making
			//all birds in the flock eventually hover over
			//the center. That's not fun.
			Velocity.XDelta *= decayRate;
			Velocity.YDelta *= decayRate;
		}

		private void KeepOnScreen()
		{
			if (Location.X < 0) Location.X = 0;
			if (Location.Y < 0) Location.Y = 0;
			if (Location.X > 780) Location.X = 780;
			if (Location.Y > 780) Location.Y = 780;
		}

	}
}
