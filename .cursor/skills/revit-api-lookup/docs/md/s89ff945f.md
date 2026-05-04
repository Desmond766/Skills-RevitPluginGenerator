---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.AddAssociation(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/99f09bfb-736a-901f-f22d-1f64baab8243.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.AddAssociation Method

Adds a new association between an analytical element and a physical element.

## Syntax (C#)
```csharp
public void AddAssociation(
	ElementId analyticalElementId,
	ElementId physicalElementId
)
```

## Parameters
- **analyticalElementId** (`Autodesk.Revit.DB.ElementId`) - Id of the analytical element.
- **physicalElementId** (`Autodesk.Revit.DB.ElementId`) - Id of the physical element.

## Remarks
The arguments must be ids of an analytical and of a physical element that don't have other associations, otherwise an exception is thrown.
 Physical element can have one of these categories:
 Columns Curtain Wall Panels Floors Generic Models Mass Parts Railings Ramps Roofs Stairs Structural Columns Structural Foundation Structural Framing Structural Trusses Structural Beam System Walls 
 Analytical element can have one of these categories:
 Analytical Member Analytical Panel

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Analytical id is not valid or has already defined another association.
 -or-
 Physical id is not valid or has already defined another association.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

