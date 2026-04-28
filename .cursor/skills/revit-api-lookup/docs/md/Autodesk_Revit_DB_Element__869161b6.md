---
kind: type
id: T:Autodesk.Revit.DB.Element
zh: 构件、图元、元素
source: html/eb16114f-69ea-f4de-0d0d-f7388b105a16.htm
---
# Autodesk.Revit.DB.Element

**中文**: 构件、图元、元素

Base class for most persistent data within a Revit document.

## Syntax (C#)
```csharp
public class Element : IDisposable
```

## Remarks
The data in a Revit document consists primarily of a collection of
 elements. An element usually corresponds to a single component of a
 building or drawing, such as a wall, door, or dimension, but it can
 also be something more abstract, like a wall type or a view.
 Every element in a document has a unique ID, represented by the
 ElementId class.

