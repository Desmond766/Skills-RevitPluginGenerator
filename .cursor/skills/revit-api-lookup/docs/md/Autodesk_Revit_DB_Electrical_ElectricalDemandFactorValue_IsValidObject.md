---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalDemandFactorValue.IsValidObject
source: html/465e9430-d821-1e45-f561-7dc659bb6fd1.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalDemandFactorValue.IsValidObject Property

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

