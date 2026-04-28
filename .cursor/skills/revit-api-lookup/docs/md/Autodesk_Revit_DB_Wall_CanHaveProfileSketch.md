---
kind: method
id: M:Autodesk.Revit.DB.Wall.CanHaveProfileSketch
zh: 墙、墙体
source: html/63ddfb69-5168-af0a-224c-4608ddd2352c.htm
---
# Autodesk.Revit.DB.Wall.CanHaveProfileSketch Method

**中文**: 墙、墙体

Checks whether this wall has or can have a profile sketch.

## Syntax (C#)
```csharp
public bool CanHaveProfileSketch()
```

## Returns
True if wall supports profile sketch, false otherwise.

## Remarks
Wall does not support profile if it is not a straight wall; or wall is tapered;
 or it is an old curtain wall; or it is an infill wall; or it is a replacement curtain panel.

