---
kind: method
id: M:Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.IsNameUnique(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle)
source: html/9e28e09e-31d2-fd52-57d7-1c50715a631c.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.IsNameUnique Method

Verify the uniqueness of the name among all analysis display style elements of the document.

## Syntax (C#)
```csharp
public static bool IsNameUnique(
	Document document,
	string name,
	AnalysisDisplayStyle excludedElement
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document in which name uniqueness is verified.
- **name** (`System.String`) - Name to verify uniqueness of.
- **excludedElement** (`Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle`) - Element to be excluded from uniqueness verification (for renaming of an existing element).

## Returns
True if name is unique, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

