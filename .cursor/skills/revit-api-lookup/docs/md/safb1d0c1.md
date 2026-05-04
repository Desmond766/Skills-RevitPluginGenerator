---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.GetElementFilterFromRule(System.Int32,Autodesk.Revit.DB.Document)
source: html/43950427-5e16-19e5-5c5b-96786094eeaa.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.GetElementFilterFromRule Method

Retrieves a filter to restrict elements to be checked.

## Syntax (C#)
```csharp
public ElementFilter GetElementFilterFromRule(
	int index,
	Document document
)
```

## Parameters
- **index** (`System.Int32`) - The rule index to get information for.
- **document** (`Autodesk.Revit.DB.Document`) - Document for which performance problems are being checked.

## Returns
The filter to restrict elements to be checked.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

