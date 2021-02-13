namespace SpaceLander
{
    internal interface IHitListener : IInitialize, ICleanup
    {
        ILandingAssessmentViewModel LandingAssessment { get; }
        ICrashAssessmentViewModel CrashAssessment { get; }
    }
}
