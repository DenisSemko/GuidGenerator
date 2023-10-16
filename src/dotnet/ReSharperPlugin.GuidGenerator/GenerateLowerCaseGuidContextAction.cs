namespace ReSharperPlugin.GuidGenerator;

[ContextAction(
    Group = CSharpContextActions.GroupID,
    Name = nameof(GenerateLowerCaseGuidContextAction),
    Description = nameof(GenerateLowerCaseGuidContextAction),
    Priority = -10)]
public class GenerateLowerCaseGuidContextAction : ContextActionBase
{
    private readonly ICSharpContextActionDataProvider _provider;

    public GenerateLowerCaseGuidContextAction(ICSharpContextActionDataProvider provider)
    {
        _provider = provider;
    }

    public override string Text => Constants.LowerCase.Text;
    
    public override bool IsAvailable(IUserDataHolder cache) => _provider.SelectedElement is not null;
    
    protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
    {
        Guid generatedGuid = Guid.NewGuid();
        string textToInsert = $"\"{generatedGuid}\";";

        return GuidHelper.InsertGuid(_provider, textToInsert);
    }
}