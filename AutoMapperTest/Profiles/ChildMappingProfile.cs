﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest.Profiles
{
	public class ChildMappingProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<ChildEntity, Child>().IncludeBase<PersonEntity, Person>()
				.ForMember( p => p.BirthYear, _ => _.Ignore() )
				.ForMember( p => p.BirthMonth, _ => _.MapFrom( _e => _e.BirthDay.Month ) );
		}
	}
}
