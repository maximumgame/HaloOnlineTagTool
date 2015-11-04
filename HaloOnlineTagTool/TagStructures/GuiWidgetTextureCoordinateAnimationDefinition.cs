using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "wtuv", Size = 0x2C)]
	public class GuiWidgetTextureCoordinateAnimationDefinition
	{
		public float Unknown;
		public List<UnknownBlock> Unknown2;
		public byte[] Unknown3;
		public float Unknown4;
		public float Unknown5;

		[TagStructure(Size = 0x18)]
		public class UnknownBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
		}
	}
}
