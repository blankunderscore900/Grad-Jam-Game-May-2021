using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

public class CheckpointAware : MonoBehaviour {
    private delegate void SaveData(object target, object value);
    private delegate object GetData(object target);


    private class SavedDataState {

        public readonly Component component;
        private readonly string item_name; // For debugging
        private readonly SaveData save;
        private readonly GetData get;
        public object value;
        
        public SavedDataState(Component _component, PropertyInfo _property, object _value) {
            Debug.Log($"Creating entry for \"{_component.gameObject.name}'s\" property \"{_property.Name}\" with default value of \"{_value}\"");
            component = _component;
            item_name = _property.Name;
            save = _property.SetValue;
            get = _property.GetValue;
            value = _value;
        }

        public SavedDataState(Component _component, FieldInfo _field, object _value) {
            Debug.Log($"Creating entry for \"{_component.gameObject.name}'s\" field \"{_field.Name}\" with default value of \"{_value}\"");
            component = _component;
            item_name = _field.Name;
            save = _field.SetValue;
            get = _field.GetValue;
            value = _value;
        }

        public void Update() {
            Debug.Log($"Updating \"{component.gameObject.name}'s\" \"{item_name}\" from previous value of \"{value}\" to value of \"{get(component)}\"");
            value = get(component);
        }

        public void Restore() {
            Debug.Log($"Restoring \"{component.gameObject.name}'s\" \"{item_name}\" from existing value of \"{get(component)}\" to new value of \"{value}\"");
            save(component, value);
        }
    }

    private List<SavedDataState> state_data;

    private void Save() {
        foreach (SavedDataState state in state_data) state.Update();
    }

    private void Restore() {
        foreach (SavedDataState state in state_data) state.Restore();
    }

    private void Start() {
        var component_types = gameObject
            .GetComponents<Component>()
            .Select(component => (component, component.GetType()));

        var properties = component_types
            .SelectMany(data => data
                .Item2
                .GetProperties()
                .Where(property => Attribute.IsDefined(property, typeof(SavedValue)))
                .Select(property => new SavedDataState(data.component, property, property.GetValue(data.component)))
            );

        var fields = component_types
            .SelectMany(data => data
                .Item2
                .GetFields()
                .Where(field => Attribute.IsDefined(field, typeof(SavedValue)))
                .Select(field => new SavedDataState(data.component, field, field.GetValue(data.component)))
            );

        state_data = properties.Union(fields).ToList();

        var transform = gameObject.transform;
        state_data.Add(new SavedDataState(transform, transform.GetType().GetProperty("position"), transform.position));
    }

    private void OnEnable() {
        CheckpointManager.OnSave += Save;
        CheckpointManager.OnRestore += Restore;
    }

    private void OnDisable() {
        CheckpointManager.OnSave -= Save;
        CheckpointManager.OnRestore -= Restore;
    }
}
