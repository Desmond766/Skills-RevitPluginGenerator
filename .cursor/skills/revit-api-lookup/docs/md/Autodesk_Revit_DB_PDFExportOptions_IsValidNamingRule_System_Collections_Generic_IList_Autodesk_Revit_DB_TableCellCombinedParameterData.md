---
kind: method
id: M:Autodesk.Revit.DB.PDFExportOptions.IsValidNamingRule(System.Collections.Generic.IList{Autodesk.Revit.DB.TableCellCombinedParameterData})
source: html/b03aa274-2edd-0b87-fc11-2d9611f655ae.htm
---
# Autodesk.Revit.DB.PDFExportOptions.IsValidNamingRule Method

Whether naming rule is valid or not.

## Syntax (C#)
```csharp
public static bool IsValidNamingRule(
	IList<TableCellCombinedParameterData> namingRule
)
```

## Parameters
- **namingRule** (`System.Collections.Generic.IList < TableCellCombinedParameterData >`) - The naming rule to be validated.

## Returns
Whether or not the name is valid.

## Remarks
If true, this naming rule is a valid.
 If false, this naming rule is not valid for empty naming rule or illegal characters, such as Copy C# \ / : * ? " < > | .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

