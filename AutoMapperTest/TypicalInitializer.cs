using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
	class TypicalInitializer : IMapperInitializer
	{
		public void Initialize()
		{
			Mapper.Initialize( c =>
			{
				c.CreateMap<PersonEntity, Person>()
					.ForMember( p => p.BirthYear, _ => _.Ignore() )
					.ForMember( p => p.BirthMonth, _ => _.MapFrom( _e => _e.BirthDay.Month ) );

				c.CreateMap<Person, PersonEntity>();

				c.CreateMap<ChildEntity, Child>().IncludeBase<PersonEntity, Person>();
			} );
		}
	}
}
