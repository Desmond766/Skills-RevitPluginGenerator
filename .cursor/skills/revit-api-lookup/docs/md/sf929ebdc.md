---
kind: property
id: P:Autodesk.Revit.DB.IExtension.Extended(System.Int32)
source: html/ddce285f-933b-a528-e738-ca9afed1693d.htm
---
# Autodesk.Revit.DB.IExtension.Extended Property

Retrieves or set the extension status at the end

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
For beams, if the beam extension status is changed, other status such as 
the symbolic extension status, miter status, miter locked status, and
other beams extension status will be changed automatically at the same time.
This change can protect that a join can have up to two extended beams, if
there are two extended beams at the join, they shall be mitered.

