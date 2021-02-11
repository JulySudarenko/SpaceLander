
namespace SpaceLander
{
    internal interface IForceModel
    {
        float ForceRate { get; }
        float TorqueRate { get; }
    }
}
