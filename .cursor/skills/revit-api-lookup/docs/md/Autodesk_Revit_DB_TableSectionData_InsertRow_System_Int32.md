---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.InsertRow(System.Int32)
source: html/e14a7a0f-0a5c-c010-7cc2-a83cb1a9da8c.htm
---
# Autodesk.Revit.DB.TableSectionData.InsertRow Method

Inserts a row data at a specified index.

## Syntax (C#)
```csharp
public void InsertRow(
	int nIndex
)
```

## Parameters
- **nIndex** (`System.Int32`) - An integer index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The row can't be inserted in data section of standard schedule except Key Schedule, Sheet List Schedule
 or following categories without emdeded schedule: MEP Space, Room, Area.
 or nIndex is invalid index.

