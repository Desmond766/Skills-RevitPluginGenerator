---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralWallUsageFilter.#ctor(Autodesk.Revit.DB.Structure.StructuralWallUsage,System.Boolean)
source: html/d8bf114a-b8c8-48ca-1123-8a469c006b22.htm
---
# Autodesk.Revit.DB.Structure.StructuralWallUsageFilter.#ctor Method

Constructs a new instance of a filter to match walls that have the given structural wall usage,
 with the option to match all walls which are not of the given structural wall usage.

## Syntax (C#)
```csharp
public StructuralWallUsageFilter(
	StructuralWallUsage structuralWallUsage,
	bool inverted
)
```

## Parameters
- **structuralWallUsage** (`Autodesk.Revit.DB.Structure.StructuralWallUsage`) - The structural usage to match.
- **inverted** (`System.Boolean`) - True if the filter should match all walls which are not of the given structural wall usage.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

