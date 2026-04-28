---
kind: method
id: M:Autodesk.Revit.DB.ColorFillSchemeEntry.SetIntegerValue(System.Int32)
source: html/2e86e474-4940-9df7-24cc-372c6832e2f1.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.SetIntegerValue Method

Sets new Integer value of entry.

## Syntax (C#)
```csharp
public void SetIntegerValue(
	int value
)
```

## Parameters
- **value** (`System.Int32`)

## Remarks
You should only use this method if the StorageType property reports the type of the entry as a Integer.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The entry has different storage type with Integer.

