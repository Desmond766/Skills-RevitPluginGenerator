---
kind: method
id: M:Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.FindByName(Autodesk.Revit.DB.Document,System.String)
source: html/f83830e4-d802-a189-7e1f-9402d71e971d.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.FindByName Method

Finds analysis display style by name.

## Syntax (C#)
```csharp
public static ElementId FindByName(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document in which to look for analysis display style element.
- **name** (`System.String`) - Name of analysis display style to look for.

## Returns
Element id of the found analysis display style, invalidElementId if not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

