---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsPathType.StartFromRiser
source: html/5e756a64-b50d-dee6-92f6-a76e9c6e6448.htm
---
# Autodesk.Revit.DB.Architecture.StairsPathType.StartFromRiser Property

True if the stairs path starts from the riser, false if it starts from the tread.

## Syntax (C#)
```csharp
public bool StartFromRiser { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The StairsPathType is not fixed up direction so the data being set is not applicable.

