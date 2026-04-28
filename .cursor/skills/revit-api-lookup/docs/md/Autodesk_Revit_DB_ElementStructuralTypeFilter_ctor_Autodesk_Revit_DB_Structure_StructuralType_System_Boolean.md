---
kind: method
id: M:Autodesk.Revit.DB.ElementStructuralTypeFilter.#ctor(Autodesk.Revit.DB.Structure.StructuralType,System.Boolean)
source: html/876de239-2d95-ca9f-1f04-be9596f583fa.htm
---
# Autodesk.Revit.DB.ElementStructuralTypeFilter.#ctor Method

Constructs a new instance of a filter to match elements by structural type, with the option to match all elements which are of the given structural type.

## Syntax (C#)
```csharp
public ElementStructuralTypeFilter(
	StructuralType structuralType,
	bool inverted
)
```

## Parameters
- **structuralType** (`Autodesk.Revit.DB.Structure.StructuralType`) - The structural type to match.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not of the given structural type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

