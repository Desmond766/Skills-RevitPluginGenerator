---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralMaterialTypeFilter.#ctor(Autodesk.Revit.DB.Structure.StructuralMaterialType,System.Boolean)
source: html/eb3b5243-ab7c-e101-73cd-f5e98381e58b.htm
---
# Autodesk.Revit.DB.Structure.StructuralMaterialTypeFilter.#ctor Method

Constructs a new instance of a filter to match family instances by structural material type,
 with the option to match all families which are not of the given structural material type.

## Syntax (C#)
```csharp
public StructuralMaterialTypeFilter(
	StructuralMaterialType structuralMaterialType,
	bool inverted
)
```

## Parameters
- **structuralMaterialType** (`Autodesk.Revit.DB.Structure.StructuralMaterialType`) - The structural material type to match.
- **inverted** (`System.Boolean`) - True if the filter should match all family instances which are not of the given structural material type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

