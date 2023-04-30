using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class CatListEntryController
{
    private VisualElement _root;

    private Label _catNameLabel;


    public void SetVisualElement(VisualElement visualElement)
    {
        _root = visualElement;
        _catNameLabel = _root.Q<Label>("CatName");

        foreach (var pb in _root.Query("unity-progress-bar").Build())
        {
            pb.style.marginBottom = 6;
            pb.style.marginLeft = 3;
            pb.style.marginRight = 3;
        }

        //.unity-progress-bar__progress {
        //background - color: rgb(41, 159, 64);
    }

    public void SetCatInformation(Cat cat)
    {
        cat.Bind(_root);
        //_catNameLabel.text = cat.Name;
        // ToDo: Set Image
    }

}
