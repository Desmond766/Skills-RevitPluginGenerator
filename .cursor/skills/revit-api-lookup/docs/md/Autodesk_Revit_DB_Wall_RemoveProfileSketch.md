---
kind: method
id: M:Autodesk.Revit.DB.Wall.RemoveProfileSketch
zh: 墙、墙体
source: html/7bd6782b-b088-9a3e-c5b6-3609c83f0070.htm
---
# Autodesk.Revit.DB.Wall.RemoveProfileSketch Method

**中文**: 墙、墙体

Reverts an edited wall to its original shape.

## Syntax (C#)
```csharp
public void RemoveProfileSketch()
```

## Remarks
The wall profile is changed back to its original rectangular profile. All profile changes made in the sketch mode are discarded.
 To check if wall sketch can be removed call SketchId .

