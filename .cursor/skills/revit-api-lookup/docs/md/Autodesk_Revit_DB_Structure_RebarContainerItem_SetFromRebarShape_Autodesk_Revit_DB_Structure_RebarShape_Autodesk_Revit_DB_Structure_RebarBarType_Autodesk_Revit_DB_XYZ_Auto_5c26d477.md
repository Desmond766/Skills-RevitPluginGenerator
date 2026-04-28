---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.SetFromRebarShape(Autodesk.Revit.DB.Structure.RebarShape,Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/2fef9f31-7da8-ffa8-c01d-a16e553e2167.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.SetFromRebarShape Method

Set an instance of a RebarContainerItem element, as an instance of a RebarShape.
 The instance will have the default shape parameters from the RebarShape,
 and its location is based on the bounding box of the shape in the shape definition.
 Hooks are removed from the shape before computing its bounding box.
 If appropriate hooks can be found in the document, they will be assigned arbitrarily.

## Syntax (C#)
```csharp
public void SetFromRebarShape(
	RebarShape rebarShape,
	RebarBarType barType,
	XYZ origin,
	XYZ xVec,
	XYZ yVec
)
```

## Parameters
- **rebarShape** (`Autodesk.Revit.DB.Structure.RebarShape`) - A RebarShape element that defines the shape of the rebar.
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The lower-left corner of the shape's bounding box will be placed at this point in the project.
- **xVec** (`Autodesk.Revit.DB.XYZ`) - The x-axis in the shape definition will be mapped to this direction in the project.
- **yVec** (`Autodesk.Revit.DB.XYZ`) - The y-axis in the shape definition will be mapped to this direction in the project.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The rebarShape has End Treatments
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - xVec has zero length.
 -or-
 yVec has zero length.

