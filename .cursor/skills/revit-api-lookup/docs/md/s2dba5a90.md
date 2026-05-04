---
kind: method
id: M:Autodesk.Revit.DB.WireframeBuilder.ValidatePoint(Autodesk.Revit.DB.Point)
source: html/f1c9fba9-45a1-4a31-468c-473ae5c3af24.htm
---
# Autodesk.Revit.DB.WireframeBuilder.ValidatePoint Method

Validates the point object to be added to the wireframe shape being constructed. Used by AddPoint() to validate input.

## Syntax (C#)
```csharp
public static bool ValidatePoint(
	Point GPoint
)
```

## Parameters
- **GPoint** (`Autodesk.Revit.DB.Point`) - Point object to be validated.

## Returns
True is %GPoint% is acceptable as a part of a wireframe shape representation being built.

## Remarks
This function may be used to pre-validate the geometry being added to avoid an exception from AddPoint().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

