---
kind: method
id: M:Autodesk.Revit.DB.ElementLevelFilter.#ctor(Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/25e77ada-c927-617e-ccde-fb49ce2b4603.htm
---
# Autodesk.Revit.DB.ElementLevelFilter.#ctor Method

Constructs a new instance of an ElementLevelFilter, with the option to match all elements not associated to the given level id.

## Syntax (C#)
```csharp
public ElementLevelFilter(
	ElementId levelId,
	bool inverted
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of the level that will be matched to elements' associated level.
- **inverted** (`System.Boolean`) - True if the filter should match all elements not associated to the given level.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

