---
kind: method
id: M:Autodesk.Revit.DB.ElevationMarker.CreateElevationMarker(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,System.Int32)
source: html/2f707487-817c-d648-4b99-559f9000f123.htm
---
# Autodesk.Revit.DB.ElevationMarker.CreateElevationMarker Method

Creates a new ElevationMarker.

## Syntax (C#)
```csharp
public static ElevationMarker CreateElevationMarker(
	Document document,
	ElementId viewFamilyTypeId,
	XYZ origin,
	int initialViewScale
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new ElevationMarker will be added.
- **viewFamilyTypeId** (`Autodesk.Revit.DB.ElementId`) - This ViewFamilyType will be used by all elevations hosted on the new ElevationMarker.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The desired origin for the ElevationMarker.
- **initialViewScale** (`System.Int32`) - This view scale will be automatically applied to new elevations created on the ElevationMarker.
 The scale is the ratio of true model size to paper size.

## Returns
The new ElevationMarker.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This view family type is not appropriate for ElevationMarkers.
 -or-
 The denominator X of the view scale 1/X must be in the range 1 to 24,000.
 -or-
 Elevation view creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

