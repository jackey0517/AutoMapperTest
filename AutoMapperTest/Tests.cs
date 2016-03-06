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
		static Tests()
		{
			Mapper.Initialize( c =>
			{
				c.CreateMap<PersonEntity, Person>()
					.ForMember( p => p.BirthYear, _ => _.Ignore() )
					.ForMember( p => p.BirthMonth, _ => _.MapFrom( _e => _e.BirthDay.Month ) )
					.ForMember( p => p.Children, _ => _.MapFrom( _e => _e.Children ) );

				c.CreateMap<Person, PersonEntity>();

				c.CreateMap<ChildEntity, Child>().IncludeBase<PersonEntity, Person>();
			} );

			Mapper.AssertConfigurationIsValid();
		}

		public void SmokingTest()
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
