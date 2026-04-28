---
kind: method
id: M:Autodesk.Revit.DB.EvaluatedParameter.AsValueString(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FormatOptions)
source: html/42579358-98a0-6008-3ec7-873f03baaac8.htm
---
# Autodesk.Revit.DB.EvaluatedParameter.AsValueString Method

Get the parameter value as a string with units.

## Syntax (C#)
```csharp
public string AsValueString(
	Document doc,
	FormatOptions options
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document to be used to obtain information about the parameter.
- **options** (`Autodesk.Revit.DB.FormatOptions`) - Options for formatting the string.

## Returns
The string that represents the parameter value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

