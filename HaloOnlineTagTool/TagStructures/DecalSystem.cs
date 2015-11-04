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
	[TagStructure(Class = "decs", Size = 0x24)]
	public class DecalSystem
	{
		public float Unknown;
		public float Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public List<DecalSystemBlock> DecalSystem2;
		public float Unknown6;

		[TagStructure(Size = 0x74)]
		public class DecalSystemBlock
		{
			public StringId Name;
			public float Unknown;
			public HaloTag BaseRenderMethod;
			public List<UnknownBlock> Unknown2;
			public List<ImportDatum> ImportData;
			public List<ShaderProperty> ShaderProperties;
			public sbyte Unknown3;
			public sbyte Unknown4;
			public sbyte Unknown5;
			public sbyte Unknown6;
			public float Unknown7;
			public int Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public float Unknown15;
			public float Unknown16;
			public float Unknown17;
			public float Unknown18;
			public float Unknown19;

			[TagStructure(Size = 0x2)]
			public class UnknownBlock
			{
				public short Unknown;
			}

			[TagStructure(Size = 0x3C)]
			public class ImportDatum
			{
				public StringId MaterialType;
				public int Unknown;
				public HaloTag Bitmap;
				public float Unknown2;
				public int Unknown3;
				public short Unknown4;
				public short Unknown5;
				public short Unknown6;
				public short Unknown7;
				public short Unknown8;
				public short Unknown9;
				public float Unknown10;
				public List<Function> Functions;

				[TagStructure(Size = 0x24)]
				public class Function
				{
					public int Unknown;
					public StringId Name;
					public float Unknown2;
					public float Unknown3;
					public byte[] Function2;
				}
			}

			[TagStructure(Size = 0x84)]
			public class ShaderProperty
			{
				public HaloTag Template;
				public List<ShaderMap> ShaderMaps;
				public List<Argument> Arguments;
				public List<UnknownBlock> Unknown;
				public float Unknown2;
				public List<UnknownBlock2> Unknown3;
				public List<UnknownBlock3> Unknown4;
				public List<UnknownBlock4> Unknown5;
				public List<Function> Functions;
				public int Unknown6;
				public int Unknown7;
				public float Unknown8;
				public short Unknown9;
				public short Unknown10;
				public short Unknown11;
				public short Unknown12;
				public short Unknown13;
				public short Unknown14;
				public short Unknown15;
				public short Unknown16;

				[TagStructure(Size = 0x18)]
				public class ShaderMap
				{
					public HaloTag Bitmap;
					public sbyte Unknown;
					public sbyte BitmapIndex;
					public sbyte Unknown2;
					public byte BitmapFlags;
					public sbyte UnknownBitmapIndexEnable;
					public sbyte UvArgumentIndex;
					public sbyte Unknown3;
					public sbyte Unknown4;
				}

				[TagStructure(Size = 0x10)]
				public class Argument
				{
					public float Arg1;
					public float Arg2;
					public float Arg3;
					public float Arg4;
				}

				[TagStructure(Size = 0x4)]
				public class UnknownBlock
				{
					public float Unknown;
				}

				[TagStructure(Size = 0x2)]
				public class UnknownBlock2
				{
					public short Unknown;
				}

				[TagStructure(Size = 0x6)]
				public class UnknownBlock3
				{
					public float Unknown;
					public sbyte Unknown2;
					public sbyte Unknown3;
				}

				[TagStructure(Size = 0x4)]
				public class UnknownBlock4
				{
					public short Unknown;
					public short Unknown2;
				}

				[TagStructure(Size = 0x24)]
				public class Function
				{
					public int Unknown;
					public StringId Name;
					public float Unknown2;
					public float Unknown3;
					public byte[] Function2;
				}
			}
		}
	}
}
