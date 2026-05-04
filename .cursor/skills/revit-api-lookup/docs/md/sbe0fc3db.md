---
kind: method
id: M:Autodesk.Revit.DB.Segment.RemoveSize(System.Double)
source: html/1dc1704c-73f6-e44d-e11e-1c91d6b1af76.htm
---
# Autodesk.Revit.DB.Segment.RemoveSize Method

Remove the existing MEPSize with this nominal diameter from the segment.

## Syntax (C#)
```csharp
public void RemoveSize(
	double nominalDiameter
)
```

## Parameters
- **nominalDiameter** (`System.Double`) - The nominal diameter of the size.

## Remarks
Does nothing if there is no existing MEPSize with this nominal diameter.

## Exceptions
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The last size of the segment cannot be removed.

