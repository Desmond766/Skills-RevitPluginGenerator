---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForNoteBlock(Autodesk.Revit.DB.Document)
zh: 明细表
source: html/5735da73-cf36-2335-2249-ac39729934fa.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForNoteBlock Method

**中文**: 明细表

Gets the default view name that will be used when creating a note block.

## Syntax (C#)
```csharp
public static string GetDefaultNameForNoteBlock(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.

## Returns
The default view name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

