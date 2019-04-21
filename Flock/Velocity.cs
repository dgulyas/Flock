namespace Flock
{
	public class Velocity
	{
		public double XDelta;
		public double YDelta;

		public Velocity(double x, double y)
		{
			XDelta = x;
			YDelta = y;
		}

		public override string ToString()
		{
			return $"Xd:{XDelta} Yd:{YDelta}";
		}


	}
}
