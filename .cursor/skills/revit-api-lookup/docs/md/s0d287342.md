---
kind: method
id: M:Autodesk.Revit.DB.PDFExportOptions.SetNamingRule(System.Collections.Generic.IList{Autodesk.Revit.DB.TableCellCombinedParameterData})
source: html/87d53eae-bd18-3ff0-e5e6-38de5a018cdf.htm
---
# Autodesk.Revit.DB.PDFExportOptions.SetNamingRule Method

Sets the naming rule.

## Syntax (C#)
```csharp
public void SetNamingRule(
	IList<TableCellCombinedParameterData> namingRule
)
```

## Parameters
- **namingRule** (`System.Collections.Generic.IList < TableCellCombinedParameterData >`) - The naming rule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The namingRule is empty or contains illegal characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

