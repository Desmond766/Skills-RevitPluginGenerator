---
kind: method
id: M:Autodesk.Revit.DB.PointOnEdgeEdgeIntersection.SetEdgeReference2(Autodesk.Revit.DB.Reference)
source: html/5e051ab3-d588-6f89-b08d-6e3805dc539d.htm
---
# Autodesk.Revit.DB.PointOnEdgeEdgeIntersection.SetEdgeReference2 Method

Change the second edge or curve reference.

## Syntax (C#)
```csharp
public void SetEdgeReference2(
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

