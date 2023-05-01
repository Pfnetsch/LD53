using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class ShelterUI : MonoBehaviour
{
    public VisualTreeAsset ShelterCatEntryTemplate;

    private UIDocument _shelterUI;
    private ListView _listViewShelterCats;
    private Button _shelterBackButton;
    private Button _shelterGetCatButton;

    private Cat _selectedShelterCat;


    private void OnEnable()
    {
        _shelterUI = GetComponent<UIDocument>();

        if (_shelterUI == null) Debug.LogError("Main UI not found!");

        _listViewShelterCats = _shelterUI.rootVisualElement.Q("ShelterCatsListView") as ListView;

        // Back
        _shelterBackButton = _shelterUI.rootVisualElement.Q("ShelterBackButton") as Button;
        _shelterBackButton.RegisterCallback<ClickEvent>(OnShelterBackButtonClick);

        // Get Cat
        _shelterGetCatButton = _shelterUI.rootVisualElement.Q("GetCatButton") as Button;
        _shelterGetCatButton.RegisterCallback<ClickEvent>(OnGetCatButtonClick);
    }

    void Start()
    {
        Func<VisualElement> makeItem = () =>
        {
            // Instantiate the UXML template for the entry
            var newListEntry = ShelterCatEntryTemplate.Instantiate();

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
            ((item.userData) as CatListEntryController).SetCatInformation(Shelter.Instance.ShelterCats[idx]);
        };

        _listViewShelterCats.makeItem = makeItem;
        _listViewShelterCats.bindItem = bindItem;
        _listViewShelterCats.fixedItemHeight = 120;
        _listViewShelterCats.selectionType = SelectionType.Multiple;

        // Callback invoked when the user changes the selection inside the ListView
        _listViewShelterCats.onSelectionChange += objects => {
            Cat cat = objects.FirstOrDefault() as Cat;
            Debug.Log("Item selected: " + cat);
            _selectedShelterCat = cat;
            };

        FillShelterCatList();
    }

    public void FillShelterCatList()
    {
        _listViewShelterCats.itemsSource = Shelter.Instance.ShelterCats;
    }

    public void OnShelterBackButtonClick(ClickEvent evt)
    {
        _shelterUI.enabled = false;
    }

    public void OnGetCatButtonClick(ClickEvent evt)
    {
        if (_selectedShelterCat != null && DeliveryManager.Instance.Money >= _selectedShelterCat.Price)
        {
            DeliveryManager.Instance.Money -= _selectedShelterCat.Price;

            DeliveryManager.Instance.CatForce.Add(_selectedShelterCat);

            Shelter.Instance.ShelterCats.Remove(_selectedShelterCat);
            _selectedShelterCat = null;

            Debug.Log("bought Kittyyyyy");
        }
    }
}
