---
kind: property
id: P:Autodesk.Revit.DB.IExtension.SymbolicExtended(System.Int32)
source: html/2149782e-00a8-09d1-ea09-8a2575639d2e.htm
---
# Autodesk.Revit.DB.IExtension.SymbolicExtended Property

Retrieves or set the symbolic extension status at the end

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
For beams, symbolic extension setting only works when the beam is extended, mitered, and miter locked
at the end. Otherwise the setting is invalid

