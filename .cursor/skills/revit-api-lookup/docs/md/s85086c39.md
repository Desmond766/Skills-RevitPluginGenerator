---
kind: method
id: M:Autodesk.Revit.DB.PartMaker.SetSourceElementIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/0a9379ea-9d8e-1380-e69b-a259c09608cc.htm
---
# Autodesk.Revit.DB.PartMaker.SetSourceElementIds Method

Set the source elements for the PartMaker.

## Syntax (C#)
```csharp
public void SetSourceElementIds(
	ICollection<ElementId> sourceElementIds
)
```

## Parameters
- **sourceElementIds** (`System.Collections.Generic.ICollection < ElementId >`) - Elements to be the sources for this PartMaker.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not permitted to be a source for this PartMaker
 Elements should be Parts that have no PartMaker yet
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

