# Curse
<b>WORK IN PROGRESS</b> .NET Curse Addons Service Wrapper

# Example
You can run Curse.Test to get an example using this library. See result (used minecraft curse mods):
<img src="https://i.imgur.com/eN1vZkx.png" alt="curse test result in console" />

# Usage
Just initialize curse addon service and use:
```cs
using Curse;
using Curse.Entities;

var service = AddonService();
{
  // do stuff with addon service.
  var chisel = await service.GetAddonAsync(235279); // minecraft mod: chisel
  var files = await chisel.GetFilesAsync(); // get addon files by addon instance.
  var chisel_files = await service.GetAddonFilesAsync(235279); // or get addon files by addon service direct.
  var result = await service.SearchAddonsAsync(GameType.Minecraft, search: "extra", maxResults: 5); // you also can search addons
}
service.Dispose(); // optional: dispose service
```