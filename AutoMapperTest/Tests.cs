using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
	class Tests
	{
		public void Test()
		{
			var entity = new PersonEntity { Id = 100, Name = "test", BirthDay = DateTime.Now };
			entity.Values.Add( 100 );
			entity.Values.Add( 200 );

			var child = new ChildEntity { Id = 10001, Name = "Child1" };
			entity.Children.Add( child );

			var p = Mapper.Map<Person>( entity );

			PrintLine( p );
		}


		private static void PrintLine( object obj )
		{
			Debug.WriteLine( obj );
			Console.WriteLine( obj );
		}
	}
}
