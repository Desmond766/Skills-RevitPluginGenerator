---
kind: property
id: P:Autodesk.Revit.DB.Architecture.SiteSubRegion.IsValidObject
source: html/4917e507-b5e5-bfe9-396c-2297b1e6f9d3.htm
---
# Autodesk.Revit.DB.Architecture.SiteSubRegion.IsValidObject Property

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

