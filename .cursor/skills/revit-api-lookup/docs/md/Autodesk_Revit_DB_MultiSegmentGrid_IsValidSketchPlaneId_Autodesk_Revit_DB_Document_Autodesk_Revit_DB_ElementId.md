---
kind: method
id: M:Autodesk.Revit.DB.MultiSegmentGrid.IsValidSketchPlaneId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/aa463929-733e-8831-3075-a34e3fe12bcf.htm
---
# Autodesk.Revit.DB.MultiSegmentGrid.IsValidSketchPlaneId Method

Identifies whether provided element id corresponds to a SketchPlane that is valid for GridChain creation.

## Syntax (C#)
```csharp
public static bool IsValidSketchPlaneId(
	Document document,
	ElementId elemId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elemId** (`Autodesk.Revit.DB.ElementId`) - Element id.

## Returns
True if elemId is the element id of a horizontal SketchPlane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

