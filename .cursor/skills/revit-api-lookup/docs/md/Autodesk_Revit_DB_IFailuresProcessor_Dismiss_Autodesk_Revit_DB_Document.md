---
kind: method
id: M:Autodesk.Revit.DB.IFailuresProcessor.Dismiss(Autodesk.Revit.DB.Document)
source: html/349ad9c7-2b61-0324-d8d0-6c1647cbe7a0.htm
---
# Autodesk.Revit.DB.IFailuresProcessor.Dismiss Method

This method is being called in case of exception or document destruction to dismiss any possible pending failure UI that may
 have left on the screen

## Syntax (C#)
```csharp
void Dismiss(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document for which pending failures processing UI should be dismissed

