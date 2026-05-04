---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddConstraintParallelToSegment(System.Int32,Autodesk.Revit.DB.ElementId,System.Boolean,System.Boolean)
source: html/c244128f-c910-c1f7-982d-dd01a5584557.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddConstraintParallelToSegment Method

Constrain the length of a segment by parameterizing its length.

## Syntax (C#)
```csharp
public void AddConstraintParallelToSegment(
	int iSegment,
	ElementId paramId,
	bool measureToOutsideOfBend0,
	bool measureToOutsideOfBend1
)
```

## Parameters
- **iSegment** (`System.Int32`) - Index of the segment (0 to NumberOfSegments - 1).
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to drive the constraint. To obtain the id of a shared parameter,
 call RebarShape.GetElementIdForExternalDefinition().
- **measureToOutsideOfBend0** (`System.Boolean`) - Choose between two possibilities for the first reference of the length dimension. If false, the reference is at the point where the bend begins; equivalently, at the projection of the bend centerpoint onto the segment. If true, the reference is moved outward by a distance equal to the bend radius plus the bar diameter; if the bend is a right angle or greater, this is equivalent to putting the reference at the outer face of the bend.
- **measureToOutsideOfBend1** (`System.Boolean`) - Choose between two possibilities for the second reference of the length dimension.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - iSegment is not between 0 and NumberOfSegments.
 -or-
 paramId is not the id of a shared parameter in the current document,
 or its unit type is not UT_Reinforcement_Length or UT_Angle.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

