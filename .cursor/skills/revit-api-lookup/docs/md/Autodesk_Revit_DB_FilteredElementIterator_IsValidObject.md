---
kind: property
id: P:Autodesk.Revit.DB.FilteredElementIterator.IsValidObject
source: html/158123f6-d43c-8f64-a685-b30a6e471f13.htm
---
# Autodesk.Revit.DB.FilteredElementIterator.IsValidObject Property

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

