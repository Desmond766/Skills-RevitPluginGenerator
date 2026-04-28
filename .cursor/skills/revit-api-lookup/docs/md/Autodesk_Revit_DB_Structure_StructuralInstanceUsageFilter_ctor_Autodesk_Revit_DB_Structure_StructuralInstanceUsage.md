---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralInstanceUsageFilter.#ctor(Autodesk.Revit.DB.Structure.StructuralInstanceUsage)
source: html/f3785343-c384-6d4b-440c-1f1c9bcc75b7.htm
---
# Autodesk.Revit.DB.Structure.StructuralInstanceUsageFilter.#ctor Method

Constructs a new instance of a filter to match structural family instances (typically columns, beams, or braces) of the given structural usage.

## Syntax (C#)
```csharp
public StructuralInstanceUsageFilter(
	StructuralInstanceUsage structuralUsage
)
```

## Parameters
- **structuralUsage** (`Autodesk.Revit.DB.Structure.StructuralInstanceUsage`) - The family instance structural usage.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

