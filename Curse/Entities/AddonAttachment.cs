using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Curse.Entities
{
	[DebuggerDisplay("{Title,nq}")]
	public sealed class AddonAttachment : IEquatable<AddonAttachment>
	{
		[JsonProperty("id")]
		public long Id { get; internal set; }

		[JsonProperty("projectId")]
		public long ProjectId { get; internal set; }

		[JsonProperty("description")]
		public string Description { get; internal set; }

		[JsonProperty("isDefault")]
		public bool IsDefault { get; internal set; }

		[JsonProperty("thumbnailUrl")]
		public string ThumbnailUrl { get; internal set; }

		[JsonProperty("title")]
		public string Title { get; internal set; }

		[JsonProperty("url")]
		public Uri Url { get; internal set; }

		[JsonProperty("status")]
		public int Status { get; internal set; }

		public override int GetHashCode()
		{
			return this.Id.GetHashCode() ^ this.ProjectId.GetHashCode();
		}

		public override string ToString()
		{
			return $"{this.Title} [{this.Status}] ({this.Url})";
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as AddonAttachment);
		}

		public bool Equals(AddonAttachment other)
		{
			if (ReferenceEquals(other, null))
				return false;

			if (ReferenceEquals(this, other))
				return true;

			return this.Id == other.Id
				&& this.ProjectId == other.ProjectId;
		}
	}
}
