---
kind: property
id: P:Autodesk.Revit.DB.Element.Id
zh: 构件、图元、元素
source: html/9235095b-b7ae-b6e5-6cc2-2b8d397644de.htm
---
# Autodesk.Revit.DB.Element.Id Property

**中文**: 构件、图元、元素

A unique identifier for an Element in an Autodesk Revit project.

## Syntax (C#)
```csharp
public ElementId Id { get; }
```

## Remarks
Returns an object containing the project-wide unique identifier for this Element. The identifier with this id is only unique for the project, it is not unique across separate Autodesk Revit projects.

