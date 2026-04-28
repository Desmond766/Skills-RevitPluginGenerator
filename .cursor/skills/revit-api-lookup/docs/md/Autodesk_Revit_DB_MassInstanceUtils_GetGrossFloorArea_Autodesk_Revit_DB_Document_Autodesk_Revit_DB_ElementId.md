---
kind: method
id: M:Autodesk.Revit.DB.MassInstanceUtils.GetGrossFloorArea(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/4786d496-d8ae-0336-42c9-7febaeeac4c1.htm
---
# Autodesk.Revit.DB.MassInstanceUtils.GetGrossFloorArea Method

Get the total occupiable floor area represented by a mass instance.

## Syntax (C#)
```csharp
public static double GetGrossFloorArea(
	Document document,
	ElementId massInstanceId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **massInstanceId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the mass instance.

## Returns
The gross floor area in square feet.

## Remarks
The area is computed from the cross sections that are created by intersecting the
 associated Levels with the mass instance Geometry.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId massInstanceId is not a mass instance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

