---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetCellsBySlotNumber(System.Int32,System.Collections.Generic.IList{System.Int32}@,System.Collections.Generic.IList{System.Int32}@)
source: html/5e26e7fb-2499-e430-5139-02c93f09972c.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetCellsBySlotNumber Method

Gets cells for the given slot number

## Syntax (C#)
```csharp
public void GetCellsBySlotNumber(
	int nSlotNumber,
	out IList<int> RowArr,
	out IList<int> ColArr
)
```

## Parameters
- **nSlotNumber** (`System.Int32`) - Slot Number
- **RowArr** (`System.Collections.Generic.IList < Int32 > %`) - The array of Row Number
- **ColArr** (`System.Collections.Generic.IList < Int32 > %`) - The array of Col Number

