---
kind: method
id: M:Autodesk.Revit.DB.IFC.ImporterIFCUtils.UpdateDirectShapeCategory(Autodesk.Revit.DB.DirectShape,Autodesk.Revit.DB.ElementId)
source: html/f7f5e7a4-8200-8ef8-c769-f68ab86d3886.htm
---
# Autodesk.Revit.DB.IFC.ImporterIFCUtils.UpdateDirectShapeCategory Method

Updates the category of a DirectShape.

## Syntax (C#)
```csharp
public static void UpdateDirectShapeCategory(
	DirectShape directShape,
	ElementId newCategoryId
)
```

## Parameters
- **directShape** (`Autodesk.Revit.DB.DirectShape`) - The DirectShape.
- **newCategoryId** (`Autodesk.Revit.DB.ElementId`) - The new category id.

## Remarks
Use this function carefully, as it could result in a mismatch between DirectShape
 and DirectShapeType categories.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

