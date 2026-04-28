---
kind: method
id: M:Autodesk.Revit.DB.ColorFillSchemeEntry.SetElementIdValue(Autodesk.Revit.DB.ElementId)
source: html/def19da6-7d4f-61e1-491b-85d530cb0beb.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.SetElementIdValue Method

Sets new ElementId value of entry.

## Syntax (C#)
```csharp
public void SetElementIdValue(
	ElementId value
)
```

## Parameters
- **value** (`Autodesk.Revit.DB.ElementId`)

## Remarks
You should only use this method if the StorageType property reports the type of the entry as a ElementId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The entry has different storage type with ElementId.

