---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.GetElementFilterFromRule(Autodesk.Revit.DB.PerformanceAdviserRuleId,Autodesk.Revit.DB.Document)
source: html/00d71deb-c805-5def-2205-87e20bd5de07.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.GetElementFilterFromRule Method

Retrieves a filter to restrict elements to be checked.

## Syntax (C#)
```csharp
public ElementFilter GetElementFilterFromRule(
	PerformanceAdviserRuleId id,
	Document document
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.PerformanceAdviserRuleId`) - The rule id to get information for.
- **document** (`Autodesk.Revit.DB.Document`) - Document for which performance problems are being checked.

## Returns
The filter to restrict elements to be checked.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

