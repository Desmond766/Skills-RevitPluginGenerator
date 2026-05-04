---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.IsValidObject
source: html/10995542-a5ca-2b22-6f3e-5453fbb77fba.htm
---
# Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.IsValidObject Property

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

