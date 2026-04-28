---
kind: property
id: P:Autodesk.Revit.DB.Analysis.GenericZoneDomainData.IsValidObject
source: html/c7545576-4fad-1f98-fb50-e7c096a10994.htm
---
# Autodesk.Revit.DB.Analysis.GenericZoneDomainData.IsValidObject Property

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

