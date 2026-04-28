---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.CanMoveSlotTo(System.Int32,System.Int32,System.Int32,System.Int32)
source: html/9207fb99-c8f3-41dd-b5ab-f4c56790d8f4.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.CanMoveSlotTo Method

Verifies if can circuits in the source slot to the specific slot.

## Syntax (C#)
```csharp
public bool CanMoveSlotTo(
	int nMovingRow,
	int nMovingCol,
	int nToRow,
	int nToCol
)
```

## Parameters
- **nMovingRow** (`System.Int32`) - The Row Number of cell to be moved.
- **nMovingCol** (`System.Int32`) - Start Column Number of cell to be moved.
- **nToRow** (`System.Int32`) - The Row Number of cell to moved to.
- **nToCol** (`System.Int32`) - End Column Number of cell to moved to.

## Returns
True if can move circuits in the source slot to the specific slot.

