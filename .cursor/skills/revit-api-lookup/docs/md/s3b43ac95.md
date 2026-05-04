---
kind: property
id: P:Autodesk.Revit.DB.ViewSheet.SheetNumber
zh: 图纸
source: html/5f9129ba-b323-c55d-e27e-46d88bec503b.htm
---
# Autodesk.Revit.DB.ViewSheet.SheetNumber Property

**中文**: 图纸

The sheet number of the document.

## Syntax (C#)
```csharp
public string SheetNumber { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: sheetNumber is an empty string or contains only whitespace.
 -or-
 When setting this property: sheetNumber cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 When setting this property: Sheet number is already in use.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

