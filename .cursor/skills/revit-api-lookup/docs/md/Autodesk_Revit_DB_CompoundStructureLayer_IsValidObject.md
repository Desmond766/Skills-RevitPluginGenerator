---
kind: property
id: P:Autodesk.Revit.DB.CompoundStructureLayer.IsValidObject
source: html/90612f1e-66d2-9b7f-5f69-9306e04e3cc6.htm
---
# Autodesk.Revit.DB.CompoundStructureLayer.IsValidObject Property

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

