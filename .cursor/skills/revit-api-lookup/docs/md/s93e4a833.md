---
kind: method
id: M:Autodesk.Revit.DB.CustomFieldData.SetCustomFieldProperties(Autodesk.Revit.DB.ICustomFieldProperties)
source: html/a13a0167-411a-3507-99e5-cca3f44d4feb.htm
---
# Autodesk.Revit.DB.CustomFieldData.SetCustomFieldProperties Method

Sets an instance of ICustomFieldProperties which represents the properties of this field.

## Syntax (C#)
```csharp
public void SetCustomFieldProperties(
	ICustomFieldProperties customFieldProperties
)
```

## Parameters
- **customFieldProperties** (`Autodesk.Revit.DB.ICustomFieldProperties`) - An instance of ICustomFieldProperties which represents the properties of this field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input properties are not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Can't set the properties to a CustomFieldData of a SchedulableField (which is not added to a schedule).

