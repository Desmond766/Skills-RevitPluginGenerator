---
kind: property
id: P:Autodesk.Revit.DB.IExtension.IsMiterLocked(System.Int32)
source: html/872443b5-e558-a97b-8893-605155754c3f.htm
---
# Autodesk.Revit.DB.IExtension.IsMiterLocked Property

Retrieves or set the miter locked status at the end.

## Syntax (C#)
```csharp
bool this[
	int index
] { get; set; }
```

## Parameters
- **index** (`System.Int32`)

## Remarks
Property index must be 0 or 1 to indicate two ends, otherwise exceptions will be thrown. 
For beams, only if the beam is extended and is mitered with other beams at the end, 
it can be locked. Otherwise, the setting is invalid

