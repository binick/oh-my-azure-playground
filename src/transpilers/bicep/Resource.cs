// See the LICENSE.TXT file in the project root for full license information.

namespace Playgroud.Transpiler.Bicep;

public class Resource
{
    public Resource(params Resource[] dependsOn)
    {
        this.DependsOn = dependsOn;
    }

    public Resource[] DependsOn { get; }
}
