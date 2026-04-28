---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalElement.IsValidSelector(Autodesk.Revit.DB.Structure.AnalyticalModelSelector)
source: html/9b076f25-113f-2c09-d63b-2d2a68082c9b.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalElement.IsValidSelector Method

Indicates if the input selector is valid for the Analytical Element.

## Syntax (C#)
```csharp
public bool IsValidSelector(
	AnalyticalModelSelector selector
)
```

## Parameters
- **selector** (`Autodesk.Revit.DB.Structure.AnalyticalModelSelector`) - Portion of the Analytical Element geometry.

## Returns
True if selector is valid for this Analytical Element, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

