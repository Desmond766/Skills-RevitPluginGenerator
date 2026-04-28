---
kind: property
id: P:Autodesk.Revit.DB.ViewSchedule.UseStripedRowsOnSheets
zh: 明细表
source: html/3ffca97c-3963-1d68-0775-fbab3644856e.htm
---
# Autodesk.Revit.DB.ViewSchedule.UseStripedRowsOnSheets Property

**中文**: 明细表

Indicates whether a property setting of true will also change the display of this schedule to show striped rows on a sheet.
 If true, setting that property to true will also change the display.
 If false, striped rows will not display for this schedule on a sheet no matter what value is set for HasStripedRows.

## Syntax (C#)
```csharp
public bool UseStripedRowsOnSheets { get; set; }
```

## Remarks
Striped rows on sheets can be overidden by shading or conditional formatting.

