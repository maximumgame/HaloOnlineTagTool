﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Serialization
{
	/// <summary>
	/// Allows easy enumeration over a tag structure's elements and filtering by version.
	/// </summary>
	public class TagFieldEnumerator
	{
		private static readonly TagFieldAttribute DefaultFieldAttribute = new TagFieldAttribute();

		private readonly EngineVersion _version;
		private readonly List<FieldInfo> _fields = new List<FieldInfo>();
		private int _nextIndex;

		/// <summary>
		/// Constructs an enumerator over a structure with no version filtering.
		/// </summary>
		/// <param name="structure">The structure type. Must have a <see cref="TagStructureAttribute"/>.</param>
		public TagFieldEnumerator(Type structure)
			: this(structure, EngineVersion.Unknown)
		{
		}

		/// <summary>
		/// Constructs an enumerator over a structure which only shows fields present in a given engine version.
		/// </summary>
		/// <param name="structure">The structure type. Must have a <see cref="TagStructureAttribute"/>.</param>
		/// <param name="version">The target engine version, or <see cref="EngineVersion.Unknown"/> to disable filtering by version.</param>
		public TagFieldEnumerator(Type structure, EngineVersion version)
		{
			StructureType = structure;
			_version = version;
			Begin();
		}

		/// <summary>
		/// Gets the type of the structure being enumerated.
		/// </summary>
		public Type StructureType { get; private set; }

		/// <summary>
		/// Gets the total size of the structure, including parent structures.
		/// </summary>
		public uint StructureSize { get; private set; }

		/// <summary>
		/// Gets the current <see cref="TagStructureAttribute"/>.
		/// </summary>
		public TagStructureAttribute Structure { get; private set; }

		/// <summary>
		/// Gets information about the current field.
		/// </summary>
		public FieldInfo Field { get; private set; }

		/// <summary>
		/// Gets the current property's <see cref="TagFieldAttribute"/>.
		/// </summary>
		public TagFieldAttribute Attribute { get; private set; }

		/// <summary>
		/// Gets the lowest engine version which supports this property, or <see cref="EngineVersion.Unknown"/> if unbounded.
		/// </summary>
		public EngineVersion MinVersion { get; private set; }

		/// <summary>
		/// Gets the highest engine version which supports this property, or <see cref="EngineVersion.Unknown"/> if unbounded.
		/// </summary>
		public EngineVersion MaxVersion { get; private set; }

		/// <summary>
		/// Moves to the next tag field in the structure.
		/// This must be called before accessing any of the other properties.
		/// </summary>
		/// <returns><c>true</c> if the enumerator moved to a new element, or <c>false</c> if the end of the structure has been reached.</returns>
		public bool Next()
		{
			do
			{
				if (_fields == null || _nextIndex >= _fields.Count)
					return false;
				Field = _fields[_nextIndex];
				_nextIndex++;
			} while (!GetCurrentPropertyInfo());
			return true;
		}

		private void Begin()
		{
			// Get the attribute for the main structure type
			Structure = GetStructureAttribute(StructureType);
			if (Structure == null)
				throw new InvalidOperationException("No TagStructure attribute which matches the target version was found on " + StructureType.Name);

			// Build the field list. Scan through the type's inheritance
			// hierarchy and add any fields belonging to parent classes that
			// also have TagStructure attributes.
			var currentType = StructureType;
			while (currentType != null)
			{
				var attrib = (currentType != StructureType) ? GetStructureAttribute(currentType) : Structure;
				if (attrib != null)
				{
					_fields.AddRange(currentType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly));
					StructureSize += attrib.Size;
				}
				currentType = currentType.BaseType;
			}

			// Order the field list in declaration order using the MetadataToken
			_fields.Sort((x, y) => x.MetadataToken - y.MetadataToken);
		}

		private TagStructureAttribute GetStructureAttribute(Type type)
		{
			// First match against any TagStructureAttributes that have version restrictions
			var attrib = type.GetCustomAttributes(typeof(TagStructureAttribute), false)
				.Cast<TagStructureAttribute>()
				.Where(a => a.MinVersion != EngineVersion.Unknown || a.MaxVersion != EngineVersion.Unknown)
				.FirstOrDefault(a => VersionMatches(a.MinVersion, a.MaxVersion));

			// If nothing was found, find the first attribute without any version restrictions
			return attrib ?? type.GetCustomAttributes(typeof(TagStructureAttribute), false)
				.Cast<TagStructureAttribute>()
				.FirstOrDefault(a => a.MinVersion == EngineVersion.Unknown && a.MaxVersion == EngineVersion.Unknown);
		}

		private bool GetCurrentPropertyInfo()
		{
			// If the field has a TagFieldAttribute, use it, otherwise use the default
			Attribute = Field.GetCustomAttributes(typeof(TagFieldAttribute), false).FirstOrDefault() as TagFieldAttribute ??
			          DefaultFieldAttribute;
			if (Attribute.Offset >= Structure.Size)
				throw new InvalidOperationException("Offset for property \"" + Field.Name + "\" is outside of its structure");

			// Read version restrictions, if any
			var minVersionAttrib = Field.GetCustomAttributes(typeof(MinVersionAttribute), false).FirstOrDefault() as MinVersionAttribute;
			var maxVersionAttrib = Field.GetCustomAttributes(typeof(MaxVersionAttribute), false).FirstOrDefault() as MaxVersionAttribute;
			MinVersion = (minVersionAttrib != null) ? minVersionAttrib.Version : EngineVersion.Unknown;
			MaxVersion = (maxVersionAttrib != null) ? maxVersionAttrib.Version : EngineVersion.Unknown;
			return VersionMatches(MinVersion, MaxVersion);
		}

		private bool VersionMatches(EngineVersion min, EngineVersion max)
		{
			if (_version == EngineVersion.Unknown)
				return true;
			if (min != EngineVersion.Unknown && VersionDetection.Compare(_version, min) < 0)
				return false;
			return (max == EngineVersion.Unknown || VersionDetection.Compare(_version, max) <= 0);
		}
	}
}
