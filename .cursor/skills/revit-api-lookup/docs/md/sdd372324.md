---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewReferencePoint(Autodesk.Revit.DB.PointElementReference)
source: html/cb090678-50c1-6ecf-5dae-fc3a49cfbb72.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewReferencePoint Method

Create a reference point on an existing reference in an Autodesk
Revit family document.

## Syntax (C#)
```csharp
public ReferencePoint NewReferencePoint(
	PointElementReference A_0
)
```

## Parameters
- **A_0** (`Autodesk.Revit.DB.PointElementReference`)

## Returns
The newly created ReferencePoint.

## Remarks
The location and coordinate system of the point is
determined by the particular PointReference subclass, and
the point will remain constrained to that
reference.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family is not a Conceptual Mass Family.

