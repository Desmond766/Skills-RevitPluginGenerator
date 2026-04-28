---
kind: property
id: P:Autodesk.Revit.DB.ViewNode.LevelOfDetail
source: html/d98987f3-27a6-1893-3b7d-fc28e8ed5322.htm
---
# Autodesk.Revit.DB.ViewNode.LevelOfDetail Property

The level of detail the view is going to be rendered at.

## Syntax (C#)
```csharp
public int LevelOfDetail { get; set; }
```

## Remarks
The value is an integer number in range of [0,15] (inclusive),
 or a value {-1}. If the value is positive, Revit will use the
 suggested level of detail when tessellating faces; otherwise it will
 use its default algorithm, which is based on output resolution.
If an explicit level of detail is requested (i.e. a positive value),
 using a value close to the middle of the valid range yields a very
 reasonable tessellation. Revit uses level 8 as its 'normal' LoD.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The level of detail is not in valid range.
 It must be a number between -1 and 15, all inclusive.

