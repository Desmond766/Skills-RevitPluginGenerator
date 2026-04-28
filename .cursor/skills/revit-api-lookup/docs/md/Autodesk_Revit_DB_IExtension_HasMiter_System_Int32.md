---
kind: property
id: P:Autodesk.Revit.DB.IExtension.HasMiter(System.Int32)
source: html/774668d8-eefd-f814-90b0-39dc11aae947.htm
---
# Autodesk.Revit.DB.IExtension.HasMiter Property

Retrieves the miter status at the end

## Syntax (C#)
```csharp
bool this[
	int index
] { get; }
```

## Parameters
- **index** (`System.Int32`)

## Remarks
Property index must be 0 or 1 to indicate two ends, otherwise exceptions will be thrown. 
For beams, this can check whether the beam is mitered with other beams at the end

