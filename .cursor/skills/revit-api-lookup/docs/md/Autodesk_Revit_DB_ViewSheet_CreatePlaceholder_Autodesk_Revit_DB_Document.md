---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.CreatePlaceholder(Autodesk.Revit.DB.Document)
zh: 图纸
source: html/9e47a397-b91e-76b3-d72c-85e8d1bdc708.htm
---
# Autodesk.Revit.DB.ViewSheet.CreatePlaceholder Method

**中文**: 图纸

Creates a placeholder sheet in a document.

## Syntax (C#)
```csharp
public static ViewSheet CreatePlaceholder(
	Document aDoc
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
The placeholder sheet.

## Remarks
Placeholder sheets represent sheets stored outside of the Revit model,
 but which should be organized along with the Revit sheets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

