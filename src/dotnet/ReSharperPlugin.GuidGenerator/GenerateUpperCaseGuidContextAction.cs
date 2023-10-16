namespace ReSharperPlugin.GuidGenerator;

[ContextAction(
    Group = CSharpContextActions.GroupID,
    Name = nameof(GenerateUpperCaseGuidContextAction),
    Description = nameof(GenerateUpperCaseGuidContextAction),
    Priority = -10)]
public class GenerateUpperCaseGuidContextAction : ContextActionBase
{
    private readonly ICSharpContextActionDataProvider _provider;

    public GenerateUpperCaseGuidContextAction(ICSharpContextActionDataProvider provider)
    {
        _provider = provider;
    }

    public override string Text => Constants.UpperCase.Text;
    
    public override bool IsAvailable(IUserDataHolder cache) => _provider.SelectedElement is not null;
    
    protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
    {
        string generatedGuid = Guid.NewGuid().ToString().ToUpper();
        string textToInsert = $"\"{generatedGuid}\";";
        
        return GuidHelper.InsertGuid(_provider, textToInsert);
    }
}