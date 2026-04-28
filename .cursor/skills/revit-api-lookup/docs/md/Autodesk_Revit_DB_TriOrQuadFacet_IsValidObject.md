---
kind: property
id: P:Autodesk.Revit.DB.TriOrQuadFacet.IsValidObject
source: html/c742eef4-8b6f-a71f-e87b-0a06b7758338.htm
---
# Autodesk.Revit.DB.TriOrQuadFacet.IsValidObject Property

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

