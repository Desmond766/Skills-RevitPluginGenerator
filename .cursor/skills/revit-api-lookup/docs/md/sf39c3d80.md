---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.#ctor(Autodesk.Revit.DB.Document,System.Int32)
source: html/4c84b8d4-d0be-2be0-e8c0-558ca4b90229.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.#ctor Method

Create a rebar shape definition with a given number of segments.

## Syntax (C#)
```csharp
public RebarShapeDefinitionBySegments(
	Document doc,
	int numberOfSegments
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document. The definition object is not a part of the document,
 but it will contain references to parameters that are in a document.
 The definition can be used for RebarShape creation only in the
 specified document.
- **numberOfSegments** (`System.Int32`) - The number of segments in the definition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - numberOfSegments must be at least 1.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

