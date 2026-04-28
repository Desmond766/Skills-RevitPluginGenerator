---
kind: method
id: M:Autodesk.Revit.DB.ColorFillSchemeEntry.GetElementIdValue
source: html/1483c739-c936-5e88-8fd9-f82baf472a45.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.GetElementIdValue Method

Gets the ElementId value stored within the entry.

## Syntax (C#)
```csharp
public ElementId GetElementIdValue()
```

## Returns
The ElementId contained in the entry.

## Remarks
This method should only be used if the StorageType property reports the type of the entry as a ElementId.

