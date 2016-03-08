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
				.Select( _ => new { MapFromAttr = _.GetCustomAttribute<AutoMapFromAttribute>(), Type = _ } )
				.Where( _ => _.MapFromAttr != null )
				.Select( _ => new { Src = _.MapFromAttr.Source, Dest = _.Type } );

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
}
