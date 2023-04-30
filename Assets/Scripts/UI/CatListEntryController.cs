using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class CatListEntryController
{
    private Label _catNameLabel;
    private Label _catInfoLabel;

    public void SetVisualElement(VisualElement visualElement)
    {
        _catNameLabel = visualElement.Q<Label>("CatName");
        _catInfoLabel = visualElement.Q<Label>("CatInfo");
    }

    public void SetCatInformation(Cat cat)
    {
        _catNameLabel.text = cat.Name;
    }

}
