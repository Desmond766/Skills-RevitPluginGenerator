---
kind: property
id: P:Autodesk.Revit.DB.LinePatternSegment.IsValidObject
source: html/c9515e52-ff78-5be0-46d7-8f0897ae3d9d.htm
---
# Autodesk.Revit.DB.LinePatternSegment.IsValidObject Property

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

