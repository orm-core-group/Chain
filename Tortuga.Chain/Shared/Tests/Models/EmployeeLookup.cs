﻿using System.ComponentModel.DataAnnotations.Schema;

#if SQLITE
using Key = System.Int64;
#elif MYSQL
using Key = System.UInt64;
#else
using Key = System.Int32;
#endif

namespace Tests.Models
{
	/// <summary>
	/// This is used to test immutable object constructors
	/// </summary>
	[Table("Employee", Schema = "HR")]
	public class EmployeeLookup
	{

		public EmployeeLookup(Key employeeKey, string firstName, string lastName)
		{
			EmployeeKey = employeeKey;
			FirstName = firstName;
			LastName = lastName;
		}

		public Key EmployeeKey { get; }
		public string FirstName { get; }
		public string LastName { get; }
	}
}
