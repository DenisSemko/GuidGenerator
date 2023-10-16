namespace ReSharperPlugin.GuidGenerator.Helpers;

public class GuidHelper
{
    public static Action<ITextControl> InsertGuid(ICSharpContextActionDataProvider provider, string textToInsert)
    {
        ICSharpTypeDeclaration typeDeclaration = provider.GetSelectedElement<ICSharpTypeDeclaration>();
        if (typeDeclaration is null)
            return null;

        return textControl =>
        {
            int caretOffset = provider.CaretOffset;
            
            using (WriteLockCookie.Create())
            {
                textControl.Document.InsertText(caretOffset, textToInsert);
                textControl.Caret.MoveTo(caretOffset + textToInsert.Length, CaretVisualPlacement.DontScrollIfVisible);
            }
        };
    }
}