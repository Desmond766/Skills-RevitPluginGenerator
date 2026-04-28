---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MEPAnalyticalSegment.IsValidObject
source: html/a037f686-806c-7f76-7fc0-872cdb3b607b.htm
---
# Autodesk.Revit.DB.Analysis.MEPAnalyticalSegment.IsValidObject Property

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

