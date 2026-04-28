---
kind: method
id: M:Autodesk.Revit.DB.PointOnEdge.SetEdgeReference(Autodesk.Revit.DB.Reference)
source: html/f0efadde-3dbb-468c-6a76-c9970e04ea06.htm
---
# Autodesk.Revit.DB.PointOnEdge.SetEdgeReference Method

Change the edge or curve reference.

## Syntax (C#)
```csharp
public void SetEdgeReference(
	Reference reference
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`)

## Remarks
The referenced element may be any model element, including
FamilyInstance, FormElement, or CurveElement. The reference
must be of type ElementReferenceType.REFERENCE_TYPE_LINEAR.

