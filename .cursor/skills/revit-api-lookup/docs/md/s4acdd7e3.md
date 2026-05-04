---
kind: method
id: M:Autodesk.Revit.DB.ColorFillSchemeEntry.SetDoubleValue(System.Double)
source: html/3e59b23f-0396-5577-6311-cf99c9760d78.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.SetDoubleValue Method

Sets new Double value of entry.

## Syntax (C#)
```csharp
public void SetDoubleValue(
	double value
)
```

## Parameters
- **value** (`System.Double`)

## Remarks
You should only use this method if the StorageType property reports the type of the entry as a Double.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The entry has different storage type with Double, or value is not finite.

