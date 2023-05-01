using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public interface INotifyProperty
{
    event UnityAction<object, string> OnValueChanged;
    void UpdateValue(string fieldName, object value);
    void Bind(VisualElement visualElement);
}

public class UINotifyProperty : INotifyProperty
{
    private Dictionary<string, VisualElement> _bindingPaths = new Dictionary<string, VisualElement>();

    public event UnityAction<object, string> OnValueChanged;
    public List<FieldInfo> Fields = new List<FieldInfo>();
    public List<PropertyInfo> PropertyInfos = new List<PropertyInfo>();

    public virtual void Bind(VisualElement element)
    {
        Fields = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
        PropertyInfos = GetType().GetProperties().ToList();
        _bindingPaths = GetBindingPath(element);

        // permit to affect value to bind element
        PropertyInfos.ForEach(p =>
        {
            p.SetValue(this, p.GetValue(this));
        });
    }

    public virtual void NotifyValueChanged<T>(T newValue, [CallerMemberName] string property = "")
    {
        OnValueChanged?.Invoke(newValue, property);
        ValueChanged(newValue, property);
    }

    private void ValueChanged<T>(T arg0, string arg1)
    {
        if (_bindingPaths.TryGetValue(arg1.ToLower(), out var element))
        {
            if (element is INotifyValueChanged<T> notifElement)
            {
                notifElement.value = arg0;
            }
            else if (element is INotifyValueChanged<string> notifString)
            {
                notifString.value = arg0?.ToString() ?? string.Empty;
            }
        }
    }


    public Dictionary<string, VisualElement> GetBindingPath(VisualElement element, Dictionary<string, VisualElement> dico = null)
    {
        if (dico == null)
        {
            dico = new Dictionary<string, VisualElement>();
        }

        if (element is BindableElement bindElement)
        {
            if (!string.IsNullOrEmpty(bindElement.bindingPath))
            {
                dico.Add(bindElement.bindingPath.ToLower(), bindElement);

                if (Fields.Exists(f => f.Name == bindElement.bindingPath.ToLower()))
                {
                    // we register callback only for matching path, add other callback if you want support other control
                    bindElement.RegisterCallback<ChangeEvent<string>>((val) =>
                    {
                        UpdateValue(bindElement.bindingPath, val.newValue);
                    });

                    bindElement.RegisterCallback<ChangeEvent<bool>>((val) =>
                    {
                        UpdateValue(bindElement.bindingPath, val.newValue);
                    });

                    bindElement.RegisterCallback<ChangeEvent<float>>((val) =>
                    {
                        UpdateValue(bindElement.bindingPath, val.newValue);
                    });

                    bindElement.RegisterCallback<ChangeEvent<int>>((val) =>
                    {
                        UpdateValue(bindElement.bindingPath, val.newValue);
                    });
                }

            }

            if (element.childCount > 0)
            {
                foreach (var subElement in element.Children())
                {
                    GetBindingPath(subElement, dico);
                }
            }
        }
        else
        {
            if (element.childCount > 0)
            {
                foreach (var subElement in element.Children())
                {
                    GetBindingPath(subElement, dico);
                }
            }
        }
        return dico;
    }

    public virtual void UpdateValue(string fieldName, object value)
    {
        var fieldInfo = Fields.FirstOrDefault(f => f.Name == fieldName);

        if (fieldInfo != null)
        {
            if (fieldInfo.FieldType == typeof(int))
                value = int.Parse(value.ToString());

            fieldInfo.SetValue(this, value);
        } 
    }
}