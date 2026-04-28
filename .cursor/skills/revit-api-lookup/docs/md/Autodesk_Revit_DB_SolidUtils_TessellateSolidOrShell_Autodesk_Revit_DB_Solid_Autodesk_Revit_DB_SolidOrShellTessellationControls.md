---
kind: method
id: M:Autodesk.Revit.DB.SolidUtils.TessellateSolidOrShell(Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.SolidOrShellTessellationControls)
source: html/d856e5f0-2e26-f01a-2996-9fbc0ad1c03e.htm
---
# Autodesk.Revit.DB.SolidUtils.TessellateSolidOrShell Method

This function facets (i.e., triangulates) a solid or an open shell. Each boundary
 component of the solid or shell is represented by a single triangulated structure.

## Syntax (C#)
```csharp
public static TriangulatedSolidOrShell TessellateSolidOrShell(
	Solid solidOrShell,
	SolidOrShellTessellationControls tessellationControls
)
```

## Parameters
- **solidOrShell** (`Autodesk.Revit.DB.Solid`) - The solid or shell to be faceted.
- **tessellationControls** (`Autodesk.Revit.DB.SolidOrShellTessellationControls`) - This input controls various aspects of the triangulation.

## Returns
The triangulated structures corresponding to the boundary components of the
 input solid or the components of the input shell.

## Remarks
Every point on the triangulation of a boundary component of the solid (or
 shell) should lie within the 3D distance specified by the "accuracy" input of some
 point on the triangulation, and vice-versa. In some cases, this constraint may be
 implemented heuristically (not rigorously).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - solidOrShell is not valid for triangulation (for example, it contains no faces).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to triangulate the solid or shell.

