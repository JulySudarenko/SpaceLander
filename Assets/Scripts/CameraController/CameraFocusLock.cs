namespace SpaceLander
{
    internal class CameraFocusLock
    {
        public bool IsUnlock { get; set; }

        public CameraFocusLock(bool isUnlock)
        {
            IsUnlock = isUnlock;
        }
    }
}
