---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MEPAnalyticalNode.IsValidObject
source: html/1bcb7875-85c7-e5d0-79b2-e85a2a3f780a.htm
---
# Autodesk.Revit.DB.Analysis.MEPAnalyticalNode.IsValidObject Property

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

