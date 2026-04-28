---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.IsValidGeometry(Autodesk.Revit.DB.Solid)
source: html/bd083561-a6e1-605e-14ce-cfe07598f3f6.htm
---
# Autodesk.Revit.DB.DirectShape.IsValidGeometry Method

Validates geometry to be stored in a DirectShape. Suitable geometry validation is performed. Additionally, the geometry
 must make sense as a shape representation for the category assigned to this DirectShape object.

## Syntax (C#)
```csharp
public bool IsValidGeometry(
	Solid Geom
)
```

## Parameters
- **Geom** (`Autodesk.Revit.DB.Solid`) - GeometryObject to be validated.

## Returns
True if the supplied GeometryObject passes the validation criteria.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

