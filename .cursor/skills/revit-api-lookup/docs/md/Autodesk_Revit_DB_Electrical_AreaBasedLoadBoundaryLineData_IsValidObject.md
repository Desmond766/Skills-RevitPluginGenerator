---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AreaBasedLoadBoundaryLineData.IsValidObject
source: html/267d5009-c07c-cab7-f677-e689961ea637.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadBoundaryLineData.IsValidObject Property

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

