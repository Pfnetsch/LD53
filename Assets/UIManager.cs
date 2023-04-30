using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    UIDocument _mainUI;
    ListView _listViewCats;

    private void OnEnable()
    {
        _mainUI = GetComponent<UIDocument>();

        if (_mainUI == null) Debug.LogError("Main UI not found!");

        _listViewCats = _mainUI.rootVisualElement.Q("CenterList") as ListView;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Create a list of data. In this case, numbers from 1 to 1000.
        const int itemCount = 10;
        var items = new List<string>(itemCount);
        for (int i = 1; i <= itemCount; i++)
            items.Add(i.ToString());

        Func<VisualElement> makeItem = () => new Label();

        // As the user scrolls through the list, the ListView object
        // will recycle elements created by the "makeItem"
        // and invoke the "bindItem" callback to associate
        // the element with the matching data item (specified as an index in the list)
        Action<VisualElement, int> bindItem = (e, i) => (e as Label).text = items[i];

        Debug.Log("Generate Items for ListView");

        _listViewCats.makeItem = makeItem;
        _listViewCats.bindItem = bindItem;
        _listViewCats.itemsSource = items;
        _listViewCats.selectionType = SelectionType.Multiple;

        // Callback invoked when the user changes the selection inside the ListView
        _listViewCats.onSelectionChange += objects => Debug.Log("Item selected" + objects.FirstOrDefault());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
