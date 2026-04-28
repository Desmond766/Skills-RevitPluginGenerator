---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.AlignPartByInsertionPoint(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,System.Double,System.Double,System.Double,Autodesk.Revit.DB.Fabrication.FabricationPartJustification,Autodesk.Revit.DB.Transform)
source: html/3c9ba970-9fa8-914e-07a2-7918b52f5df0.htm
---
# Autodesk.Revit.DB.FabricationPart.AlignPartByInsertionPoint Method

Align the part by its insertion point to a point and rotation in free space.

## Syntax (C#)
```csharp
public static bool AlignPartByInsertionPoint(
	Document document,
	ElementId partId,
	XYZ position,
	double rotation,
	double rotationPerpendicular,
	double slope,
	FabricationPartJustification justification,
	Transform trf
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **partId** (`Autodesk.Revit.DB.ElementId`) - The element identifier of the part to align.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position to move the part's insertion point to.
- **rotation** (`System.Double`) - The rotation in radians.
- **rotationPerpendicular** (`System.Double`) - The perpendicular rotation for free placement around the Y axis direction of connection - angle in radians.
- **slope** (`System.Double`) - The slope value to flex to match if possible in fractional units (eg.1/50). Positive values are up, negative are down. Slopes can only be applied
 to fittings, whilst straights will inherit the slope from the piece it is connecting to.
- **justification** (`Autodesk.Revit.DB.Fabrication.FabricationPartJustification`) - The justification to align eccentric parts.
- **trf** (`Autodesk.Revit.DB.Transform`) - Optional alignment transformation matrix, eg. a Trf that describes plan or side elevation.

## Returns
True if the alignment succeeds, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element is not a fabrication part.
 -or-
 Not all of the fabrication part's connectors are open.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

