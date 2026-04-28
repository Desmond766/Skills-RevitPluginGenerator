---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MEPNetworkIterator.IsValidObject
source: html/ce3a6821-b5cc-8672-2d22-0c797b61ce75.htm
---
# Autodesk.Revit.DB.Analysis.MEPNetworkIterator.IsValidObject Property

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

