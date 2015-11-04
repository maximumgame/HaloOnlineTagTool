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
	[TagStructure(Class = "rmdf", Size = 0x5C)]
	public class RenderMethodDefinition
	{
		public HaloTag Unknown;
		public List<Method> Methods;
		public List<UnknownBlock> Unknown2;
		public List<UnknownBlock2> Unknown3;
		public HaloTag Unknown4;
		public HaloTag Unknown5;
		public float Unknown6;
		public float Unknown7;

		[TagStructure(Size = 0x18)]
		public class Method
		{
			public StringId Type;
			public List<ShaderOption> ShaderOptions;
			public StringId Unknown;
			public StringId Unknown2;

			[TagStructure(Size = 0x1C)]
			public class ShaderOption
			{
				public StringId Type;
				public HaloTag Option;
				public StringId Unknown;
				public StringId Unknown2;
			}
		}

		[TagStructure(Size = 0x10)]
		public class UnknownBlock
		{
			public float Unknown;
			public List<UnknownBlock2> Unknown2;

			[TagStructure(Size = 0x10)]
			public class UnknownBlock2
			{
				public float Unknown;
				public List<UnknownBlock> Unknown2;

				[TagStructure(Size = 0x4)]
				public class UnknownBlock
				{
					public float Unknown;
				}
			}
		}

		[TagStructure(Size = 0x10)]
		public class UnknownBlock2
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
		}
	}
}
