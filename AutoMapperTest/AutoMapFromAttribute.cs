using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
	public class AutoMapFromAttribute : Attribute
	{
		public Type Source { get; set; }

		public AutoMapFromAttribute( Type source )
		{
			Source = source;
		}
	}
}
