---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalLinkType.IsValidAnalyticalFixityState(Autodesk.Revit.DB.Structure.AnalyticalFixityState)
source: html/49803380-c8d1-d503-1693-84e0bde29735.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalLinkType.IsValidAnalyticalFixityState Method

Returns whether the input fixity state is valid for Analytical Link Type parameters.

## Syntax (C#)
```csharp
public static bool IsValidAnalyticalFixityState(
	AnalyticalFixityState fixityState
)
```

## Parameters
- **fixityState** (`Autodesk.Revit.DB.Structure.AnalyticalFixityState`) - The fixity state value to check.

## Returns
True if valid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

