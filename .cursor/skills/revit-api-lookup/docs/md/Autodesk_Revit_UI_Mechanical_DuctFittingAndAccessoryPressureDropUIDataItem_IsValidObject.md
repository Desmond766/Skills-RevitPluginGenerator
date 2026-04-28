---
kind: property
id: P:Autodesk.Revit.UI.Mechanical.DuctFittingAndAccessoryPressureDropUIDataItem.IsValidObject
source: html/a3bfc0e9-1aee-d297-5e26-fa1bf0c10a3b.htm
---
# Autodesk.Revit.UI.Mechanical.DuctFittingAndAccessoryPressureDropUIDataItem.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

