---
kind: method
id: M:Autodesk.Revit.DB.IPerformanceAdviserRule.InitCheck(Autodesk.Revit.DB.Document)
source: html/95d3eaea-5f6e-8e1d-b60d-1669e752e273.htm
---
# Autodesk.Revit.DB.IPerformanceAdviserRule.InitCheck Method

Invoked by performance advisor once in the beginning of the check. If rule checks document as a whole,
 the check can be performed in this method.

## Syntax (C#)
```csharp
void InitCheck(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document for which performance problems are being checked.

