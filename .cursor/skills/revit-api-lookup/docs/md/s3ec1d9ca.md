---
kind: method
id: M:Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.GetElements(Autodesk.Revit.DB.Document)
source: html/aef1d924-fbe9-7909-3cca-4d6fe4042198.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.GetElements Method

Returns set of all analysis display styles elements in the given document.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetElements(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document from which analysis display style elements are retrieved.

## Returns
All analysis display style elements existing in the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

