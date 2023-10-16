namespace ReSharperPlugin.GuidGenerator.Helpers;

public class Constants
{
    private const string ProjectName = "GuidGenerator";

    public class GuidInstance
    {
        public const string Text = $"{ProjectName}: Add new GUID object";
        public const string GeneratedGuid = "Guid.NewGuid();";
    }

    public class UpperCase
    {
        public const string Text = $"{ProjectName}: Add new Upper Case Guid";
        public const string InstanceText = $"{ProjectName}: Add new Upper Case Guid Instance";
    }

    public class LowerCase
    {
        public const string Text = $"{ProjectName}: Add new Lower Case Guid";
        public const string InstanceText = $"{ProjectName}: Add new Lower Case Guid Instance";
    }
}