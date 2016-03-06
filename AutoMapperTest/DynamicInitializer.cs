using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
	class DynamicInitializer : IMapperInitializer
	{
		public void Initialize()
		{
			var mappings = Assembly.GetExecutingAssembly().GetTypes()
				.Select( _ => new { Attr = _.GetCustomAttribute<AutoMapAttribute>(), Type = _ } )
				.Where( _ => _.Attr != null )
				.Select( _ => new { Src = _.Type, Dest = _.Attr.Destination } );

			var profileType = typeof( Profile );
			var profiles = Assembly.GetExecutingAssembly().GetTypes()
				.Where( t => profileType.IsAssignableFrom( t ) && t.GetConstructor( Type.EmptyTypes ) != null )
				.Select( Activator.CreateInstance )
				.Cast<Profile>();

			Mapper.Initialize( c =>
			{
				foreach ( var p in mappings ) c.CreateMap( p.Src, p.Dest );
				foreach ( var p in profiles ) c.AddProfile( p );
			} );
		}
	}


	public class AutoMapAttribute : Attribute
	{
		public Type Destination { get; set; }

		public AutoMapAttribute( Type destination )
		{
			Destination = destination;
		}
	}


	public class PersonMappingProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<PersonEntity, Person>()
					.ForMember( p => p.BirthYear, _ => _.Ignore() )
					.ForMember( p => p.BirthMonth, _ => _.MapFrom( _e => _e.BirthDay.Month ) );
		}
	}

	public class ChildMappingProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<ChildEntity, Child>().IncludeBase<PersonEntity, Person>();
		}
	}
}
