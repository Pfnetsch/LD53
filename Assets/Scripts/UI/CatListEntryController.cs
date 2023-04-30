using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class CatListEntryController
{
    private VisualElement _root;
    private Label _catNameLabel;
    private Label _catInfoLabel;

    public void SetVisualElement(VisualElement visualElement)
    {
        _root = visualElement;
        _catNameLabel = _root.Q<Label>("CatName");
        _catInfoLabel = _root.Q<Label>("CatInfo");
    }

    public void SetCatInformation(Cat cat)
    {
        cat.Bind(_root);
        //_catNameLabel.text = cat.Name;
    }

}
