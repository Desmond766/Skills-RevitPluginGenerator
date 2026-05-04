---
kind: method
id: M:Autodesk.Revit.DB.CustomFieldData.GetCustomFieldProperties
source: html/9de9b290-c9f0-167c-ed37-952704c046c6.htm
---
# Autodesk.Revit.DB.CustomFieldData.GetCustomFieldProperties Method

Gets an instance of ICustomFieldProperties which represents the properties of this field.

## Syntax (C#)
```csharp
public ICustomFieldProperties GetCustomFieldProperties()
```

## Returns
Returns an instance of ICustomFieldProperties .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Can't obtain the properties from a CustomFieldData of a SchedulableField (which is not added to a schedule).

