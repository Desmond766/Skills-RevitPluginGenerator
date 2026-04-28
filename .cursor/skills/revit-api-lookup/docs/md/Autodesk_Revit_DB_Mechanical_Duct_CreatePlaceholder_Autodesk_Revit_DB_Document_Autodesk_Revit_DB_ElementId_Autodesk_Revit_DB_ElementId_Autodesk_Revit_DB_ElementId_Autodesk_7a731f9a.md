---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Duct.CreatePlaceholder(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 风管
source: html/17cfec44-7070-eae5-d5d9-d6105fc793f5.htm
---
# Autodesk.Revit.DB.Mechanical.Duct.CreatePlaceholder Method

**中文**: 风管

Creates a new placeholder duct.

## Syntax (C#)
```csharp
public static Duct CreatePlaceholder(
	Document document,
	ElementId systemTypeId,
	ElementId ductTypeId,
	ElementId levelId,
	XYZ startPoint,
	XYZ endPoint
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **systemTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the HVAC system type.
- **ductTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the duct type.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level id for the duct.
- **startPoint** (`Autodesk.Revit.DB.XYZ`) - The first point of the placeholder line.
- **endPoint** (`Autodesk.Revit.DB.XYZ`) - The second point of the placeholder line.

## Returns
The created placeholder duct.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The systemTypeId is not valid HVAC system type.
 -or-
 The duct type ductTypeId is not valid duct type.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The points of startPoint and endPoint are too close: for MEPCurve, the minimum length is 1/10 inch.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

