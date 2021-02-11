namespace SpaceLander
{
    internal interface IHitListener
    {
        ILandingAssessmentViewModel LandingAssessment { get; }
        ICrashAssessmentViewModel CrashAssessment { get; }
    }
}
