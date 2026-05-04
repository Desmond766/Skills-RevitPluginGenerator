---
kind: method
id: M:Autodesk.Revit.DB.LogicalAndFilter.#ctor(Autodesk.Revit.DB.ElementFilter,Autodesk.Revit.DB.ElementFilter)
source: html/f7d7e9ae-8ace-77dd-69c2-e82580849bf2.htm
---
# Autodesk.Revit.DB.LogicalAndFilter.#ctor Method

Constructs a new instance of the logical filter with two input filters.

## Syntax (C#)
```csharp
public LogicalAndFilter(
	ElementFilter filter1,
	ElementFilter filter2
)
```

## Parameters
- **filter1** (`Autodesk.Revit.DB.ElementFilter`) - The first filter.
- **filter2** (`Autodesk.Revit.DB.ElementFilter`) - The second filter.

## Remarks
The input filters will be copied.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

