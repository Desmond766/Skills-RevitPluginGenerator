---
kind: property
id: P:Autodesk.Revit.DB.Element.Location
zh: 构件、图元、元素
source: html/89438f4f-7e15-835a-0c66-d6adbc8dd00c.htm
---
# Autodesk.Revit.DB.Element.Location Property

**中文**: 构件、图元、元素

This property is used to find the physical location of an element within a project.

## Syntax (C#)
```csharp
public virtual Location Location { get; }
```

## Remarks
The Location property returns an object that can be used to find the location of an object
within the project. An object may have a point location, such as a table or may have a line location.
A wall is an example of an element that has a line location.

