---
kind: property
id: P:Autodesk.Revit.DB.Face.HasRegions
source: html/b54848a3-e52c-618c-24ad-20fc3c7966bb.htm
---
# Autodesk.Revit.DB.Face.HasRegions Property

Identifies if the face contains regions (which can be created, for example, by the Split Face command).

## Syntax (C#)
```csharp
public bool HasRegions { get; }
```

## Remarks
If this is true, use GetRegions () () () to get access to the specific Faces which make up the regions.

