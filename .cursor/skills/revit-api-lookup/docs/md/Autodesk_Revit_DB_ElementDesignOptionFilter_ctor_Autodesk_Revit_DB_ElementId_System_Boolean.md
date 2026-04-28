---
kind: method
id: M:Autodesk.Revit.DB.ElementDesignOptionFilter.#ctor(Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/25fd54ac-aeb2-3b73-fee8-150b849e9819.htm
---
# Autodesk.Revit.DB.ElementDesignOptionFilter.#ctor Method

Constructs a new instance of a filter to match elements contained within a particular design option, with the option to invert the filter and find elements not contained within a particular design option.

## Syntax (C#)
```csharp
public ElementDesignOptionFilter(
	ElementId designOptionId,
	bool inverted
)
```

## Parameters
- **designOptionId** (`Autodesk.Revit.DB.ElementId`) - The design option id to match.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not contained within a particular design option.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

