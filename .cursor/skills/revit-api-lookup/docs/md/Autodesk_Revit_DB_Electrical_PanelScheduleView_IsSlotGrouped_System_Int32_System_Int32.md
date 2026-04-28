---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.IsSlotGrouped(System.Int32,System.Int32)
source: html/f9d08d83-873d-8917-abef-497f0b1072d4.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.IsSlotGrouped Method

Check if the slot is in a group

## Syntax (C#)
```csharp
public int IsSlotGrouped(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row Number
- **nCol** (`System.Int32`) - Column Number

## Returns
It is not in a group if the return value equals to 0. It is in a group if the return value is greater than 0 and the return value is the group number.

