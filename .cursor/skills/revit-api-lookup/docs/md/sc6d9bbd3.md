---
kind: method
id: M:Autodesk.Revit.DB.Wall.IsWallCrossSectionValid(Autodesk.Revit.DB.WallCrossSection)
zh: 墙、墙体
source: html/3da9a916-d6ca-2f56-b818-4cc60d7252a7.htm
---
# Autodesk.Revit.DB.Wall.IsWallCrossSectionValid Method

**中文**: 墙、墙体

Checks whether the desired cross section is valid for the current wall.

## Syntax (C#)
```csharp
public bool IsWallCrossSectionValid(
	WallCrossSection wallCrossSection
)
```

## Parameters
- **wallCrossSection** (`Autodesk.Revit.DB.WallCrossSection`) - The desired cross section.

## Returns
True if the wall can be set to the desired cross section.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

