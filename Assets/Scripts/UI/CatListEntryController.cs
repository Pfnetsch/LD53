using UnityEngine;
using UnityEngine.UIElements;

public class CatListEntryController
{
    private VisualElement _root;

    public void SetVisualElement(VisualElement visualElement)
    {
        _root = visualElement;
        var infoLabel = _root.Q<Label>("lblInfo");


        // Progressbar styling
        foreach (var pb in _root.Query("unity-progress-bar").Build())
        {
            pb.style.marginBottom = 6;
            pb.style.marginLeft = 3;
            pb.style.marginRight = 3;
        }

        //.unity-progress-bar__progress {
        //background - color: rgb(41, 159, 64);
        infoLabel.RegisterCallback<MouseMoveEvent>(InfoLabelOnMouseMove);
    }

    public void SetCatInformation(Cat cat)
    {
        cat.Bind(_root);

        // ToDo: Set Image
    }

    public void InfoLabelOnMouseMove(MouseMoveEvent mouseMoveEvent)
    {
        Debug.Log("Mouse is on Info Label");
    }

}
