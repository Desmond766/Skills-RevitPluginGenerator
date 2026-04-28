---
kind: method
id: M:Autodesk.Revit.DB.IPerformanceAdviserRule.ExecuteElementCheck(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element)
source: html/483e0369-c3cf-285e-33be-eee4582b483a.htm
---
# Autodesk.Revit.DB.IPerformanceAdviserRule.ExecuteElementCheck Method

Invoked by performance advisor for each element to be checked.

## Syntax (C#)
```csharp
void ExecuteElementCheck(
	Document document,
	Element element
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document for which performance problems are being checked.
- **element** (`Autodesk.Revit.DB.Element`) - The Element being checked for performance problems.

