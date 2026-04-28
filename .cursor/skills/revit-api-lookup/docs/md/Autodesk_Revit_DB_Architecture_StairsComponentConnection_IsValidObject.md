---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsComponentConnection.IsValidObject
source: html/02aaeff8-f0be-6a2d-9b6b-ecea5a6dce2b.htm
---
# Autodesk.Revit.DB.Architecture.StairsComponentConnection.IsValidObject Property

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

