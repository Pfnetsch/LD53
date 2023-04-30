using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class CatListEntryController
{
    private VisualElement _root;
    private Label _catNameLabel;
    private Label _catInfoLabel;
    private VisualElement _avatar;

    public void SetVisualElement(VisualElement visualElement)
    {
        _root = visualElement;
        _catNameLabel = _root.Q<Label>("CatName");
        _catInfoLabel = _root.Q<Label>("CatInfo");
        _avatar = _root.Q<Image>("Avatar");
    }

    public void SetCatInformation(Cat cat)
    {
        cat.Bind(_root);
        //_catNameLabel.text = cat.Name;
        // ToDo: Set Image
        _avatar.style.backgroundImage = new StyleBackground(cat.Picture);
    }

}
