---
kind: method
id: M:Autodesk.Revit.DB.PointOnEdgeFaceIntersection.SetFaceReference(Autodesk.Revit.DB.Reference)
source: html/733b0e11-0444-dd53-1244-1647616a3328.htm
---
# Autodesk.Revit.DB.PointOnEdgeFaceIntersection.SetFaceReference Method

Change the face reference.

## Syntax (C#)
```csharp
public void SetFaceReference(
	Reference reference
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`)

## Remarks
The referenced element may be any model element, including
FamilyInstance or FormElement. The reference
must be of type ElementReferenceType.REFERENCE_TYPE_SURFACE,
and the surface must be of type Plane .
The Reference's UVPoint property is ignored.

