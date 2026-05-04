---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.AddAssociation(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId},System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/10346e59-62d7-7fb3-9451-2a72a12dd118.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.AddAssociation Method

Adds a new association between a group of analytical elements and a group of physical elements.

## Syntax (C#)
```csharp
public void AddAssociation(
	ISet<ElementId> analyticalElementIds,
	ISet<ElementId> physicalElementIds
)
```

## Parameters
- **analyticalElementIds** (`System.Collections.Generic.ISet < ElementId >`) - Ids of the analytical elements.
- **physicalElementIds** (`System.Collections.Generic.ISet < ElementId >`) - Ids of the physical elements.

## Remarks
The arguments must be ids of analytical and of physical elements that don't have other associations, otherwise an exception is thrown.
 Physical elements can have one of these categories:
 Columns Curtain Wall Panels Floors Generic Models Mass Parts Railings Ramps Roofs Stairs Structural Columns Structural Foundation Structural Framing Structural Trusses Structural Beam System Walls 
 Analytical elements can have one of these categories:
 Analytical Member Analytical Panel

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Analytical id is not valid or has already defined another association.
 -or-
 Physical id is not valid or has already defined another association.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

