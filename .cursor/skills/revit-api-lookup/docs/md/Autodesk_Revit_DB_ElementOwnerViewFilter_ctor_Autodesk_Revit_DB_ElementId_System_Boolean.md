---
kind: method
id: M:Autodesk.Revit.DB.ElementOwnerViewFilter.#ctor(Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/8e88e85e-eeeb-e71a-e513-90f0716bee19.htm
---
# Autodesk.Revit.DB.ElementOwnerViewFilter.#ctor Method

Constructs a new instance of a filter to match elements which are owned by a particular view,
 with the option to invert the filter and find elements not owned by the given view.

## Syntax (C#)
```csharp
public ElementOwnerViewFilter(
	ElementId viewId,
	bool inverted
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id to match.
 Pass invalid element id to create a filter that will pass non-view-specific elements.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not owned by the given view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

