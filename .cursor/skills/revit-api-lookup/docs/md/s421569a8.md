---
kind: method
id: M:Autodesk.Revit.DB.PointOnEdgeFaceIntersection.SetEdgeReference(Autodesk.Revit.DB.Reference)
source: html/6d4ac155-c9b0-7a66-fba9-808c8bde9f01.htm
---
# Autodesk.Revit.DB.PointOnEdgeFaceIntersection.SetEdgeReference Method

Change the edge or curve reference.

## Syntax (C#)
```csharp
public void SetEdgeReference(
	Reference edgeReference
)
```

## Parameters
- **edgeReference** (`Autodesk.Revit.DB.Reference`)

## Remarks
The referenced element may be any model element, including
FamilyInstance, FormElement, or CurveElement. The reference
must be of type ElementReferenceType.REFERENCE_TYPE_LINEAR.

