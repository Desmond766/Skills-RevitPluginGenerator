---
kind: method
id: M:Autodesk.Revit.DB.DisplacementPath.SetAnchorPoint(Autodesk.Revit.DB.DisplacementElement,Autodesk.Revit.DB.Reference,System.Double)
source: html/5d92709f-6736-b8b9-b31b-68f0af5f8ee1.htm
---
# Autodesk.Revit.DB.DisplacementPath.SetAnchorPoint Method

Sets the reference that determines the origin of this DisplacementPath.

## Syntax (C#)
```csharp
public void SetAnchorPoint(
	DisplacementElement displacementElement,
	Reference reference,
	double param
)
```

## Parameters
- **displacementElement** (`Autodesk.Revit.DB.DisplacementElement`) - The element id of a DisplacementElement.
- **reference** (`Autodesk.Revit.DB.Reference`) - A reference of an edge or a curve in the GRep of the element corresponding to elemId.
- **param** (`System.Double`) - An parameter used to specify a point on the edge.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The value param should lie in the range [0,1].
 -or-
 reference does not represent an edge or curve belonging to an element displaced by displacementElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

