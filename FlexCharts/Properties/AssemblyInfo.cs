using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("FlexCharts")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("FlexCharts")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("53b04142-3fa5-4d7e-989e-efaff6b92631")]

[assembly: ThemeInfo(
		ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
																		 //(used if a resource is not found in the page, 
																		 // or application resource dictionaries)
		ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
																							//(used if a resource is not found in the page, 
																							// app, or any theme specific resource dictionaries)
)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]


[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.Controls.Charts")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.Controls.Primitives")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.Controls.Core")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.Documents")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.Data")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.Data.Filtering")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.Data.Sorting")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.Data.Structures")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.MaterialDesign")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.MaterialDesign.Descriptors")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "FlexCharts.MaterialDesign.Providers")]