---
kind: method
id: M:Autodesk.Revit.DB.RoutingPreferenceManager.GetSharedSizes(System.Double,Autodesk.Revit.DB.ConnectorProfileType)
source: html/50ed8cf7-4dde-9723-0a99-73a90a6c07c0.htm
---
# Autodesk.Revit.DB.RoutingPreferenceManager.GetSharedSizes Method

Gets a list of all segments of a given profile shape that define a given size.

## Syntax (C#)
```csharp
public IList<ElementId> GetSharedSizes(
	double size,
	ConnectorProfileType shape
)
```

## Parameters
- **size** (`System.Double`) - The size to search for.
- **shape** (`Autodesk.Revit.DB.ConnectorProfileType`) - The profile shape of segment object.

## Returns
A list of all segments that define a given size.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

