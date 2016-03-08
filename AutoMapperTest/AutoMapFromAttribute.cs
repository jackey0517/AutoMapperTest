using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
	[AttributeUsage( AttributeTargets.Class, Inherited = false, AllowMultiple = false )]
	public class AutoMapFromAttribute : Attribute
	{
		public Type Source { get; set; }

		public AutoMapFromAttribute( Type source )
		{
			Source = source;
		}
	}
}
