using System.Collections.Generic;
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
		internal List<AddonAuthor> _authorsInternal = new List<AddonAuthor>();

		[JsonIgnore]
		public IReadOnlyList<AddonAuthor> Authors => this._authorsInternal.AsReadOnly();

		[JsonProperty("attachments")]
		internal List<AddonAttachment> _attachmentsInternal = new List<AddonAttachment>();

		[JsonIgnore]
		public IReadOnlyList<AddonAttachment> Attachments => this._attachmentsInternal.AsReadOnly();

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
		internal List<AddonCategory> _categoriesInternal = new List<AddonCategory>();

		[JsonIgnore]
		public IReadOnlyList<AddonCategory> Categories => this._categoriesInternal.AsReadOnly();

		[JsonProperty("categorySection", NullValueHandling = NullValueHandling.Ignore)]
		public AddonCategorySection CategorySection { get; internal set; }

		[JsonProperty("slug")]
		public string Slug { get; internal set; }

		[JsonProperty("gameVersionLatestFiles")]
		internal List<GameVersionLatestFile> _gameVersionLatestFilesInternal = new List<GameVersionLatestFile>();

		[JsonIgnore]
		public IReadOnlyList<GameVersionLatestFile> GameVersionLatestFiles => this._gameVersionLatestFilesInternal.AsReadOnly();

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
			if (other is null)
				return false;

			if (ReferenceEquals(other, this))
				return true;

			return this.Id == other.Id;
		}

		public static bool operator ==(Addon a1, Addon a2)
		{
			if (ReferenceEquals(a1, a2))
				return true;

			if (a1 is null)
				return false;

			if (a2 is null)
				return false;

			return a1.Equals(a2);
		}

		public static bool operator !=(Addon a1, Addon a2)
			=> !(a1 == a2);
	}

	public class AddonFile
	{
		public 
	}
}
