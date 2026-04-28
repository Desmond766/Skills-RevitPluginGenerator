---
kind: type
id: T:Autodesk.Revit.DB.ElementId
source: html/44f3f7b1-3229-3404-93c9-dc5e70337dd6.htm
---
# Autodesk.Revit.DB.ElementId

The ElementId object is used as a unique identification for an element within a
single project.

## Syntax (C#)
```csharp
public class ElementId
```

## Remarks
The Value within the ElementId is only unique with a single project. It is not unique
across several projects. The Id can be used to retrieve a specific element from the database
when needed. However ids are subject to change during an Autodesk Revit session and as such
should not be retained and used across repeated calls to external commands. If a manner is
needed to uniquely identify an element beyond this limitation then a shared parameter should
be added to the element containing a unique identifier managed by the external application.

