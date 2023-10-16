namespace ReSharperPlugin.GuidGenerator;

[ContextAction(
    Group = CSharpContextActions.GroupID,
    Name = nameof(GenerateGuidInstanceContextAction),
    Description = nameof(GenerateGuidInstanceContextAction),
    Priority = -10)]
public class GenerateGuidInstanceContextAction : ContextActionBase
{
    private readonly ICSharpContextActionDataProvider _provider;

    public GenerateGuidInstanceContextAction(ICSharpContextActionDataProvider provider)
    {
        _provider = provider;
    }

    public override string Text => Constants.GuidInstance.Text;
    
    public override bool IsAvailable(IUserDataHolder cache) => _provider.SelectedElement is not null;

    protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
    {
        string textToInsert = Constants.GuidInstance.GeneratedGuid;
        
        return GuidHelper.InsertGuid(_provider, textToInsert);
    }
}