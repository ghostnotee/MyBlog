using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Components;

namespace SharedComponents.Demo.JSInteropSamplesWasm;

public partial class NetToJS : ComponentBase
{
    [JSImport("showAlert", "nettojs")]
    internal static partial string ShowAlert(string message);
}