---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeParameters.GetAllRebarShapeParameters(Autodesk.Revit.DB.Document)
source: html/235f6abc-17cc-f541-6b5a-cd8e3d895527.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeParameters.GetAllRebarShapeParameters Method

List all shape parameters used by all the existing RebarShapes in the specified document.

## Syntax (C#)
```csharp
public static IList<ElementId> GetAllRebarShapeParameters(
	Document doc
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
ElementIds corresponding to the external parameters.

## Remarks
This method replaces RebarShape.GetAllRebarShapeParameters() from prior releases.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

