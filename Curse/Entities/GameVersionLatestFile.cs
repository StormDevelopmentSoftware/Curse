using Newtonsoft.Json;
using System;

namespace Curse.Entities
{
	public class GameVersionLatestFile : IEquatable<GameVersionLatestFile>
	{
		[JsonProperty("gameVersion")]
		public string Version { get; internal set; }

		[JsonProperty("projectFileId")]
		public long ProjectFileId { get; internal set; }

		[JsonProperty("projectFileName")]
		public string ProjectFileName { get; internal set; }

		[JsonProperty("fileType")]
		public GameVersionLatestFileType FileType { get; internal set; }

		[JsonProperty("gameVersionFlavor", NullValueHandling = NullValueHandling.Ignore)]
		public string GameVersionFlavor { get; internal set; }

		public bool Equals(GameVersionLatestFile other)
		{
			if (other is null)
				return false;

			if (ReferenceEquals(this, other))
				return true;

			return this.FileType == other.FileType
				&& this.ProjectFileId == other.ProjectFileId
				&& this.ProjectFileName == other.ProjectFileName
				&& this.Version == other.Version;
		}
	}
}
