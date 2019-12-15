using Newtonsoft.Json;
using System.Diagnostics;
using System;

namespace Curse.Entities
{
	[DebuggerDisplay("{Name,nq}")]
	public sealed class AddonCategory : IEquatable<AddonCategory>
	{
		[JsonProperty("categoryId")]
		public long Id { get; internal set; }

		[JsonProperty("name")]
		public string Name { get; internal set; }

		[JsonProperty("url")]
		public Uri Url { get; internal set; }

		[JsonProperty("avatarUrl")]
		public Uri AvatarUrl { get; internal set; }

		[JsonProperty("parentId")]
		public long ParentId { get; internal set; }

		[JsonProperty("rootId")]
		public long RootId { get; internal set; }

		[JsonProperty("projectId")]
		public long ProjectId { get; internal set; }

		[JsonProperty("avatarId")]
		public long AvatarId { get; internal set; }

		[JsonProperty("gameId")]
		public GameType Game { get; internal set; }

		public override int GetHashCode()
		{
			return Tuple.Create(this.Name, this.Id, this.Game).GetHashCode();
		}

		public override string ToString()
		{
			return $"{this.Name} ({this.Id})";
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as AddonCategory);
		}

		public bool Equals(AddonCategory other)
		{
			if (other is null)
				return false;

			if (ReferenceEquals(this, other))
				return true;

			return this.Id == other.Id
				&& this.Name == other.Name;
		}
	}
}
