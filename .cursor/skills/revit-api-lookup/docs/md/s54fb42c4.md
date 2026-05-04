---
kind: method
id: M:Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.GetRouteAnalysisSettings(Autodesk.Revit.DB.Document)
source: html/1bf0d99c-6255-441d-4019-cffc35bfde33.htm
---
# Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.GetRouteAnalysisSettings Method

Returns the RouteAnalysisSettings element for a given document.

## Syntax (C#)
```csharp
public static RouteAnalysisSettings GetRouteAnalysisSettings(
	Document cda
)
```

## Parameters
- **cda** (`Autodesk.Revit.DB.Document`) - The document for which to get the RouteAnalysisSettings element.

## Returns
Returns the RouteAnalysisSettings element in project documents
 or Nothing nullptr a null reference ( Nothing in Visual Basic) for family documents .

## Remarks
Project documents have a RouteAnalysisSettings element, one per document.
 Family documents do not have RouteAnalysisSettings elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

