---
kind: property
id: P:Autodesk.Revit.DB.ExternallyTaggedNonBReps.IsValidObject
source: html/d3a7c795-bb17-51b8-4600-907247f9d7d2.htm
---
# Autodesk.Revit.DB.ExternallyTaggedNonBReps.IsValidObject Property

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

