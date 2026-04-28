---
kind: method
id: M:Autodesk.Revit.DB.TemporaryGraphicsManager.SetVisibility(System.Int32,System.Boolean)
source: html/69d4d684-9774-b729-551d-aacede3f86b9.htm
---
# Autodesk.Revit.DB.TemporaryGraphicsManager.SetVisibility Method

Changes the visibility of temporary graphics object.

## Syntax (C#)
```csharp
public void SetVisibility(
	int index,
	bool visible
)
```

## Parameters
- **index** (`System.Int32`) - Unique index of the temporary graphics object to be updated.
- **visible** (`System.Boolean`) - if true, it will make the temporary graphics object visible.
 if false, it will make the temporary graphics object invisible.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is out of range of TemporaryGraphicsManager managed objects, or the indexed object has been removed from the document.

