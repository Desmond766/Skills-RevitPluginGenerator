---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ViewSystemsAnalysisReport.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/860c6374-1268-f064-22a6-f8121ec0fc17.htm
---
# Autodesk.Revit.DB.Analysis.ViewSystemsAnalysisReport.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new view for the systems analysis report.

## Syntax (C#)
```csharp
public static ViewSystemsAnalysisReport Create(
	Document document,
	string viewName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the view is to be created.
- **viewName** (`System.String`) - The name of the new report view.

## Returns
The newly created view instance, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the operation fails.

## Remarks
A report instance is typically created to request a new systems analysis. The default values include the weather file "USA_CO_Denver.Intl.AP.725650_TMY3.epw" and
 the workflow file "HVAC Systems Loads and Sizing.osw". Both are part of the Revit installation. The default output folder is the system TEMP folder.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - viewName cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 viewName is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

