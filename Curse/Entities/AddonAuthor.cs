using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Curse.Entities
{
    [DebuggerDisplay("{Name,nq} ({Url,nq})")]
	public sealed class AddonAuthor : IEquatable<AddonAuthor>
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("url")]
        public Uri Url { get; internal set; }

        [JsonProperty("projectId")]
        public long ProjectId { get; internal set; }

        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("projectTitleId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProjectTitleId { get; internal set; } = null;

        [JsonProperty("projectTitleTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string ProjectTitleTitle { get; internal set; } = null;

        [JsonProperty("userId")]
        public long UserId { get; internal set; }

        [JsonProperty("twitchId")]
        public long? TwitchId { get; internal set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AddonAuthor);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(this.Id, this.ProjectId, this.UserId)
                .GetHashCode();
        }

        public bool Equals(AddonAuthor other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return this.Id == other.Id
                && this.ProjectId == other.ProjectId
                && this.UserId == other.UserId;
        }
    }
}
