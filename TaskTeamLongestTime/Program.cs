using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TaskTeamLongestTime
{
	class Program
	{
		static void Main(string[] args)
		{
			EmployeeService employeeService = new EmployeeService();
			List<WorkedTogetherEmployee> workedTogetherEmployees = new List<WorkedTogetherEmployee>();

			List<Employee> employees = employeeService.GetEmployees();

			for (int i = 0; i < employees.Count; i++)
			{
				for (int j = 0; j < employees.Count; j++)
				{
					if (employees[i].EmpID != employees[j].EmpID && employees[i].ProjectID == employees[j].ProjectID
						&& employees[i].DateFrom < employees[j].DateTo)
					{
						var starTime = employees[i].DateFrom > employees[j].DateFrom ? employees[j].DateFrom : employees[i].DateFrom;
						var endTime = employees[i].DateTo > employees[j].DateTo ? employees[j].DateTo : employees[i].DateTo;


						workedTogetherEmployees.Add(new WorkedTogetherEmployee
						{
							FirstEmployeeId = employees[i].EmpID,
							SecondEmployeeId = employees[j].EmpID,
							ProjectId = employees[i].ProjectID,
							WorkingDaysTogether = ((DateTime)endTime - starTime).TotalDays
						});
					}

				}
			}
			WorkedTogetherEmployee workedTogetherEmployee = workedTogetherEmployees.OrderByDescending(x => x.WorkingDaysTogether).FirstOrDefault();
			Console.WriteLine($"First EmployeeId:{workedTogetherEmployee.FirstEmployeeId} ," +
				$"Second EmployeeId:{workedTogetherEmployee.SecondEmployeeId}");
			Console.ReadLine();

		}
	}
	
}
