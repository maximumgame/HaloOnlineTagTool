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
	[TagStructure(Class = "glps", Size = 0x1C)]
	public class GlobalPixelShader
	{
		public List<UnknownBlock> Unknown;
		public float Unknown2;
		public List<UnknownBlock2> Unknown3;

		[TagStructure(Size = 0x10)]
		public class UnknownBlock
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
		}

		[TagStructure(Size = 0x50)]
		public class UnknownBlock2
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public byte[] Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public float Unknown15;
			public float Unknown16;
		}
	}
}
