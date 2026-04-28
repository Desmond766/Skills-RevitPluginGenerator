---
kind: method
id: M:Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.SetName(System.String)
source: html/1df4c7d0-2a04-4a22-4e88-0d50b9c54169.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.SetName Method

Set name of analysis display style element.

## Syntax (C#)
```csharp
public void SetName(
	string name
)
```

## Parameters
- **name** (`System.String`) - Analysis display style element name to be set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is not unique in document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

