---
kind: method
id: M:Autodesk.Revit.DB.PointOnFace.SetFaceReference(Autodesk.Revit.DB.Reference)
source: html/dfc103eb-5ad6-8e9f-d4f0-552287e94dc3.htm
---
# Autodesk.Revit.DB.PointOnFace.SetFaceReference Method

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

