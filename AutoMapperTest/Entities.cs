using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
	class TestEntity
	{
		public override string ToString()
		{
			var concreteType = this.GetType();
			var lines = concreteType.GetProperties().Select( CreatePropertyDescription );
			return concreteType.FullName + Environment.NewLine + string.Join( Environment.NewLine, lines );
		}

		private string CreatePropertyDescription( PropertyInfo p )
		{
			object value = p.GetValue( this, null );
			if ( p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition().Equals( typeof( List<> ) ) )
			{
				dynamic val = value;
				value = "[" + string.Join( ",", val ) + "]";
			}

			return string.Format( "{0} : {1}", p.Name, value );
		}
	}

	class Child : Person
	{
		public Child()
		{
		}
	}

	[AutoMapAttribute( typeof( PersonEntity ) )]
	class Person : TestEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime BirthDay { get; set; }

		public int BirthYear { get; set; }

		public int BirthMonth { get; set; }

		public List<int> Values { get; private set; }

		public List<Child> Children { get; private set; }


		public Person()
		{
			Values = new List<int>();
			Children = new List<Child>();
		}
	}

	class ChildEntity : PersonEntity
	{
		public ChildEntity()
		{
		}
	}

	[AutoMapAttribute( typeof( Person ) )]
	class PersonEntity : TestEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime BirthDay { get; set; }

		public List<int> Values { get; private set; }

		public List<ChildEntity> Children { get; private set; }


		public PersonEntity()
		{
			Values = new List<int>();
			Children = new List<ChildEntity>();
		}
	}
}
