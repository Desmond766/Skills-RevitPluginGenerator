---
kind: method
id: M:Autodesk.Revit.DB.WorksetKindFilter.#ctor(Autodesk.Revit.DB.WorksetKind,System.Boolean)
source: html/ae184f33-6f34-9d8b-4027-5ee29ce072e7.htm
---
# Autodesk.Revit.DB.WorksetKindFilter.#ctor Method

Constructs a new instance of WorksetKindFilter filter to match worksets of the given WorksetKind.

## Syntax (C#)
```csharp
public WorksetKindFilter(
	WorksetKind worksetKind,
	bool inverted
)
```

## Parameters
- **worksetKind** (`Autodesk.Revit.DB.WorksetKind`) - The WorksetKind to match.
- **inverted** (`System.Boolean`) - True if the filter should match all worksets which are not of the given WorksetKind.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

