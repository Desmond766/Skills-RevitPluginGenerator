---
kind: method
id: M:Autodesk.Revit.DB.BrowserOrganization.AreFiltersSatisfied(Autodesk.Revit.DB.ElementId)
source: html/0e3cabea-8309-3c7b-a684-b1248601cb64.htm
---
# Autodesk.Revit.DB.BrowserOrganization.AreFiltersSatisfied Method

Determines if the given element satisfies the filters defined by the browser organization.

## Syntax (C#)
```csharp
public bool AreFiltersSatisfied(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element to check.

## Returns
True if the given element satisfies the filter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elementId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

