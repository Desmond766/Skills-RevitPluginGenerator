---
kind: property
id: P:Autodesk.Revit.DB.SymbolGeometryId.IsValidObject
source: html/4ca77878-a891-17ec-c869-e5e2e6de7453.htm
---
# Autodesk.Revit.DB.SymbolGeometryId.IsValidObject Property

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

