---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.MoveSlotTo(System.Int32,System.Int32,System.Int32,System.Int32)
source: html/225a5ab5-8d2e-5fd8-ad6f-c04eb7a4d40e.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.MoveSlotTo Method

Move the circuits in the source slot to the specific slot.

## Syntax (C#)
```csharp
public void MoveSlotTo(
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

## Remarks
If the moving circuit is in a group, all circuits in the group will be moved accordingly.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nMovingRow is invalid in Body.
 -or-
 The given column number nMovingCol is invalid in Body.
 -or-
 The given row number nToRow is invalid in Body.
 -or-
 The given column number nToCol is invalid in Body.
 -or-
 There is no circuit at given cell (nMovingRow, nMovingCol).
 -or-
 Cannot move the circuits at slot (nMovingRow, nMovingCol) to given slot (nToRow, nToCol).

