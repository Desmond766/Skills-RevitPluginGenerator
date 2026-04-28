---
kind: method
id: M:Autodesk.Revit.DB.FreeFormElement.UpdateSolidGeometry(Autodesk.Revit.DB.Solid)
source: html/99abedef-afcb-2117-9196-0289668f85bc.htm
---
# Autodesk.Revit.DB.FreeFormElement.UpdateSolidGeometry Method

Updates the geometry of the FreeForm element to the given shape preserving References to the existing geometry where possible (see remarks for rules).

## Syntax (C#)
```csharp
public void UpdateSolidGeometry(
	Solid newGeometry
)
```

## Parameters
- **newGeometry** (`Autodesk.Revit.DB.Solid`) - The new geometry to set in the FreeForm element.

## Remarks
Rules for preserving References:
 First preserve faces as Reference when exclusively coincident with existing faces. Then preserve faces as Reference if exclusively parallel to existing faces. Then preserve faces as Reference if exclusive at small angle to the existing faces. Any other faces are will not be preserved as a Reference. 
 Edges are preserved as References if and only if exclusively bound to faces that are also preserved as References.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

