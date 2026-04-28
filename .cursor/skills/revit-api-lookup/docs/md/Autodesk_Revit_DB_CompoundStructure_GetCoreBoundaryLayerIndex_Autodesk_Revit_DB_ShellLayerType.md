---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetCoreBoundaryLayerIndex(Autodesk.Revit.DB.ShellLayerType)
source: html/33a4b0ce-7694-bf4f-81a0-a8b66fa3cade.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetCoreBoundaryLayerIndex Method

Returns the index of the layer just below the core boundary.

## Syntax (C#)
```csharp
public int GetCoreBoundaryLayerIndex(
	ShellLayerType shellLayerType
)
```

## Parameters
- **shellLayerType** (`Autodesk.Revit.DB.ShellLayerType`) - If ShellLayerType.Exterior return the index on the exterior side (or top side for a roof, floor, or ceiling type).
 If ShellLayerType.Interior return the index on the interior side (or bottom side for a roof, floor, or ceiling type).

## Returns
The index of the layer.

## Remarks
-1 returned if there is no such a layer. You can change the shell/core layer boundary
 using SetNumberOfShellLayers(ShellLayerType, Int32) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

