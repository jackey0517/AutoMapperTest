using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
	class Program
	{
		static void Main( string[] args )
		{
			var tests = new TypcialUsageTest();

			try
			{
				tests.Test();
			}
			catch ( AutoMapperConfigurationException ex )
			{
				Console.WriteLine( ex );
			}

			Console.ReadLine();
		}
	}
}
