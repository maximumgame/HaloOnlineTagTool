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
	[TagStructure(Class = "chmt", Size = 0xC)]
	public class ChocolateMountainNew
	{
		public List<UnknownBlock> Unknown;

		[TagStructure(Size = 0x4)]
		public class UnknownBlock
		{
			public float Unknown;
		}
	}
}
