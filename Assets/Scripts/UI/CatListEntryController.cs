using UnityEngine.UIElements;

public class CatListEntryController
{
    Label _catName;

    public void SetVisualElement(VisualElement visualElement)
    {
        _catName = visualElement.Q<Label>("CatName");
    }

    public void SetCatInformation(Cat cat)
    {
        _catName.text = cat.Name;
    }

}
