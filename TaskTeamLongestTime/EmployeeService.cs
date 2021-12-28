using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTeamLongestTime
{
	public class EmployeeService : IEmployee
	{
		public List<Employee> GetEmployees()
		{
			//List<Employee> employees = new List<Employee>
			//{
			//	new Employee{EmpID=143,ProjectID=10,DateFrom=new DateTime(2013, 11, 1),DateTo=new DateTime(2015, 8, 10)},
			//	new Employee{EmpID=144,ProjectID=20,DateFrom=new DateTime(2012, 8, 7),DateTo=new DateTime(2017, 9, 15)},
			//	new Employee{EmpID=145,ProjectID=10,DateFrom=new DateTime(2017, 12, 7),DateTo=null},
			//	new Employee{EmpID=146,ProjectID=15,DateFrom=new DateTime(2016, 11, 1),DateTo=new DateTime(2018, 9, 7)},
			//	new Employee{EmpID=147,ProjectID=20,DateFrom=new DateTime(2011, 6, 20),DateTo=new DateTime(2014, 5, 21)},
			//	new Employee{EmpID=148,ProjectID=15,DateFrom=new DateTime(2019, 1, 1),DateTo=null},
			//	new Employee{EmpID=149,ProjectID=20,DateFrom=new DateTime(2010, 3, 1),DateTo=new DateTime(2012, 7, 10)},
			//	new Employee{EmpID=150,ProjectID=10,DateFrom=new DateTime(2018, 10, 1),DateTo=null}
			//};
			List<Employee> employees = new List<Employee>();
			string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\", "Data.txt");
			string[] rows = File.ReadAllLines(path);
			foreach (var row in rows)
			{
				var splitRow = row.Split(',');
				employees.Add(new Employee
				{
					EmpID = int.Parse(splitRow[0]),
					ProjectID = int.Parse(splitRow[1]),
					DateFrom = DateTime.Parse(splitRow[2]),
					DateTo = splitRow[3] == "NULL" ? DateTime.Now : DateTime.Parse(splitRow[3])
				});


			}
			return employees;
		}
	}
}
