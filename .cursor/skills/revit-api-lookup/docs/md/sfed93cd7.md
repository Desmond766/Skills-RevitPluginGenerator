---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.CanBeSwapped
source: html/a8effafa-42c2-10bf-dda3-9a435c4075a2.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.CanBeSwapped Method

Checks if the fabrication configuration can be swapped.

## Syntax (C#)
```csharp
public bool CanBeSwapped()
```

## Returns
True if the fabrication configuration can be swapped, false otherwise.

## Remarks
Swapping configuration is not permitted if the existing configuration has already been used to create fabrication part elements in the document.

