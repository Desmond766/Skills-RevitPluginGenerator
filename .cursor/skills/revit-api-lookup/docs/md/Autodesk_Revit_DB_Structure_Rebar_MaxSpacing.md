---
kind: property
id: P:Autodesk.Revit.DB.Structure.Rebar.MaxSpacing
zh: 钢筋、配筋
source: html/1e7105e5-8d08-26ed-d97d-76754753fded.htm
---
# Autodesk.Revit.DB.Structure.Rebar.MaxSpacing Property

**中文**: 钢筋、配筋

Identifies the maximum spacing between rebar in rebar set.

## Syntax (C#)
```csharp
public double MaxSpacing { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The maxSpacing isn't bigger than 0.0.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element represents a single bar (the layout rule is Single).

