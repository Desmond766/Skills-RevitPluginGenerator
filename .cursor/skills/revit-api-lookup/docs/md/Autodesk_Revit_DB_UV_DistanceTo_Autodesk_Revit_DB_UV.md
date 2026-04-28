---
kind: method
id: M:Autodesk.Revit.DB.UV.DistanceTo(Autodesk.Revit.DB.UV)
source: html/1b9b02cf-8fca-84b7-d80e-ed4b32277826.htm
---
# Autodesk.Revit.DB.UV.DistanceTo Method

Returns the distance from this 2-D point to the specified 2-D point.

## Syntax (C#)
```csharp
public double DistanceTo(
	UV source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.UV`) - The specified point.

## Returns
The real number equal to the distance between the two points.

## Remarks
The distance between the two points is equal to the length of the vector
that joins the two points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

