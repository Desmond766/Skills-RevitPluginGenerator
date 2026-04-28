---
kind: method
id: M:Autodesk.Revit.DB.CustomFieldData.ValidateCustomFieldProperties(Autodesk.Revit.DB.ICustomFieldProperties)
source: html/e0298fd1-9ae5-584b-3d5b-aac318d93fd0.htm
---
# Autodesk.Revit.DB.CustomFieldData.ValidateCustomFieldProperties Method

Validates the custom field properties.

## Syntax (C#)
```csharp
public string ValidateCustomFieldProperties(
	ICustomFieldProperties customFieldProperties
)
```

## Parameters
- **customFieldProperties** (`Autodesk.Revit.DB.ICustomFieldProperties`) - An instance of ICustomFieldProperties which represents the properties of this field.

## Returns
If the properties are valid, an empty string will be returned.
 If the properties are not valid, a non-empty string which describes the error will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Can't validate the properties of a CustomFieldData of a SchedulableField (which is not added to a schedule).

