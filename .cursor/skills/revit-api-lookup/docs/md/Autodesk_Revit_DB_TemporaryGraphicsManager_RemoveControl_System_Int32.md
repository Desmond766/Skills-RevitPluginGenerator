---
kind: method
id: M:Autodesk.Revit.DB.TemporaryGraphicsManager.RemoveControl(System.Int32)
source: html/3803b2b0-c688-faa3-ae1f-fdbd0135dd5a.htm
---
# Autodesk.Revit.DB.TemporaryGraphicsManager.RemoveControl Method

Deletes the existing control identified by the unique index.

## Syntax (C#)
```csharp
public void RemoveControl(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - Unique index of the control to be deleted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is out of range of TemporaryGraphicsManager managed objects, or the indexed object has been removed from the document.

