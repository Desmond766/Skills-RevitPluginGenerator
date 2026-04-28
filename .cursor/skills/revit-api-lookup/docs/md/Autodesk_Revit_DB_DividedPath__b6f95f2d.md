---
kind: type
id: T:Autodesk.Revit.DB.DividedPath
source: html/8043b21a-7c78-e0cb-f7b3-495ace05de87.htm
---
# Autodesk.Revit.DB.DividedPath

An element that consists of a set of points distributed along a path which consists of a connected set of curves and edges.

## Syntax (C#)
```csharp
public class DividedPath : Element
```

## Remarks
The points can be the result of a uniform distribution along the path.
 The type of the distribution is determined by a selected 'layout'.
 The distance between the layout points depends on the path, the layout, and layout specific settings.
 In addition, points can also be the result of intersecting the path with other elements.

