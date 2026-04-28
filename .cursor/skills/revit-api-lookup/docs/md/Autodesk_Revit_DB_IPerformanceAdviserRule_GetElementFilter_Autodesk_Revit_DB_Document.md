---
kind: method
id: M:Autodesk.Revit.DB.IPerformanceAdviserRule.GetElementFilter(Autodesk.Revit.DB.Document)
source: html/748d52b4-e49e-0820-a8dc-6d3b48bf37fc.htm
---
# Autodesk.Revit.DB.IPerformanceAdviserRule.GetElementFilter Method

Retrieves a filter to restrict elements to be checked.

## Syntax (C#)
```csharp
ElementFilter GetElementFilter(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document for which performance problems are being checked.

## Returns
The filter to restrict elements to be checked.

## Remarks
If the rule needs to be executed on individual elements,
 it should return a filter that defines what elements the rule should apply to.
 Otherwise, nothing (i.e. null) should be returned.
 If filter is returned, it should stay valid till the end of the check.

