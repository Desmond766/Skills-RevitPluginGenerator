---
kind: method
id: M:Autodesk.Revit.DB.ProjectLocation.IsProjectLocationNameUnique(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.ElementId)
source: html/dc6a464b-1334-67c2-c28a-b42895f0094c.htm
---
# Autodesk.Revit.DB.ProjectLocation.IsProjectLocationNameUnique Method

Verifies that there is no existing ProjectLocation with the given name belonging to the given SiteLocation.

## Syntax (C#)
```csharp
public static bool IsProjectLocationNameUnique(
	Document document,
	string name,
	ElementId siteLocationId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to check.
- **name** (`System.String`) - The name to check.
- **siteLocationId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the SiteLocation which the ProjectLocation belongs to.

## Returns
True if the name is unused (among ProjectLocations). False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

