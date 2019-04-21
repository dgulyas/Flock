using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flock
{
	class Program
	{
		static void Main(string[] args)
		{
			var bird = new Bird{Location = new Point(5,5)};
			while (true)
			{
				bird.tick(new Point(10, 10));
			}
		}
	}
}
