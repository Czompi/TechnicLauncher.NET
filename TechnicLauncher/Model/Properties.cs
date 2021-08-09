using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using TechnicLauncher.Model.Helpers;

namespace TechnicLauncher.Model
{
	[Serializable()]
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true, TypeName = "Properties")]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public partial class Properties
	{
		public override string ToString() => this.ToString<Properties>();

		[XmlElement("Property")]
		public List<Property> Property { get; set; }
	}
}