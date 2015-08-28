using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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


[assembly: XmlnsDefinition(@"http://www.flexcharts.com/schemas/core", "FlexCharts.Controls")]
[assembly: XmlnsDefinition(@"http://www.flexcharts.com/schemas/core", "FlexCharts.Controls.Primatives")]


[assembly: XmlnsDefinition(@"http://www.flexcharts.com/schemas/core", "FlexCharts.Data")]
[assembly: XmlnsDefinition(@"http://www.flexcharts.com/schemas/core", "FlexCharts.Data.Filtering")]
[assembly: XmlnsDefinition(@"http://www.flexcharts.com/schemas/core", "FlexCharts.Data.Sorting")]
[assembly: XmlnsDefinition(@"http://www.flexcharts.com/schemas/core", "FlexCharts.Data.Structures")]

[assembly: XmlnsDefinition(@"http://www.flexcharts.com/schemas/core", "FlexCharts.MaterialDesign")]
[assembly: XmlnsDefinition(@"http://www.flexcharts.com/schemas/core", "FlexCharts.MaterialDesign.Descriptors")]
[assembly: XmlnsDefinition(@"http://www.flexcharts.com/schemas/core", "FlexCharts.MaterialDesign.Providers")]