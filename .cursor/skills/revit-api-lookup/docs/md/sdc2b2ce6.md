---
kind: method
id: M:Autodesk.Revit.DB.DividedPath.IsCurveReferenceValid(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/04a861e9-15d3-08bf-0fc6-4e73b4c4b1e1.htm
---
# Autodesk.Revit.DB.DividedPath.IsCurveReferenceValid Method

This returns true if the reference represents a curve or edge that can be used to create a divided path.

## Syntax (C#)
```csharp
public static bool IsCurveReferenceValid(
	Document document,
	Reference curveReference
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **curveReference** (`Autodesk.Revit.DB.Reference`) - The reference.

## Returns
True if the reference can be used to create a divided path, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

