using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
	class TestEntity
	{
		public override string ToString()
		{
			var concreteType = this.GetType();
			var lines = concreteType.GetProperties().Select( p => string.Format( "{0} : {1}", p.Name, p.GetValue( this, null ) ) );
			return concreteType.FullName + Environment.NewLine + string.Join( Environment.NewLine, lines );
		}
	}

	class Person : TestEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime BirthDay { get; set; }

		public int BirthYear { get; set; }

		public int BirthMonth { get; set; }
	}

	class PersonEntity : TestEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime BirthDay { get; set; }
	}
}
