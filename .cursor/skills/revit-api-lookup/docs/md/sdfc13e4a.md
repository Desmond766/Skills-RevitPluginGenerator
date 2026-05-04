---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.SurfaceName
source: html/066be9de-edf8-4d48-c80f-f289e85866c4.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.SurfaceName Property

The unique name identifier for this surface.

## Syntax (C#)
```csharp
public string SurfaceName { get; }
```

## Remarks
Surface and Opening elements get an Name element assigned
 according to the below described schema: (Orientation)(Space#)[(Other space#)](Exposure)(Type)-(sequence number)[Opening Type+#] Sample:
 N-101-102-E-W-O-77 N = Orientation [N/NE/E/SE/S/SW/W/NW/N/T/B/X]
 (every surface within the sector of 22.5 degrees from the north
 vector gets the letter N etc) (horizontal surfaces facing upwards
 get the letter T for top, downwards B for bottom) (shading surfaces
 get the letter X for differentiation). 101 = Space number. 102 = Other space number. E = Exposure - exterior/interior/underground [E/I/U]. W = Type [W/C/R/F] (Wall, Roof, Ceiling, Floor, Shade) (every
 surface type has it's letter W-Wall R-Roof C-Ceiling F-Floor S-Shade). O = Opening Type [W/D/O] (Window, Door, Opening) (every opening
 type has it's letter W-Window D-Door O-Opening). 77 = sequence number. Sample surface names: N-101-E-W-84 North facing Exterior Wall #84 in space 101. N-101-E-W-84-D-1 Door #1 in North facing Exterior Wall #84 in space 101. E-101-102-I-W-92 Vertical Interior Wall #92 between space 101 and 102. T-101-E-R-141 Top facing Exterior Roof #141 in space 101. B-101-201-I-F-88 Bottom facing Interior Floor #88 between space 101 and 201. X-73 Shade #73.

