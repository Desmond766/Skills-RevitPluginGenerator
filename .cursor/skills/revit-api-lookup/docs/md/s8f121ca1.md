---
kind: method
id: M:Autodesk.Revit.DB.PointOnEdgeEdgeIntersection.SetEdgeReference1(Autodesk.Revit.DB.Reference)
source: html/884c5afd-6f2b-8c71-3491-c71264f4c015.htm
---
# Autodesk.Revit.DB.PointOnEdgeEdgeIntersection.SetEdgeReference1 Method

Change the first edge or curve reference.

## Syntax (C#)
```csharp
public void SetEdgeReference1(
	Reference edgeReference
)
```

## Parameters
- **edgeReference** (`Autodesk.Revit.DB.Reference`)

## Remarks
The referenced element may be any model element, including
FamilyInstance, FormElement, or NonPlanarSketch. The reference
must be of type ElementReferenceType.REFERENCE_TYPE_LINEAR,
and it must correspond to a straight line.

