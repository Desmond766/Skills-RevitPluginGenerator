---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralInstanceUsageFilter.#ctor(Autodesk.Revit.DB.Structure.StructuralInstanceUsage,System.Boolean)
source: html/bb575ce2-5911-c72c-a012-0475f75abd01.htm
---
# Autodesk.Revit.DB.Structure.StructuralInstanceUsageFilter.#ctor Method

Constructs a new instance of a filter to match family instances by structural usage,
 with the option to match all family instances which are not of the given structural usage.

## Syntax (C#)
```csharp
public StructuralInstanceUsageFilter(
	StructuralInstanceUsage structuralUsage,
	bool inverted
)
```

## Parameters
- **structuralUsage** (`Autodesk.Revit.DB.Structure.StructuralInstanceUsage`) - The structural usage to match.
- **inverted** (`System.Boolean`) - True if the filter should match all family instances which are not of the given structural usage.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

