---
kind: property
id: P:Autodesk.Revit.DB.SolidOrShellTessellationControls.LevelOfDetail
source: html/c7975423-7bec-c45d-f0a1-e4edb8d82657.htm
---
# Autodesk.Revit.DB.SolidOrShellTessellationControls.LevelOfDetail Property

An number between 0 and 1 (inclusive) specifying the level of detail for the triangulation of a solid or shell.

## Syntax (C#)
```csharp
public double LevelOfDetail { get; set; }
```

## Remarks
Smaller values yield coarser triangulations (fewer triangles), while larger values yield finer
 triangulations (more triangles).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for levelOfDetail must lie between 0 and 1 (inclusive).

