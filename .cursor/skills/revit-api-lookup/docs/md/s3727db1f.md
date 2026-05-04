---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.AlignPartByInsertionPointAndCutInToStraight(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,System.Double,System.Double,System.Boolean)
source: html/6f1e6d1b-1e90-dfd1-7991-e49ed098ac80.htm
---
# Autodesk.Revit.DB.FabricationPart.AlignPartByInsertionPointAndCutInToStraight Method

Align the part by its insertion point to a point and rotation on a straight. This will automatically size and connect the part being cut into, if possible.

## Syntax (C#)
```csharp
public static bool AlignPartByInsertionPointAndCutInToStraight(
	Document document,
	ElementId straightId,
	ElementId partId,
	XYZ position,
	double rotation,
	double slope,
	bool flip
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **straightId** (`Autodesk.Revit.DB.ElementId`) - The element identifier of the straight to be cut in to.
- **partId** (`Autodesk.Revit.DB.ElementId`) - The element identifier of the part to align and cut in with.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position to move the parts insertion point to.
- **rotation** (`System.Double`) - The rotation in radians.
- **slope** (`System.Double`) - The slope value to flex to match if possible in fractional units (eg.1/50). Positive values are up, negative are down. Slopes can only be applied
 to fittings, whilst straights will inherit the slope from the piece it is connecting to.
- **flip** (`System.Boolean`) - Flip the part to allow for flow direction.

## Returns
True if the alignment succeeds, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element is not a fabrication part.
 -or-
 Not all of the fabrication part's connectors are open.
 -or-
 The part is not a straight.
 -or-
 The fabrication parts do not have matching domain types.
 -or-
 The position is not on the straight.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to align the part to the straight to cut in to.

