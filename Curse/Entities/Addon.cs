using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System;

namespace Curse.Entities
{
	[DebuggerDisplay("{Name,nq}: {Id}")]
	public sealed class Addon : IEquatable<Addon>
	{
		[JsonProperty("id")]
		public long Id { get; internal set; }

		[JsonProperty("name")]
		public string Name { get; internal set; }

		[JsonProperty("authors")]
		internal List<AddonAuthor> _authorsInternal;

		[JsonProperty("attachments")]
		internal List<AddonAttachment> _attachmentsInternal;

		[JsonIgnore]
		public IReadOnlyList<AddonAuthor> Authors { get; internal set; }

		[JsonIgnore]
		public IReadOnlyList<AddonAttachment> Attachments { get; internal set; }

		[JsonProperty("websiteUrl")]
		public Uri Url { get; internal set; }

		[JsonProperty("gameId")]
		public GameType Game { get; internal set; }

		[JsonProperty("summary")]
		public string Summary { get; internal set; }

		[JsonProperty("defaultFileId")]
		public long DefaultFileId { get; internal set; }

		[JsonProperty("downloadCount")]
		public double DownloadCount { get; internal set; }

		[JsonProperty("categories")]
		internal List<AddonCategory> _categoriesInternal;

		[JsonIgnore]
		public IReadOnlyList<AddonCategory> Categories { get; internal set; }


		[JsonIgnore]
		public AddonService Service { get; internal set; }

		public override int GetHashCode()
		{
			return Tuple.Create(this.Id, this.Name)
				.GetHashCode();
		}

		public override string ToString()
		{
			return $"{this.Name} ({this.Id})";
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Addon);
		}

		public bool Equals(Addon other)
		{
			if (ReferenceEquals(other, null))
				return false;

			if (ReferenceEquals(other, this))
				return true;

			return this.Id == other.Id;
		}
	}
}
