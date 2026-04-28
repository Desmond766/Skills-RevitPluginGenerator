---
kind: method
id: M:Autodesk.Revit.DB.ElementCategoryFilter.#ctor(Autodesk.Revit.DB.ElementId)
source: html/38887786-b759-772b-1ca1-c3c9b9cf6cf5.htm
---
# Autodesk.Revit.DB.ElementCategoryFilter.#ctor Method

Constructs a new instance of a filter to match elements by category.

## Syntax (C#)
```csharp
public ElementCategoryFilter(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category id to match.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The category was not valid for filtering.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

