---
kind: method
id: M:Autodesk.Revit.DB.DividedPath.SetIntersectingElements(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/77d59f55-d70a-35b8-aacd-fb66a53223b9.htm
---
# Autodesk.Revit.DB.DividedPath.SetIntersectingElements Method

Set the elements whose intersection with path produces points.

## Syntax (C#)
```csharp
public void SetIntersectingElements(
	ICollection<ElementId> intersectors
)
```

## Parameters
- **intersectors** (`System.Collections.Generic.ICollection < ElementId >`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Not all intersecting elements in intersectors are valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

