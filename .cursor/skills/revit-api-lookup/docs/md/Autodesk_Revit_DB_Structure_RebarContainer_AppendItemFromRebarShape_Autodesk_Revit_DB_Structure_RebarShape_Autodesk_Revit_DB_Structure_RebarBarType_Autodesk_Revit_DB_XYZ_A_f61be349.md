---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.AppendItemFromRebarShape(Autodesk.Revit.DB.Structure.RebarShape,Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/292aade1-0459-1a6a-9bd3-715e8bb634df.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.AppendItemFromRebarShape Method

Appends an Item to the RebarContainer. Fills its data on base of the Rebar.

## Syntax (C#)
```csharp
public RebarContainerItem AppendItemFromRebarShape(
	RebarShape rebarShape,
	RebarBarType barType,
	XYZ origin,
	XYZ xVector,
	XYZ yVector
)
```

## Parameters
- **rebarShape** (`Autodesk.Revit.DB.Structure.RebarShape`) - A RebarShape element that defines the shape of the rebar.
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The lower-left corner of the shape's bounding box will be placed at this point in the project.
- **xVector** (`Autodesk.Revit.DB.XYZ`) - The x-axis in the shape definition will be mapped to this direction in the project.
- **yVector** (`Autodesk.Revit.DB.XYZ`) - The y-axis in the shape definition will be mapped to this direction in the project.

## Returns
The Rebar Container Item.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The rebarShape has End Treatments
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - xVector has zero length.
 -or-
 yVector has zero length.

