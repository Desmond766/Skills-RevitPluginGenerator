---
kind: method
id: M:Autodesk.Revit.DB.Structure.FamilyStructuralMaterialTypeFilter.#ctor(Autodesk.Revit.DB.Structure.StructuralMaterialType,System.Boolean)
source: html/a42f5839-930f-1eb4-ea78-52f34f7d1b9b.htm
---
# Autodesk.Revit.DB.Structure.FamilyStructuralMaterialTypeFilter.#ctor Method

Constructs a new instance of a filter to match families by structural material type,
 with the option to match all families which are not of the given structural material type.

## Syntax (C#)
```csharp
public FamilyStructuralMaterialTypeFilter(
	StructuralMaterialType structuralMaterialType,
	bool inverted
)
```

## Parameters
- **structuralMaterialType** (`Autodesk.Revit.DB.Structure.StructuralMaterialType`) - The structural material type to match.
- **inverted** (`System.Boolean`) - True if the filter should match all families which are not of the given structural material type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

