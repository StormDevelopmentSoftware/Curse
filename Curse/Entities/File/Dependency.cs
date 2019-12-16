using Newtonsoft.Json;

namespace Curse.Entities.File
{
    public partial class Dependency
    {
        [JsonProperty("addonId")]
        public long AddonId { get; internal set; }

        [JsonProperty("type")]
        public int Type { get; internal set; } // maybe? FileType?
    }
}
