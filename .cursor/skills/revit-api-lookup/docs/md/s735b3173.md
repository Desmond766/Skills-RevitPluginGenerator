---
kind: property
id: P:Autodesk.Revit.UI.FilterDialog.IsValidObject
source: html/bb8c1788-732d-f893-6a0f-81e14231d244.htm
---
# Autodesk.Revit.UI.FilterDialog.IsValidObject Property

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

