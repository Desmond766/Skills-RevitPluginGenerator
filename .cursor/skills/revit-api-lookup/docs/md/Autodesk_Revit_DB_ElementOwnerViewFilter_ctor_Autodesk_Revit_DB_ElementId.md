---
kind: method
id: M:Autodesk.Revit.DB.ElementOwnerViewFilter.#ctor(Autodesk.Revit.DB.ElementId)
source: html/154a3c37-b6b8-7e40-1027-8fd883a311a9.htm
---
# Autodesk.Revit.DB.ElementOwnerViewFilter.#ctor Method

Constructs a new instance of a filter to match elements which are owned by a particular view.

## Syntax (C#)
```csharp
public ElementOwnerViewFilter(
	ElementId viewId
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id to match.
 Pass invalid element id to create a filter that will pass non-view-specific elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

