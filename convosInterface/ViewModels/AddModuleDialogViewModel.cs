using System;
using Library.Convos.Models;
using Library.Convos.Services;

namespace MAUI.Convos.ViewModels
{
	public class AddModuleDialogViewModel
    {
		public String Name { get; set; }
		public String Description { get; set; }

		public AddModuleDialogViewModel(string courseCode)
		{
			CourseCode = courseCode;
			if (Name == null)
				Name = string.Empty;
			if (Description == null)
				Description = string.Empty;
		}

		public string CourseCode { get; set; }

		public void AddModule(string code)
		{
			Module module = new Module();
			module.Name = Name;
			module.Description = Description;

			CourseService.Current.AddModule(CourseCode, module);
		}
	}
}