---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalMember.SetReleaseType(System.Boolean,Autodesk.Revit.DB.Structure.ReleaseType)
source: html/41b94d8b-c36b-d3bf-f76e-56e66ea3b19a.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.SetReleaseType Method

Sets the release type.

## Syntax (C#)
```csharp
public void SetReleaseType(
	bool start,
	ReleaseType releaseType
)
```

## Parameters
- **start** (`System.Boolean`) - The position on Analytical Member element. True for start, false for end.
- **releaseType** (`Autodesk.Revit.DB.Structure.ReleaseType`) - The type of release.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

