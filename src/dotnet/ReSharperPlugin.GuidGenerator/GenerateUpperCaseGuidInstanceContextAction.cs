namespace ReSharperPlugin.GuidGenerator;

[ContextAction(
    Group = CSharpContextActions.GroupID,
    Name = nameof(GenerateUpperCaseGuidInstanceContextAction),
    Description = nameof(GenerateUpperCaseGuidInstanceContextAction),
    Priority = -10)]
public class GenerateUpperCaseGuidInstanceContextAction : ContextActionBase
{
    private readonly ICSharpContextActionDataProvider _provider;

    public GenerateUpperCaseGuidInstanceContextAction(ICSharpContextActionDataProvider provider)
    {
        _provider = provider;
    }

    public override string Text => Constants.UpperCase.InstanceText;
    
    public override bool IsAvailable(IUserDataHolder cache) => _provider.SelectedElement is not null;
    
    protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
    {
        string generatedGuid = Guid.NewGuid().ToString().ToUpper();
        string textToInsert = $"var upperCaseGuid = new Guid(\"{generatedGuid}\");";
        
        return GuidHelper.InsertGuid(_provider, textToInsert);
    }
}