using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public VisualTreeAsset CatEntryTemplate;

    public UIDocument ShelterUI;

    private UIDocument _mainUI;
    private ListView _listViewCats;
    private ProgressBar _clockProgressBar;
    private Button _shelterButton;

    private List<Cat> _cats;

    private void OnEnable()
    {
        _mainUI = GetComponent<UIDocument>();

        if (_mainUI == null) Debug.LogError("Main UI not found!");

        _listViewCats = _mainUI.rootVisualElement.Q("CenterList") as ListView;

        _clockProgressBar = _mainUI.rootVisualElement.Q("ClockProgressBar") as ProgressBar;
        _clockProgressBar.highValue = Global.SecondsOfDay;

        _shelterButton = _mainUI.rootVisualElement.Q("ShelterButton") as Button;

        _shelterButton.RegisterCallback<ClickEvent>(OnShelterButtonClick);
    }

    // Start is called before the first frame update
    void Start()
    {
        Func<VisualElement> makeItem = () =>
        {
            // Instantiate the UXML template for the entry
            var newListEntry = CatEntryTemplate.Instantiate();

            // Instantiate a controller for the data
            var newListEntryLogic = new CatListEntryController();

            // Assign the controller script to the visual element
            newListEntry.userData = newListEntryLogic;

            // Initialize the controller script
            newListEntryLogic.SetVisualElement(newListEntry);

            // Return the root of the instantiated visual tree
            return newListEntry;
        };

        // As the user scrolls through the list, the ListView object
        // will recycle elements created by the "makeItem"
        // and invoke the "bindItem" callback to associate
        // the element with the matching data item (specified as an index in the list)
        Action<VisualElement, int> bindItem = (item, idx) =>
        {
            ((item.userData) as CatListEntryController).SetCatInformation(_cats[idx]);
        };

        _listViewCats.makeItem = makeItem;
        _listViewCats.bindItem = bindItem;
        _listViewCats.fixedItemHeight = 120;
        _listViewCats.selectionType = SelectionType.Multiple;

        // Callback invoked when the user changes the selection inside the ListView
        _listViewCats.onSelectionChange += objects => Debug.Log("Item selected: " + objects.FirstOrDefault());

        FillCatList();
    }

    // Update is called once per frame
    void Update()
    {
        _clockProgressBar.value = Global.SecondsOfDay - Timer.TimeRemaining;
    }

    public void FillCatList()
    {
        _cats = DeliveryManager.Instance.CatForce;

        _listViewCats.itemsSource = _cats;
    }

    public void OnShelterButtonClick(ClickEvent evt)
    {
        ShelterUI.enabled = true;
        // get ShelterCats from Shelter
    }
}
