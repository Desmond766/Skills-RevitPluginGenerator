---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.SetSegmentAs180DegreeBend(System.Int32,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/146fe862-c330-b686-bda5-2cc1a2422eb3.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.SetSegmentAs180DegreeBend Method

Indicate that a segment is a "virtual" segment introduced to describe a 180-degree bend. The radius of the bend will be driven by radiusParam.

## Syntax (C#)
```csharp
public void SetSegmentAs180DegreeBend(
	int iSegment,
	ElementId paramId,
	bool measureToOutsideOfBend
)
```

## Parameters
- **iSegment** (`System.Int32`) - Index of the segment (0 to NumberOfSegments - 1).
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to drive the radius.
 To obtain the id of a shared parameter,
 call RebarShape.GetElementIdForExternalDefinition().
- **measureToOutsideOfBend** (`System.Boolean`) - Choose between two possibilities for the references of the radius dimension.
 If true, measure to the exterior face of the bar. If false, measure to the interior face.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - iSegment is not between 0 and NumberOfSegments.
 -or-
 paramId is not the id of a shared parameter in the current document,
 or its unit type is not UT_Reinforcement_Length or UT_Angle.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

