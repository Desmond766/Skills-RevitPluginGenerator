---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewReferencePoint(Autodesk.Revit.DB.Transform)
source: html/c93b3173-1f70-be86-c4dc-4195de2e66a2.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewReferencePoint Method

Create a reference point at a given location and with a given
coordinate system in an Autodesk Revit family document.

## Syntax (C#)
```csharp
public ReferencePoint NewReferencePoint(
	Transform A_0
)
```

## Parameters
- **A_0** (`Autodesk.Revit.DB.Transform`)

## Returns
The newly created ReferencePoint.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family is not a Conceptual Mass Family.

