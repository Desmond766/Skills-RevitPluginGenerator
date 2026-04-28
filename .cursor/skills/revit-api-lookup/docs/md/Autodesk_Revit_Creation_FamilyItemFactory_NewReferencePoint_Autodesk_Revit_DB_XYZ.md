---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewReferencePoint(Autodesk.Revit.DB.XYZ)
source: html/cf203384-8a37-d5ef-0129-426451b1410b.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewReferencePoint Method

Create a reference point at a given location in an Autodesk
Revit family document.

## Syntax (C#)
```csharp
public ReferencePoint NewReferencePoint(
	XYZ A_0
)
```

## Parameters
- **A_0** (`Autodesk.Revit.DB.XYZ`)

## Returns
The newly created ReferencePoint.

## Remarks
The ReferencePoint will have a default coordinate system
corresponding to the global coordinate system.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family is not a Conceptual Mass Family.

