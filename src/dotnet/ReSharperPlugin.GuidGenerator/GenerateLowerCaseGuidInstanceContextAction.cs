namespace ReSharperPlugin.GuidGenerator;

[ContextAction(
    Group = CSharpContextActions.GroupID,
    Name = nameof(GenerateLowerCaseGuidInstanceContextAction),
    Description = nameof(GenerateLowerCaseGuidInstanceContextAction),
    Priority = -10)]
public class GenerateLowerCaseGuidInstanceContextAction : ContextActionBase
{
    private readonly ICSharpContextActionDataProvider _provider;

    public GenerateLowerCaseGuidInstanceContextAction(ICSharpContextActionDataProvider provider)
    {
        _provider = provider;
    }

    public override string Text => Constants.LowerCase.InstanceText;
    
    public override bool IsAvailable(IUserDataHolder cache) => _provider.SelectedElement is not null;
    
    protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
    {
        Guid generatedGuid = Guid.NewGuid();
        string textToInsert = $"var lowerCaseGuid = new Guid(\"{generatedGuid}\");";
        
        return GuidHelper.InsertGuid(_provider, textToInsert);
    }
}