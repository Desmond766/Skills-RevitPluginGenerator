---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.HasImageField
zh: 明细表
source: html/5796f4c6-0611-d142-172a-70031467a9b4.htm
---
# Autodesk.Revit.DB.ViewSchedule.HasImageField Method

**中文**: 明细表

Checks whether the schedule definition includes any image-related fields and if any elements in the schedule actually have images in those fields.

## Syntax (C#)
```csharp
public bool HasImageField()
```

## Returns
True if the schedule has at least one image field showing at least one image, false otherwise.

## Remarks
This method may return an incorrect value if the data of the schedule view is out of date. Check [!:IsDataOutOfData()] ,
 and call RefreshData () () () to ensure that the return value is correct.

