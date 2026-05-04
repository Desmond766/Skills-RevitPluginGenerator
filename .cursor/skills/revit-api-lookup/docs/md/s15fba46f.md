---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstanceFilter.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/62ccd425-3472-37ee-11d6-f8cbd7689187.htm
---
# Autodesk.Revit.DB.FamilyInstanceFilter.#ctor Method

Constructs a new instance of a filter to match family instances of the given family symbol.

## Syntax (C#)
```csharp
public FamilyInstanceFilter(
	Document document,
	ElementId familySymbolId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document. This requirement is unique to this filter and is needed to ensure the input
 family symbol id is valid for the provided document. This ensures the most stability and
 greatest performance for this filter.
- **familySymbolId** (`Autodesk.Revit.DB.ElementId`) - The family symbol id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The familySymbolId does not represent a valid FamilySymbol record in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

