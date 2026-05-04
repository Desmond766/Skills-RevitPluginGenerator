---
kind: property
id: P:Autodesk.Revit.DB.WorksharingTooltipInfo.IsValidObject
source: html/57aff666-de47-f628-05a1-09834b42f8ae.htm
---
# Autodesk.Revit.DB.WorksharingTooltipInfo.IsValidObject Property

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

