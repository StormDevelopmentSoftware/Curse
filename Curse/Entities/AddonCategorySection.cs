using Newtonsoft.Json;
using System;

namespace Curse.Entities
{
	public class AddonCategorySection : IEquatable<AddonCategorySection>
	{
		[JsonProperty("id")]
		public long Id { get; internal set; }

		[JsonProperty("gameId")]
		public GameType Game { get; internal set; }

		[JsonProperty("name")]
		public string Name { get; internal set; }

		[JsonProperty("packageType")]
		public AddonPackageType PackageType { get; internal set; }

		[JsonProperty("path")]
		public string Path { get; internal set; }

		[JsonProperty("initialInclusionPattern", NullValueHandling = NullValueHandling.Ignore)]
		public string InitialInclusionPattern { get; internal set; }

		[JsonProperty("extraIncludePattern", NullValueHandling = NullValueHandling.Ignore)]
		public string ExtraIncludePattern { get; internal set; }

		[JsonProperty("gameCategoryId")]
		public long GameCategoryId { get; internal set; }

		public override int GetHashCode()
		{
			return Tuple.Create(this.Id, this.Name)
				.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as AddonCategorySection);
		}

		public bool Equals(AddonCategorySection other)
		{
			if (other is null)
				return false;

			if (ReferenceEquals(this, other))
				return true;

			return this.Id == other.Id
				&& this.Name == other.Name
				&& this.Path == other.Path;
		}
	}
}
